using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ViewArtistsBLL : IViewArtistsBLL
    {
        private IRepositoryBLL<IViewArtists> _repository;
        private IDataBaseAccess _dataBaseAccess;
        private int _total = 0;
        private IList<IViewArtists> _collection;

        public IList<IViewArtists> Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public ViewArtistsBLL( IRepositoryBLL<IViewArtists> repository )
        {
            _repository = repository;
            _dataBaseAccess = _repository.repositorieDAL.DataBaseAccess;
        }

        public IList<IViewArtists> GetArtists( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Page = page;
            query.RowCount = rowCount;

            IList<IViewArtists> retorno = _repository.Find(query);

            query.From = "viewArtists";
            this.Total = _repository.Count(query);

            _collection = retorno;

            return retorno;
        }
    }
}