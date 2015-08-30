using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MusicBattlBLL.interfaces;
using MusicBattlDAL;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using System.Text;

namespace MusicBattlBLL.models
{
    public class ViewAlbumArtistSongTotalVotesBLL : IViewAlbumArtistSongTotalVotesBLL
    {
        #region Properties

        private IRepositoryBLL<IViewAlbumArtistSongTotalVotes> _repository;
        private IDataBaseAccess _dataBaseAccess;
        private IList<IViewAlbumArtistSongTotalVotes> _collection;
        private int _total;
        private string _orderBy = string.Empty;

        public string OrderBy
        {
            get { return _orderBy; }
            set { _orderBy = value; }
        }

        public IList<IViewAlbumArtistSongTotalVotes> Collection
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

        public ViewAlbumArtistSongTotalVotesBLL( IRepositoryBLL<IViewAlbumArtistSongTotalVotes> repository )
        {
            _repository = repository;
            _dataBaseAccess = _repository.repositorieDAL.DataBaseAccess;
        }

        #endregion Constructor

        #region IList<IViewAlbumArtistSongTotalVotes> GetTopMostVotedSong( int page = 0 , int rowCount = 0  )

        public IList<IViewAlbumArtistSongTotalVotes> GetTopMostVotedSong( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.OrderBy = " total DESC ";
            if( !String.IsNullOrEmpty(_orderBy) )
            {
                query.OrderBy = _orderBy;
            }

            query.Page = page;
            query.RowCount = rowCount;

            IList<IViewAlbumArtistSongTotalVotes> result = _repository.Find(query);

            query.From = "ViewAlbumArtistSongTotalVotes";
            this.Total = _repository.Count(query);

            return result;
        }

        #endregion IList<IViewAlbumArtistSongTotalVotes> GetTopMostVotedSong( int page = 0 , int rowCount = 0  )

        #region IList<IViewAlbumArtistSongTotalVotes> GetTopMostVotedAlbum( int page = 0 , int rowCount = 0  )

        public IList<IViewAlbumArtistSongTotalVotes> GetTopMostVotedAlbum( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.OrderBy = " total DESC ";

            if( !String.IsNullOrEmpty(_orderBy) )
            {
                query.OrderBy = _orderBy;
            }

            IList<IViewAlbumArtistSongTotalVotes> retorno = new List<IViewAlbumArtistSongTotalVotes>();

            retorno = _repository.Find(query);

            var groupedResultByAlbum = (from n in retorno
                                        group n by n.AlbumName into g
                                        orderby g.Key
                                        select new ViewAlbumArtistSongTotalVotes
                                        {
                                            SongId = 0 ,
                                            AlbumName = g.Key ,
                                            ArtistId = g.FirstOrDefault().ArtistId ,
                                            SongName = string.Empty ,
                                            ArtistName = g.FirstOrDefault().ArtistName ,
                                            Total = g.Sum(m => m.Total).Value
                                        }).ToList<IViewAlbumArtistSongTotalVotes>();

            IList<IViewAlbumArtistSongTotalVotes> result = groupedResultByAlbum.OrderByDescending(o => o.Total).ToList();

            return result;
        }

        #endregion IList<IViewAlbumArtistSongTotalVotes> GetTopMostVotedAlbum( int page = 0 , int rowCount = 0  )

        #region IList<IViewAlbumArtistSongTotalVotes> GetTopMostVotedArtist( int page = 0 , int rowCount = 0 )

        public IList<IViewAlbumArtistSongTotalVotes> GetTopMostVotedArtist( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.OrderBy = " Total DESC ";

            if( !String.IsNullOrEmpty(_orderBy) )
            {
                query.OrderBy = _orderBy;
            }

            query.Page = page;
            query.RowCount = rowCount;
            _repository.Find(query);

            this.Total = _repository.Count(query);

            _collection = _repository.Collection;

            return _collection;
        }

        #endregion IList<IViewAlbumArtistSongTotalVotes> GetTopMostVotedArtist( int page = 0 , int rowCount = 0 )

        #region IList<IViewAlbumArtistSongTotalVotes> GetMostVotesToday( int page = 0 , int rowCount = 0 )

        public IList<IViewAlbumArtistSongTotalVotes> GetMostVotesToday( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(" (battlDate BETWEEN '{0}' AND '{1} 23:59:59')", DateTime.Now.ToString("yyyy/MM/dd"), DateTime.Now.ToString("yyyy/MM/dd"));

            query.From = "ViewTopSongs";
            query.Where = builder.ToString();
            if (!String.IsNullOrEmpty(_orderBy))
            {
                query.OrderBy = _orderBy;
            }

            query.Page = page;
            query.RowCount = rowCount;

            IList<IViewAlbumArtistSongTotalVotes> result = result = _repository.Find(query);

            query.From = "ViewTopSongs";
            this.Total = _repository.Count(query);

            _collection = result;

            return result;
        }

        #endregion IList<IViewAlbumArtistSongTotalVotes> GetMostVotesToday( int page = 0 , int rowCount = 0 )

        #region IList<IViewAlbumArtistSongTotalVotes> GetMostVotedThisWeek( int page = 0 , int rowCount = 0  )

        public IList<IViewAlbumArtistSongTotalVotes> GetMostVotedThisWeek( int page = 0 , int rowCount = 0 )
        {
            DateTime firstWeekDay;
            DateTime lastWeekDay;

            DateUtils.GetWeek(DateTime.Now , new CultureInfo("pt-BR") , out firstWeekDay , out lastWeekDay);

            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(" (battlDate BETWEEN '{0}' AND '{1} 23:59:59')", firstWeekDay.ToString("yyyy-MM-dd"), lastWeekDay.ToString("yyyy-MM-dd"));

            IDataQuery query = new DataQuery();
            query.From = "ViewTopSongs";
            query.Where = builder.ToString();            
            if (!String.IsNullOrEmpty(_orderBy))
            {
                query.OrderBy = _orderBy;
            }

            query.Page = page;
            query.RowCount = rowCount;

            IList<IViewAlbumArtistSongTotalVotes> result = result = _repository.Find(query);

            query.From = "ViewTopSongs";
            this.Total = _repository.Count(query);

            _collection = result;

            return result;
        }

        #endregion IList<IViewAlbumArtistSongTotalVotes> GetMostVotedThisWeek( int page = 0 , int rowCount = 0  )

        #region IList<IViewAlbumArtistSongTotalVotes> GetMostVotedThisMonth( int page = 0 , int rowCount = 0  )

        public IList<IViewAlbumArtistSongTotalVotes> GetMostVotedThisMonth( int page = 0 , int rowCount = 0 )
        {
            DateTime firstDayOfTheMonth;
            DateTime lastDayOfTheMonth;

            DateUtils.GetMonth(DateTime.Now , new CultureInfo("pt-BR") , out firstDayOfTheMonth , out lastDayOfTheMonth);

            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(" (battlDate BETWEEN '{0}' AND '{1} 23:59:59')",firstDayOfTheMonth.ToString("yyyy-MM-dd"), lastDayOfTheMonth.ToString("yyyy-MM-dd"));

            IDataQuery query = new DataQuery();
            query.From = "ViewTopSongs";
            query.Where = builder.ToString();
            if( !String.IsNullOrEmpty(_orderBy) )
            {
                query.OrderBy = _orderBy;
            }

            query.Page = page;
            query.RowCount = rowCount;

            IList<IViewAlbumArtistSongTotalVotes> result = _repository.Find(query);

            query.From = "ViewTopSongs";
            this.Total = _repository.Count(query);

            _collection = result;

            return result;
        }

        #endregion IList<IViewAlbumArtistSongTotalVotes> GetMostVotedThisMonth( int page = 0 , int rowCount = 0  )
    }
}