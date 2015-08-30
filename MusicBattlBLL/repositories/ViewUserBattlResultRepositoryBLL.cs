using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewUserBattlResultRepositoryBLL : IRepositoryBLL<IViewUserBattlResult>
    {
        private IRepository<IViewUserBattlResult> _repositorieDAL;

        #region Constructor

        public ViewUserBattlResultRepositoryBLL( IRepository<IViewUserBattlResult> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewUserBattlResult> Members

        #region IViewUserBattlResult GetById( int id )

        public IViewUserBattlResult GetById( int id )
        {
            IViewUserBattlResult entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewUserBattlResult GetById( int id )

        #region IList<IViewUserBattlResult> GetTop( int top, IDataQuery query )

        public IList<IViewUserBattlResult> GetTop( int top , IDataQuery query )
        {
            IList<IViewUserBattlResult> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewUserBattlResult> GetTop( int top, IDataQuery query )

        #region IList<IViewUserBattlResult> Find( IDataQuery query )

        public IList<IViewUserBattlResult> Find( IDataQuery query )
        {
            IList<IViewUserBattlResult> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewUserBattlResult> Find( IDataQuery query )

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

        #region Add( IViewUserBattlResult pEntity )

        public IViewUserBattlResult Add( IViewUserBattlResult pEntity )
        {
            IViewUserBattlResult entity = pEntity;

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

        #endregion Add( IViewUserBattlResult pEntity )

        #region IViewUserBattlResult Update( IViewUserBattlResult pEntity )

        public IViewUserBattlResult Update( IViewUserBattlResult pEntity )
        {
            IViewUserBattlResult entity = pEntity;

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

        #endregion IViewUserBattlResult Update( IViewUserBattlResult pEntity )

        #region IList<IViewUserBattlResult> Collection

        public IList<IViewUserBattlResult> Collection
        {
            get { return (IList<IViewUserBattlResult>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewUserBattlResult> Collection

        #region IRepository<IViewUserBattlResult> repositorieDAL

        public IRepository<IViewUserBattlResult> repositorieDAL
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

        #endregion IRepository<IViewUserBattlResult> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewUserBattlResult entity )

        public void Validate( IViewUserBattlResult entity )
        {
            //TODO
        }

        #endregion Validate( IViewUserBattlResult entity )

        #endregion IRepositoryBLL<IViewUserBattlResult> Members
    }
}