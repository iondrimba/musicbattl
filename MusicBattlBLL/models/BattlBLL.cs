using Microsoft.Practices.EnterpriseLibrary.Data;
using MusicBattlBLL.interfaces;
using MusicBattlBLL.repositories;
using MusicBattlDAL;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using MusicBattlDAL.repositories.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;

namespace MusicBattlBLL.models
{
    public class BattlBLL : IBattlBLL
    {
        private IRepositoryBLL<IBattl> _battlRepository;
        private IRepositoryBLL<IViewBattl> _viewBattlRepository;
        private Database _dataBase;
        private int _BattlInterval;

        public int BattlInterval
        {
            get { return _BattlInterval; }
            set { _BattlInterval = value; }
        }

        public BattlBLL(IRepositoryBLL<IBattl> battlRepository, IRepositoryBLL<IViewBattl> viewBattlRepository)
        {
            _battlRepository = battlRepository;
            _viewBattlRepository = viewBattlRepository;
            _dataBase = ((BattlRepository)_battlRepository.repositorieDAL).DataBase;
        }

        #region IBattlBLL Members

        #region IBattlBLL CreateBattl()

        public IViewBattl CreateBattl()
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format("ViewBattl.active=1");
            IViewBattl _viewBattl = new ViewBattl();
            IList<IViewBattl> col = _viewBattlRepository.Find(query);

            if (col.Count > 0)
            {
                _viewBattl = col[0];
            }
            else
            {
                IBattl battl = GetBattlNotPlayedThisWeek();
                DateTime battlTime = DateTime.Now; //GetLastBattlTime();
                battl.BattlDate = battlTime;
                battl.StartTime = new DateTime(battlTime.Year, battlTime.Month, battlTime.Day, battlTime.Hour, battlTime.Minute, 0);
                battl.EndTime = battl.StartTime.AddSeconds(59);
                battl.Active = true;

                using (TransactionScope scope = new TransactionScope())
                {
                    battl = _battlRepository.Add(battl);

                    query = new DataQuery();
                    query.Where = string.Format("ViewBattl.BattlId={0} and active=1", battl.BattlId);
                    col = _viewBattlRepository.Find(query);

                    if (col.Count > 0)
                    {
                        _viewBattl = col[0];
                    }

                    scope.Complete();
                }
            }

            return _viewBattl;
        }

        #endregion IBattlBLL CreateBattl()

        #region IBattlBLL CreateBattl(DateTime time)

        public IViewBattl CreateBattl(DateTime time)
        {
            IBattl battl = GetBattlNotPlayedThisWeek();
            battl.BattlDate = time;
            battl.StartTime = new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, 0);
            battl.EndTime = battl.StartTime.AddSeconds(59);

            battl = _battlRepository.Add(battl);

            IDataQuery query = new DataQuery();
            query.Where = string.Format("ViewBattl.battlId={0}", battl.BattlId);
            IViewBattl _viewBattl = new ViewBattl();

            _viewBattl = _viewBattlRepository.Find(query)[0];

            return _viewBattl;
        }

        #endregion IBattlBLL CreateBattl(DateTime time)

        #region IBattlBLL CreateTestBattl(DateTime date)

        public IBattl CreateTestBattl(DateTime date)
        {
            DateTime lastBattlTime = date;


            IRepositoryBLL<ISong> repo = new SongRepositoryBLL(new SongRepository(_dataBase));
            ISongBLL songBLL = new SongBLL(repo);
            ISong fisrtSong = songBLL.GetRandomSong(0);
            ISong secondSong = songBLL.GetRandomSong(fisrtSong.SongId);

            IBattl battl = new Battl();
            battl.FirstSongId = fisrtSong.SongId;
            battl.SecondSongId = secondSong.SongId;
            battl.BattlDate = lastBattlTime.AddHours(1);
            battl.StartTime = battl.BattlDate.AddMinutes(5);
            battl.EndTime = battl.StartTime.AddMinutes(5);

            battl = _battlRepository.Add(battl);

            return battl;
        }

        #endregion IBattlBLL CreateTestBattl(DateTime date)

        #region DateTime GetLastBattlTime()

        private DateTime GetLastBattlTime()
        {
            IDataQuery query = new DataQuery();
            query.OrderBy = " battlId DESC ";

            IBattl battl = new Battl();
            IList<IBattl> collection = _battlRepository.GetTop(1, query);

            if (collection.Count == 0)
            {
                battl.EndTime = DateTime.Now;
            }
            else
            {
                battl.EndTime = collection[0].EndTime;
            }

            return battl.EndTime;
        }

        #endregion DateTime GetLastBattlTime()

        #region IBattl GetBattlNotPlayedThisWeek()

        private IBattl GetBattlNotPlayedThisWeek()
        {
            IBattl battl = new Battl();
            IDataQuery query = new DataQuery();

            DateTime date = DateTime.Now;
            int daysRange = 6;
            int dayWeek = (int)date.DayOfWeek;
            DateTime lastMonday = date.AddDays(-daysRange);
            DateTime lastSunday = date;

            IRepositoryBLL<ISong> repo = new SongRepositoryBLL(new SongRepository(_dataBase));
            ISongBLL songBLL = new SongBLL(repo);

            ISong fisrtSong = songBLL.GetRandomSong(0);
            ISong secondSong = songBLL.GetRandomSong(fisrtSong.SongId);

            battl.FirstSongId = fisrtSong.SongId;
            battl.SecondSongId = secondSong.SongId;

            return battl;
        }

        #endregion IBattl GetBattlNotPlayedThisWeek()

        #region IBattlBLL GetActiveBattl()

        public IViewBattl GetActiveBattl(IViewBattlQueryParams queryParams)
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format("ViewBattl.active =1");
            IViewBattl _battl = new ViewBattl();
            IList<IViewBattl> col = _viewBattlRepository.Find(query);

            if (col.Count > 0)
            {
                _battl = col[0];

                if (BattlHasExperied(_battl))
                {
                    EndActiveBattl();

                    _battl = CreateBattl();
                }
            }
            else
            {
                _battl = CreateBattl();
            }

            return _battl;
        }

        private bool BattlHasExperied(IViewBattl pBattl)
        {
            bool retorno = false;

            TimeSpan difference = (TimeSpan)(DateTime.Now - pBattl.StartTime);

            if (difference.Minutes > 10 && difference.Seconds > 0)
             {
                retorno = true;
            }

            return retorno;
        }

        #endregion IBattlBLL GetActiveBattl()

        #region IEnumerable<IBattlBLL> GetTopBattls( int top )

        public IList<IBattl> GetPastBattls(int count)
        {
            IDataQuery query = new DataQuery();
            query.OrderBy = " battlDate DESC";
            query.Where = " active=0";
            _battlRepository.GetTop(count, query);
            IList<IBattl> _battls = _battlRepository.Collection;

            return _battls;
        }

        #endregion IEnumerable<IBattlBLL> GetTopBattls( int top )

        #endregion IBattlBLL Members

        #region IBattlBLL Members

        public void EndActiveBattl()
        {
            IDataQuery query = new DataQuery();
            query.Where = " active=1";
            _battlRepository.Find(query);
            IList<IBattl> _battls = _battlRepository.Collection;

            if (_battls.Count > 0)
            {
                _battls[0].Active = false;
                _battlRepository.Update(_battls[0]);
            }
        }

        #endregion IBattlBLL Members
    }
}