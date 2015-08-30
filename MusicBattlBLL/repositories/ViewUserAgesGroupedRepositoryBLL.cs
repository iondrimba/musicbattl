using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewUserAgesRepositoryBLL : IRepositoryBLL<IViewUserAges>
    {
        private IRepository<IViewUserAges> _repositorieDAL;

        #region Constructor

        public ViewUserAgesRepositoryBLL( IRepository<IViewUserAges> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewUserAges> Members

        #region IViewUserAges GetById( int id )

        public IViewUserAges GetById( int id )
        {
            IViewUserAges entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewUserAges GetById( int id )

        #region IList<IViewUserAges> GetTop( int top, IDataQuery query )

        public IList<IViewUserAges> GetTop( int top , IDataQuery query )
        {
            IList<IViewUserAges> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewUserAges> GetTop( int top, IDataQuery query )

        #region IList<IViewUserAges> Find( IDataQuery query )

        public IList<IViewUserAges> Find( IDataQuery query )
        {
            IList<IViewUserAges> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewUserAges> Find( IDataQuery query )

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

        #region Add( IViewUserAges pEntity )

        public IViewUserAges Add( IViewUserAges pEntity )
        {
            IViewUserAges entity = pEntity;

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

        #endregion Add( IViewUserAges pEntity )

        #region IViewUserAges Update( IViewUserAges pEntity )

        public IViewUserAges Update( IViewUserAges pEntity )
        {
            IViewUserAges entity = pEntity;

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

        #endregion IViewUserAges Update( IViewUserAges pEntity )

        #region IList<IViewUserAges> Collection

        public IList<IViewUserAges> Collection
        {
            get { return (IList<IViewUserAges>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewUserAges> Collection

        #region IRepository<IViewUserAges> repositorieDAL

        public IRepository<IViewUserAges> repositorieDAL
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

        #endregion IRepository<IViewUserAges> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewUserAges entity )

        public void Validate( IViewUserAges entity )
        {
            //TODO
        }

        #endregion Validate( IViewUserAges entity )

        #endregion IRepositoryBLL<IViewUserAges> Members
    }
}