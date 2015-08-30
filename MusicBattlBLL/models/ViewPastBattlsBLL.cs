using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using System.Threading.Tasks;

namespace MusicBattlBLL.models
{
    public class ViewPastBattlsBLL : IViewPastBattlsBLL
    {
        #region Properties

        private IRepositoryBLL<IViewPastBattls> _repository;
        private IDataBaseAccess _dataBaseAccess;
        private int _total = 0;
        private IList<IViewPastBattls> _collection;

        public IList<IViewPastBattls> Collection
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

        public ViewPastBattlsBLL( IRepositoryBLL<IViewPastBattls> battlRepository )
        {
            _repository = battlRepository;
            _dataBaseAccess = _repository.repositorieDAL.DataBaseAccess;
        }

        #endregion Constructor

        #region IList<IViewPastBattls> GetPastBattls( int page = 0 , int rowCount = 0 )

        public IList<IViewPastBattls> GetPastBattls(int page = 0, int rowCount = 0)
        {
            IDataQuery query = new DataQuery();
            query.OrderBy = " battlId DESC ";
            query.Page = page;
            query.RowCount = rowCount;
            _repository.Find(query);

            query.From = "viewPastBattls";
            this.Total = _repository.Count(query);

            _collection = _repository.Collection;

            return _collection;
        }

        #endregion IList<IViewPastBattls> GetPastBattls( int page = 0 , int rowCount = 0 )

        #region IViewPastBattlsBLL Members

        public IViewPastBattls GetPastBattlsById( int id )
        {
            return _repository.GetById(id);
        }

        #endregion IViewPastBattlsBLL Members
    }
}