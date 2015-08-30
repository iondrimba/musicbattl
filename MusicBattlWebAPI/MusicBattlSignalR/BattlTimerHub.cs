using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using MusicBattlDAL;

namespace MusicBattlSignalR
{
    [HubName("battlTimer")]
    public class BattlTimerHub : Hub
    {
        private readonly BattlTimer _battlTimer;

        public BattlTimerHub()
            : this(BattlTimer.Instance)
        {
        }

        public BattlTimerHub( BattlTimer battlTimer )
        {
            _battlTimer = battlTimer;
        }

        public string GetTime()
        {
            return _battlTimer.GetTime();
        }

        public string GetBattlState()
        {
            return _battlTimer.BattlState.ToString();
        }

        public void BattlStart()
        {
            _battlTimer.BattlStart();
        }

        public void BattlEnd()
        {
            _battlTimer.BattlEnd();
        }

        public void BattlReset()
        {
            _battlTimer.BattlReset();
        }

        public void BattlVote( Vote vote )
        {
            _battlTimer.BattlVote(vote);
        }
    }
}