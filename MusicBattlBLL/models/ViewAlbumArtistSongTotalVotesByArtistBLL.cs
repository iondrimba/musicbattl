using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ViewAlbumArtistSongTotalVotesByArtistBLL : IViewAlbumArtistSongTotalVotesByArtistBLL
    {
        #region Properties

        private IRepositoryBLL<IViewAlbumArtistSongTotalVotesByArtist> _repository;
        private IDataBaseAccess _dataBaseAccess;
        private IList<IViewAlbumArtistSongTotalVotesByArtist> _collection;
        private int _total;

        public IList<IViewAlbumArtistSongTotalVotesByArtist> Collection
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

        public ViewAlbumArtistSongTotalVotesByArtistBLL( IRepositoryBLL<IViewAlbumArtistSongTotalVotesByArtist> repository )
        {
            _repository = repository;
            _dataBaseAccess = _repository.repositorieDAL.DataBaseAccess;
        }

        #endregion Constructor

        #region IList<IViewAlbumArtistSongTotalVotesByArtist> GetTopMostVotedArtist( int page = 0 , int rowCount = 0 )

        public IList<IViewAlbumArtistSongTotalVotesByArtist> GetTopMostVotedArtist( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.OrderBy = " Total DESC ";
            query.Page = page;
            query.RowCount = rowCount;
            _repository.Find(query);

            query.From = "ViewAlbumArtistSongTotalVotesByArtist";
            this.Total = _repository.Count(query);

            _collection = _repository.Collection;

            return _collection;
        }

        #endregion IList<IViewAlbumArtistSongTotalVotesByArtist> GetTopMostVotedArtist( int page = 0 , int rowCount = 0 )
    }
}