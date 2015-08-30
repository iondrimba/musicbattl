using System;
using System.Configuration;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using MusicBattlBLL.interfaces;
using MusicBattlBLL.models;
using MusicBattlBLL.repositories;
using MusicBattlDAL;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MusicBattlSignalR
{
    public class BattlTimer
    {
        // Singleton instance
        private readonly static Lazy<BattlTimer> _instance = new Lazy<BattlTimer>(
            () => new BattlTimer(GlobalHost.ConnectionManager.GetHubContext<BattlTimerHub>().Clients));

        private readonly object _battlStateLock = new object();
        private readonly object _updateBattlLock = new object();

        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(1000);
        private volatile int totalTime = 0;
        private volatile int totalTimeReset = 0;
        private int battleTotalTime = 600000;
        private int battlTimeResetTime = 2000;

        private Timer _timer;
        private Timer _timerReset;
        private volatile bool _updatingBattl;
        private volatile BattlState _battlState;
        private volatile IViewBattl _battl;

        private BattlTimer( IHubConnectionContext<dynamic> clients )
        {
            Clients = clients;
        }

        public static BattlTimer Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        public BattlState BattlState
        {
            get { return _battlState; }
            private set { _battlState = value; }
        }

        public string GetTime()
        {
            return DateTime.Now.ToString();
        }

        public void BattlStart()
        {
            lock( _battlStateLock )
            {
                if( BattlState == BattlState.Closed )
                {
                    _timer = new Timer(BattlUpdate , null , _updateInterval , _updateInterval);

                    totalTime = MusicBattlWebAPI.Helpers.WebConfigHelper.BattlInterval * battleTotalTime;

                    BattlState = BattlState.Open;

                    BroadcastStateChange(BattlState.Open);
                }
            }
        }

        public void BattlEnd()
        {
            lock( _updateBattlLock )
            {
                if( BattlState == BattlState.Open )
                {
                    if( _timer != null )
                    {
                        _timer.Dispose();
                        totalTime = 0;
                    }

                    if( _timerReset != null )
                    {
                        _timerReset.Dispose();
                        totalTimeReset = 0;
                    }

                    Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase();

                    IRepository<IBattl> dalBattl = new BattlRepository(db);
                    IRepositoryBLL<IBattl> battlRepoBll = new BattlRepositoryBLL(dalBattl);

                    IRepository<IViewBattl> viewdalBattl = new ViewBattlRepository(db);
                    IRepositoryBLL<IViewBattl> iViewbattlRepoBll = new ViewBattlRepositoryBLL(viewdalBattl);

                    IBattlBLL battlBLL = new BattlBLL(battlRepoBll , iViewbattlRepoBll);

                    battlBLL.EndActiveBattl();

                    _battl = battlBLL.CreateBattl();

                    BattlState = BattlState.Closed;

                    BroadcastStateChange(BattlState.Closed);
                }
            }
        }

        public void BattlReset()
        {
            lock( _updateBattlLock )
            {
                if( BattlState == BattlState.Closed )
                {
                    _timerReset = new Timer(BattlResetUpdate , null , _updateInterval , _updateInterval);

                    totalTimeReset = MusicBattlWebAPI.Helpers.WebConfigHelper.BattlInterval * battlTimeResetTime;

                    BattlState = BattlState.Reset;

                    BroadcastStateChange(BattlState.Reset);
                }
            }
        }

        private void BattlUpdate( object state )
        {
            lock( _updateBattlLock )
            {
                if( !_updatingBattl )
                {
                    _updatingBattl = true;

                    totalTime = totalTime - 1000;

                    BroadcastBattlTimer(totalTime);

                    if( totalTime == 0 )
                    {
                        BattlEnd();
                    }

                    _updatingBattl = false;
                }
            }
        }

        private void BattlResetUpdate( object state )
        {
            lock( _updateBattlLock )
            {
                if( !_updatingBattl )
                {
                    _updatingBattl = true;

                    totalTimeReset = totalTimeReset - 1000;

                    BroadcastBattlResetTimer(totalTimeReset);

                    if( totalTimeReset == 0 )
                    {
                        if( _timerReset != null )
                        {
                            _timerReset.Dispose();
                            totalTimeReset = 0;
                        }

                        BattlState = BattlState.Closed;

                        BattlStart();
                    }

                    _updatingBattl = false;
                }
            }
        }

        private void BroadcastStateChange( BattlState battlState )
        {
            switch( battlState )
            {
                case BattlState.Open:
                    Clients.All.battlStarted();
                    break;

                case BattlState.Closed:
                    Clients.All.battlEnded(_battl);
                    break;

                case BattlState.Reset:
                    Clients.All.battlReseted();
                    break;

                default:
                    break;
            }
        }

        private void BroadcastBattlTimer( int time )
        {
            Clients.All.updateBattlTimer(time);
        }

        private void BroadcastBattlResetTimer( int time )
        {
            Clients.All.updateBattlResetTimer(time);
        }

        public void BattlVote( Vote vote )
        {
            lock( _updateBattlLock )
            {
                if( BattlState == BattlState.Open )
                {
                    if( VoteSong(vote) )
                    {
                        BroadcastBattlVoted(vote);
                    }
                }
            }
        }

        private bool VoteSong( Vote vote )
        {
            bool retorno = false;
            vote.Votes = 1;
            
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase();

            IRepository<IVote> dal = new VoteRepository(db);
            IRepositoryBLL<IVote> votelRepoBll = new VoteRepositoryBLL(dal);
            IVoteBLL voteBLL = new VoteBLL(votelRepoBll);

            retorno = (voteBLL.VoteOnArtist(vote).VoteId > 0);

            return retorno;
        }

        private void BroadcastBattlVoted( Vote vote )
        {
            Clients.All.updateBattlVotes(vote);
        }
    }

    public enum BattlState
    {
        Closed ,
        Open ,
        Reset
    }
}