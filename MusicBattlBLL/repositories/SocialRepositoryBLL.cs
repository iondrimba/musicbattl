using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class SocialRepositoryBLL : IRepositoryBLL<ISocial>
    {
        private IRepository<ISocial> _repositorieDAL;

        #region Constructor

        public SocialRepositoryBLL( IRepository<ISocial> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<ISocial> Members

        #region ISocial GetById( int id )

        public ISocial GetById( int id )
        {
            ISocial entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion ISocial GetById( int id )

        #region IList<ISocial> GetTop( int top, IDataQuery query )

        public IList<ISocial> GetTop( int top , IDataQuery query )
        {
            IList<ISocial> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<ISocial> GetTop( int top, IDataQuery query )

        #region IList<ISocial> Find( IDataQuery query )

        public IList<ISocial> Find( IDataQuery query )
        {
            IList<ISocial> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<ISocial> Find( IDataQuery query )

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

        #region Add( ISocial pEntity )

        public ISocial Add( ISocial pEntity )
        {
            ISocial entity = pEntity;

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

        #endregion Add( ISocial pEntity )

        #region ISocial Update( ISocial pEntity )

        public ISocial Update( ISocial pEntity )
        {
            ISocial entity = pEntity;

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

        #endregion ISocial Update( ISocial pEntity )

        #region IList<ISocial> Collection

        public IList<ISocial> Collection
        {
            get { return (IList<ISocial>)_repositorieDAL.Collection; }
        }

        #endregion IList<ISocial> Collection

        #region IRepository<ISocial> repositorieDAL

        public IRepository<ISocial> repositorieDAL
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

        #endregion IRepository<ISocial> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( ISocial entity )

        public void Validate( ISocial entity )
        {
            //TODO
        }

        #endregion Validate( ISocial entity )

        #endregion IRepositoryBLL<ISocial> Members
    }
}