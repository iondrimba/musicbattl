using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewUserTotalVotesRepositoryBLL : IRepositoryBLL<IViewUserTotalVotes>
    {
        private IRepository<IViewUserTotalVotes> _repositorieDAL;

        #region Constructor

        public ViewUserTotalVotesRepositoryBLL( IRepository<IViewUserTotalVotes> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewUserTotalVotes> Members

        #region IViewUserTotalVotes GetById( int id )

        public IViewUserTotalVotes GetById( int id )
        {
            IViewUserTotalVotes entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewUserTotalVotes GetById( int id )

        #region IList<IViewUserTotalVotes> GetTop( int top, IDataQuery query )

        public IList<IViewUserTotalVotes> GetTop( int top , IDataQuery query )
        {
            IList<IViewUserTotalVotes> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewUserTotalVotes> GetTop( int top, IDataQuery query )

        #region IList<IViewUserTotalVotes> Find( IDataQuery query )

        public IList<IViewUserTotalVotes> Find( IDataQuery query )
        {
            IList<IViewUserTotalVotes> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewUserTotalVotes> Find( IDataQuery query )

        #region Count<Q>( Q query )

        public int Count<Q>( Q query )
        {
            int count = _repositorieDAL.Count(query);

            return count;
        }

        #endregion Count<Q>( Q query )

        #region Sum<Q>( Q query )

        public decimal Sum<Q>( Q query )
        {
            throw new NotImplementedException();
        }

        #endregion Sum<Q>( Q query )

        #region Add( IViewUserTotalVotes pEntity )

        public IViewUserTotalVotes Add( IViewUserTotalVotes pEntity )
        {
            IViewUserTotalVotes entity = pEntity;

            try
            {
                Validate(entity);
                entity = _repositorieDAL.Add(pEntity);
            }
            catch( Exception )
            {
                throw;
            }

            return entity;
        }

        #endregion Add( IViewUserTotalVotes pEntity )

        #region IViewUserTotalVotes Update( IViewUserTotalVotes pEntity )

        public IViewUserTotalVotes Update( IViewUserTotalVotes pEntity )
        {
            IViewUserTotalVotes entity = pEntity;

            try
            {
                Validate(entity);
                entity = _repositorieDAL.Update(pEntity);
            }
            catch( Exception )
            {
                throw;
            }

            return entity;
        }

        #endregion IViewUserTotalVotes Update( IViewUserTotalVotes pEntity )

        #region IList<IViewUserTotalVotes> Collection

        public IList<IViewUserTotalVotes> Collection
        {
            get { return (IList<IViewUserTotalVotes>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewUserTotalVotes> Collection

        #region IRepository<IViewUserTotalVotes> repositorieDAL

        public IRepository<IViewUserTotalVotes> repositorieDAL
        {
            get
            {
                return _repositorieDAL;
            }
            set
            {
                _repositorieDAL = value;
            }
        }

        #endregion IRepository<IViewUserTotalVotes> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewUserTotalVotes entity )

        public void Validate( IViewUserTotalVotes entity )
        {
            //TODO
        }

        #endregion Validate( IViewUserTotalVotes entity )

        #endregion IRepositoryBLL<IViewUserTotalVotes> Members
    }
}