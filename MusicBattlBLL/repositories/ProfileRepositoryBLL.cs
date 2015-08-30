using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ProfileRepositoryBLL : IRepositoryBLL<IProfile>
    {
        private IRepository<IProfile> _repositorieDAL;

        #region Constructor

        public ProfileRepositoryBLL( IRepository<IProfile> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IProfile> Members

        #region IProfile GetById( int id )

        public IProfile GetById( int id )
        {
            IProfile entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IProfile GetById( int id )

        #region IList<IProfile> GetTop( int top, IDataQuery query )

        public IList<IProfile> GetTop( int top , IDataQuery query )
        {
            IList<IProfile> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IProfile> GetTop( int top, IDataQuery query )

        #region IList<IProfile> Find( IDataQuery query )

        public IList<IProfile> Find( IDataQuery query )
        {
            IList<IProfile> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IProfile> Find( IDataQuery query )

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

        #region Add( IProfile pEntity )

        public IProfile Add( IProfile pEntity )
        {
            IProfile entity = pEntity;

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

        #endregion Add( IProfile pEntity )

        #region IProfile Update( IProfile pEntity )

        public IProfile Update( IProfile pEntity )
        {
            IProfile entity = pEntity;

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

        #endregion IProfile Update( IProfile pEntity )

        #region IList<IProfile> Collection

        public IList<IProfile> Collection
        {
            get { return (IList<IProfile>)_repositorieDAL.Collection; }
        }

        #endregion IList<IProfile> Collection

        #region IRepository<IProfile> repositorieDAL

        public IRepository<IProfile> repositorieDAL
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

        #endregion IRepository<IProfile> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IProfile entity )

        public void Validate( IProfile entity )
        {
            //TODO
        }

        #endregion Validate( IProfile entity )

        #endregion IRepositoryBLL<IProfile> Members
    }
}