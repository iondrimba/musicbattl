using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ViewTopSongsBLL : IViewTopSongsBLL
    {
        #region Properties

        private IRepositoryBLL<IViewTopSongs> _repository;
        private IDataBaseAccess _dataBaseAccess;
        private int _total = 0;
        private IList<IViewTopSongs> _collection;

        public int Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
            }
        }

        public IList<IViewTopSongs> Collection
        {
            get
            {
                return _collection;
            }
            set
            {
                _collection = value;
            }
        }

        #endregion Properties

        #region Constructor

        public ViewTopSongsBLL( IRepositoryBLL<IViewTopSongs> battlRepository )
        {
            _repository = battlRepository;
            _dataBaseAccess = _repository.repositorieDAL.DataBaseAccess;
        }

        #endregion Constructor



        #region IViewTopSongsBLL Members

        public IList<IViewTopSongs> GetTopSongsBronze( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Where = " (percentage BETWEEN 0 AND 1) ";
            query.Page = page;
            query.RowCount = rowCount;
            IList<IViewTopSongs> result = GetTopSongs(query);

            _collection = result;

            return result;
        }

        public IList<IViewTopSongs> GetTopSongsSilver( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Where = " (percentage BETWEEN 1 AND 3)";
            query.Page = page;
            query.RowCount = rowCount;
            IList<IViewTopSongs> result = GetTopSongs(query);

            _collection = result;

            return result;
        }

        public IList<IViewTopSongs> GetTopSongsGold( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Where = " (percentage BETWEEN 4 AND 100)";
            query.Page = page;
            query.RowCount = rowCount;
            IList<IViewTopSongs> result = GetTopSongs(query);

            _collection = result;

            return result;
        }

        #endregion IViewTopSongsBLL Members

        private IList<IViewTopSongs> GetTopSongs( IDataQuery query )
        {
            query.OrderBy = " ArtistName ";
            var results = _repository.Find(query);

            query.From = "ViewTopSongsPercentage";
            this.Total = _repository.Count(query);

            _collection = results;

            return results;
        }
    }
}