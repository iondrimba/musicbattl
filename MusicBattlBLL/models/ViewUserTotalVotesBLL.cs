using System.Collections.Generic;
using System.Linq;
using MusicBattlBLL.interfaces;
using MusicBattlDAL;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ViewUserTotalVotesBLL : IViewUserTotalVotesBLL
    {
        private IRepositoryBLL<IViewUserTotalVotes> _repository;
        private IDataBaseAccess _dataBaseAccess;
        private int _total = 0;

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private IList<IViewUserTotalVotes> _collection;

        public IList<IViewUserTotalVotes> Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }

        #region Constructor

        public ViewUserTotalVotesBLL( IRepositoryBLL<IViewUserTotalVotes> repository )
        {
            _repository = repository;
            _dataBaseAccess = _repository.repositorieDAL.DataBaseAccess;
        }

        #endregion Constructor

        #region IViewUserTotalVotesBLL Members

        #region IList<IViewUserTotalVotes> GetTopMostVotesByUser( int page = 0 , int rowCount = 0  )

        public IList<IViewUserTotalVotes> GetTopMostVotesByUser( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Page = page;
            query.RowCount = rowCount;

            IList<IViewUserTotalVotes> retorno = new List<IViewUserTotalVotes>();

            retorno = _repository.Find(query);

            query.From = "ViewUserTotalVotes";

            this.Total = _repository.Count(query);

            _collection = retorno;

            return retorno;
        }

        #endregion IList<IViewUserTotalVotes> GetTopMostVotesByUser( int page = 0 , int rowCount = 0  )

        #region IList<IViewUserTotalVotes> GetTopMostVotesSongsByUser( int page = 0 , int rowCount = 0  )

        public IList<IViewUserTotalVotes> GetTopMostVotesSongsByUser( int page = 0 , int rowCount = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Page = page;
            query.RowCount = rowCount;

            IList<IViewUserTotalVotes> retorno = new List<IViewUserTotalVotes>();

            retorno = _repository.Find(query);

            query.From = "ViewUserTotalVotes";
            this.Total = _repository.Count(query);

            var groupedResultBySongId = (from n in retorno
                                         group n by new { n.SongId , n.UsuarioId , n.Name , n.SongName , n.Picture } into g
                                         orderby g.Key.Name
                                         let r = g.FirstOrDefault()
                                         select new ViewUserTotalVotes
                                         {
                                             SongId = r.SongId ,
                                             SongName = r.SongName ,
                                             Name = r.Name ,
                                             UsuarioId = r.UsuarioId ,
                                             ProfileId = r.ProfileId ,
                                             Gender = r.Gender ,
                                             BattlId = r.BattlId ,
                                             Picture = r.Picture ,
                                             Total = g.Sum(m => m.Total).Value
                                         }).ToList<IViewUserTotalVotes>();

            IList<IViewUserTotalVotes> result = groupedResultBySongId.OrderByDescending(o => o.Total).ToList();

            _collection = result;

            return result;
        }

        #endregion IList<IViewUserTotalVotes> GetTopMostVotesSongsByUser( int page = 0 , int rowCount = 0  )

        #endregion IViewUserTotalVotesBLL Members
    }
}