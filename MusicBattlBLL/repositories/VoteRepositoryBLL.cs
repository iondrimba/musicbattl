using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class VoteRepositoryBLL : IRepositoryBLL<IVote>
    {
        private IRepository<IVote> _repositorieDAL;

        #region Constructor

        public VoteRepositoryBLL( IRepository<IVote> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IVote> Members

        #region IVote GetById( int id )

        public IVote GetById( int id )
        {
            IVote entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IVote GetById( int id )

        #region IList<IVote> GetTop( int top, IDataQuery query )

        public IList<IVote> GetTop( int top , IDataQuery query )
        {
            IList<IVote> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IVote> GetTop( int top, IDataQuery query )

        #region IList<IVote> Find( IDataQuery query )

        public IList<IVote> Find( IDataQuery query )
        {
            IList<IVote> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IVote> Find( IDataQuery query )

        #region Count<Q>( Q query )

        public int Count<Q>( Q query )
        {
            throw new NotImplementedException();
        }

        #endregion Count<Q>( Q query )

        #region Sum<Q>( Q query )

        public decimal Sum<Q>( Q query )
        {
            throw new NotImplementedException();
        }

        #endregion Sum<Q>( Q query )

        #region Add( IVote pEntity )

        public IVote Add( IVote pEntity )
        {
            IVote entity = pEntity;

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

        #endregion Add( IVote pEntity )

        #region IVote Update( IVote pEntity )

        public IVote Update( IVote pEntity )
        {
            IVote entity = pEntity;

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

        #endregion IVote Update( IVote pEntity )

        #region IList<IVote> Collection

        public IList<IVote> Collection
        {
            get { return (IList<IVote>)_repositorieDAL.Collection; }
        }

        #endregion IList<IVote> Collection

        #region IRepository<IVote> repositorieDAL

        public IRepository<IVote> repositorieDAL
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

        #endregion IRepository<IVote> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IVote entity )

        public void Validate( IVote entity )
        {
            //TODO
        }

        #endregion Validate( IVote entity )

        #endregion IRepositoryBLL<IVote> Members
    }
}