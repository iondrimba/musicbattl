using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ActivityLogRepositoryBLL : IRepositoryBLL<IActivityLog>
    {
        private IRepository<IActivityLog> _repositorieDAL;

        #region Constructor

        public ActivityLogRepositoryBLL( IRepository<IActivityLog> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IActivityLog> Members

        #region IActivityLog GetById( int id )

        public IActivityLog GetById( int id )
        {
            IActivityLog entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IActivityLog GetById( int id )

        #region IList<IActivityLog> GetTop( int top, IDataQuery query )

        public IList<IActivityLog> GetTop( int top , IDataQuery query )
        {
            IList<IActivityLog> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IActivityLog> GetTop( int top, IDataQuery query )

        #region IList<IActivityLog> Find( IDataQuery query )

        public IList<IActivityLog> Find( IDataQuery query )
        {
            IList<IActivityLog> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IActivityLog> Find( IDataQuery query )

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

        #region Add( IActivityLog pEntity )

        public IActivityLog Add( IActivityLog pEntity )
        {
            IActivityLog entity = pEntity;

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

        #endregion Add( IActivityLog pEntity )

        #region IActivityLog Update( IActivityLog pEntity )

        public IActivityLog Update( IActivityLog pEntity )
        {
            IActivityLog entity = pEntity;

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

        #endregion IActivityLog Update( IActivityLog pEntity )

        #region IList<IActivityLog> Collection

        public IList<IActivityLog> Collection
        {
            get { return (IList<IActivityLog>)_repositorieDAL.Collection; }
        }

        #endregion IList<IActivityLog> Collection

        #region IRepository<IActivityLog> repositorieDAL

        public IRepository<IActivityLog> repositorieDAL
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

        #endregion IRepository<IActivityLog> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IActivityLog entity )

        public void Validate( IActivityLog entity )
        {
            //TODO
        }

        #endregion Validate( IActivityLog entity )

        #endregion IRepositoryBLL<IActivityLog> Members
    }
}