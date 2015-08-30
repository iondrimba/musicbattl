using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ActionRepositoryBLL : IRepositoryBLL<IAction>
    {
        private IRepository<IAction> _repositorieDAL;

        #region Constructor

        public ActionRepositoryBLL( IRepository<IAction> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IAction> Members

        #region IAction GetById( int id )

        public IAction GetById( int id )
        {
            IAction entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IAction GetById( int id )

        #region IList<IAction> GetTop( int top, IDataQuery query )

        public IList<IAction> GetTop( int top , IDataQuery query )
        {
            IList<IAction> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IAction> GetTop( int top, IDataQuery query )

        #region IList<IAction> Find( IDataQuery query )

        public IList<IAction> Find( IDataQuery query )
        {
            IList<IAction> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IAction> Find( IDataQuery query )

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

        #region Add( IAction pEntity )

        public IAction Add( IAction pEntity )
        {
            IAction entity = pEntity;

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

        #endregion Add( IAction pEntity )

        #region IAction Update( IAction pEntity )

        public IAction Update( IAction pEntity )
        {
            IAction entity = pEntity;

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

        #endregion IAction Update( IAction pEntity )

        #region IList<IAction> Collection

        public IList<IAction> Collection
        {
            get { return (IList<IAction>)_repositorieDAL.Collection; }
        }

        #endregion IList<IAction> Collection

        #region IRepository<IAction> repositorieDAL

        public IRepository<IAction> repositorieDAL
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

        #endregion IRepository<IAction> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IAction entity )

        public void Validate( IAction entity )
        {
            //TODO
        }

        #endregion Validate( IAction entity )

        #endregion IRepositoryBLL<IAction> Members
    }
}