using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ViewTopUsersBLL : IViewTopUsersBLL
    {
        #region Properties

        private IRepositoryBLL<IViewTopUsers> _repository;
        private IDataBaseAccess _dataBaseAccess;
        private int _total = 0;

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private IList<IViewTopUsers> _collection;

        public IList<IViewTopUsers> Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }

        #endregion Properties

        #region Constructor

        public ViewTopUsersBLL( IRepositoryBLL<IViewTopUsers> battlRepository )
        {
            _repository = battlRepository;
            _dataBaseAccess = _repository.repositorieDAL.DataBaseAccess;
        }

        #endregion Constructor

        public IList<IViewTopUsers> GetTopUsersBronze( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Where = " (percentage BETWEEN 0 AND 1) ";
            query.Page = page;
            query.RowCount = rowCount;
            IList<IViewTopUsers> result = GetTopUsers(query);

            return result;
        }

        public IList<IViewTopUsers> GetTopUsersSilver( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Where = " (percentage BETWEEN 2 AND 5) ";
            query.Page = page;
            query.RowCount = rowCount;
            IList<IViewTopUsers> result = GetTopUsers(query);

            return result;
        }

        public IList<IViewTopUsers> GetTopUsersGold( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Where = " (percentage BETWEEN 5 AND 100) ";
            query.Page = page;
            query.RowCount = rowCount;
            IList<IViewTopUsers> result = GetTopUsers(query);

            return result;
        }

        private IList<IViewTopUsers> GetTopUsers( IDataQuery query )
        {
            var getTopUsers = _repository.Find(query);
            IList<IViewTopUsers> filteredResult = getTopUsers;

            query.From = "viewTopUsersPercentage";
            this.Total = _repository.Count(query);

            _collection = filteredResult;

            return filteredResult;
        }
    }
}