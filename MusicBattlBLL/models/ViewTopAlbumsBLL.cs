using System;
using System.Collections.Generic;
using System.Globalization;
using MusicBattlBLL.interfaces;
using MusicBattlBLL.repositories;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ViewTopAlbumsBLL : IViewTopAlbumsBLL
    {
        private IRepositoryBLL<IViewTopAlbums> _repository;
        private IDataBaseAccess _dataBaseAccess;
        private int _total = 0;
        private IList<IViewTopAlbums> _collection;
        private string _orderBy = string.Empty;

        public string OrderBy
        {
            get { return _orderBy; }
            set { _orderBy = value; }
        }

        public IList<IViewTopAlbums> Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public ViewTopAlbumsBLL( IRepositoryBLL<IViewTopAlbums> repository )
        {
            _repository = repository;
            _dataBaseAccess = _repository.repositorieDAL.DataBaseAccess;
        }

        #region IViewTopAlbumsBLL Members

        public IList<IViewTopAlbums> GetMostVotedAlbumToday( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Page = page;
            query.RowCount = rowCount;
            query.Where = string.Format("(ViewTopAlbums.battlDate ='{0}')" , DateTime.Now.ToString("yyyy-MM-dd"));

            IList<IViewTopAlbums> retorno = GetData("viewTopAlbumsGroupedByDay" , query);

            return retorno;
        }

        public IList<IViewTopAlbums> GetMostVotedAlbumThisWeek( int page = 0 , int rowCount = 0 )
        {
            DateTime firstWeekDay;
            DateTime lastWeekDay;
            DateUtils.GetWeek(DateTime.Now , new CultureInfo("pt-BR") , out firstWeekDay , out lastWeekDay);
            IDataQuery query = new DataQuery();
            query.Page = page;
            query.RowCount = rowCount;
            query.Where = string.Format("(ViewTopAlbums.battlDate BETWEEN '{0}' AND '{1}')" , firstWeekDay.ToString("yyyy-MM-dd") , lastWeekDay.ToString("yyyy-MM-dd"));

            IList<IViewTopAlbums> retorno = GetData("viewTopAlbumsGroupedByAlbum" , query);

            return retorno;
        }

        public IList<IViewTopAlbums> GetMostVotedAlbumThisMonth( int page = 0 , int rowCount = 0 )
        {
            DateTime firstDayOfTheMonth;
            DateTime lastDayOfTheMonth;
            DateUtils.GetMonth(DateTime.Now , new CultureInfo("pt-BR") , out firstDayOfTheMonth , out lastDayOfTheMonth);
            IDataQuery query = new DataQuery();
            query.Page = page;
            query.RowCount = rowCount;
            query.Where = string.Format("(ViewTopAlbums.battlDate BETWEEN '{0}' AND '{1}')" , firstDayOfTheMonth.ToString("yyyy-MM-dd") , lastDayOfTheMonth.ToString("yyyy-MM-dd"));

            IList<IViewTopAlbums> retorno = GetData("viewTopAlbumsGroupedByAlbum" , query);

            return retorno;
        }

        #endregion IViewTopAlbumsBLL Members

        private IList<IViewTopAlbums> GetData( string procedureName , IDataQuery query )
        {
            IList<IViewTopAlbums> retorno = new List<IViewTopAlbums>();
            query.OrderBy = " ArtistName ";

            if( !String.IsNullOrEmpty(_orderBy) )
            {
                query.OrderBy = _orderBy;
            }

            retorno = ((ViewTopAlbumsRepositoryBLL)_repository).ExecuteProcedure(procedureName , query , query.RowCount);

            query.From = "ViewTopAlbums";
            this.Total = _repository.Count(query);

            _collection = retorno;

            return retorno;
        }
    }
}