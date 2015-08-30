using System.Collections.Generic;
using System.Linq;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ViewUserFavoritesSongsBLL : IViewUserFavoritesSongsBLL
    {
        #region Properties

        private IRepositoryBLL<IViewUserFavoritesSongs> _repository;
        private IDataBaseAccess _dataBaseAccess;
        private int _total = 0;

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private IList<IViewUserFavoritesSongs> _collection;

        public IList<IViewUserFavoritesSongs> Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }

        #endregion Properties

        #region Constructor

        public ViewUserFavoritesSongsBLL( IRepositoryBLL<IViewUserFavoritesSongs> battlRepository )
        {
            _repository = battlRepository;
            _dataBaseAccess = _repository.repositorieDAL.DataBaseAccess;
        }

        #endregion Constructor

        #region IList<IViewUserFavoritesSongs> GetFavoriteSongsByProfileId( int profileId , int page = 0 , int rowCount = 0  )

        public IList<IViewUserFavoritesSongs> GetFavoriteSongsByProfileId( int profileId , int page = 0 , int rowCount = 0 )
        {
            IList<IViewUserFavoritesSongs> retorno = new List<IViewUserFavoritesSongs>();

            IDataQuery query = new DataQuery();
            query.Page = page;
            query.RowCount = rowCount;
            query.Where = string.Format(" (profileId={0}) " , profileId);

            var getFavorires = _repository.Find(query).ToList<IViewUserFavoritesSongs>();
            IList<IViewUserFavoritesSongs> filteredResult = getFavorires;

            query.From = "ViewUserFavoritesSongs";
            _total = _repository.Count(query);

            _collection = filteredResult;

            return filteredResult;
        }

        #endregion IList<IViewUserFavoritesSongs> GetFavoriteSongsByProfileId( int profileId , int page = 0 , int rowCount = 0  )
    }
}