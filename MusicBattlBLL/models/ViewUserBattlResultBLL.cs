using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ViewUserBattlResultBLL : IViewUserBattlResultBLL
    {
        #region Properties

        private IRepositoryBLL<IViewUserBattlResult> _battlRepository;
        private IViewUserFavoritesSongsBLL _viewUserFavoritesSongsBLL;
        private IDataBaseAccess _dataBaseAccess;
        private int _total;
        private IList<IViewUserBattlResult> _collection;

        public IList<IViewUserBattlResult> Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        #endregion Properties

        #region Constructor

        public ViewUserBattlResultBLL( IRepositoryBLL<IViewUserBattlResult> battlRepository , IViewUserFavoritesSongsBLL viewUserFavoritesSongsBLL )
        {
            _battlRepository = battlRepository;
            _viewUserFavoritesSongsBLL = viewUserFavoritesSongsBLL;
            _dataBaseAccess = _battlRepository.repositorieDAL.DataBaseAccess;
        }

        #endregion Constructor

        #region IList<IViewUserBattlResult> GetBattlsWonByProfileId( int profileId , int page = 0 , int rowCount = 0 )

        public IList<IViewUserBattlResult> GetBattlsWonByProfileId( int profileId , int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Page = page;
            query.RowCount = rowCount;
            query.Where = string.Format(" profileIdFirst ={0} AND totalFirst > totalSecond OR profileIdSecond = {0} AND totalFirst < totalSecond " , profileId);

            var result = _battlRepository.Find(query);

            query.From = "ViewUserBattlWonLostResult";
            _total = _battlRepository.Count(query);

            _collection = result;

            return _collection;
        }

        #endregion IList<IViewUserBattlResult> GetBattlsWonByProfileId( int profileId , int page = 0 , int rowCount = 0 )

        #region IList<IViewUserBattlResult> GetBattlsLostByProfileId( int profileId , int page = 0 , int rowCount = 0 )

        public IList<IViewUserBattlResult> GetBattlsLostByProfileId( int profileId , int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Page = page;
            query.RowCount = rowCount;
            query.Where = string.Format(" profileIdFirst = {0} AND totalFirst < totalSecond OR profileIdSecond = {0} AND totalFirst > totalSecond " , profileId);

            var result = _battlRepository.Find(query);

            query.From = "ViewUserBattlWonLostResult";
            _total = _battlRepository.Count(query);

            _collection = result;

            return _collection;
        }

        #endregion IList<IViewUserBattlResult> GetBattlsLostByProfileId( int profileId , int page = 0 , int rowCount = 0 )

        #region IViewUserFavoritesSongsBLL GetFavoritesByProfileId( int profileId , int page = 0 , int rowCount = 0)

        public IViewUserFavoritesSongsBLL GetFavoritesByProfileId( int profileId , int page = 0 , int rowCount = 0 )
        {
            _viewUserFavoritesSongsBLL.GetFavoriteSongsByProfileId(profileId , page , rowCount);

            return _viewUserFavoritesSongsBLL;
        }

        #endregion IViewUserFavoritesSongsBLL GetFavoritesByProfileId( int profileId , int page = 0 , int rowCount = 0)

        #region IList<IViewUserBattlResult> GetDummyCollection( int count )

        private IList<IViewUserBattlResult> GetDummyCollection( int count )
        {
            List<IViewUserBattlResult> result = new List<IViewUserBattlResult>();

            for( int i = 0; i < count; i++ )
            {
                IViewUserBattlResult item = new ViewUserBattlResult();
                result.Add(item);
            }

            return result;
        }

        #endregion IList<IViewUserBattlResult> GetDummyCollection( int count )
    }
}