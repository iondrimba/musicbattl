using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewBattlResultsRepositoryBLL : IRepositoryBLL<IViewBattlResults>
    {
        private IRepository<IViewBattlResults> _repositorieDAL;

        #region Constructor

        public ViewBattlResultsRepositoryBLL( IRepository<IViewBattlResults> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewBattlResults> Members

        #region IViewBattlResults GetById( int id )

        public IViewBattlResults GetById( int id )
        {
            IViewBattlResults entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewBattlResults GetById( int id )

        #region IList<IViewBattlResults> GetTop( int top, IDataQuery query )

        public IList<IViewBattlResults> GetTop( int top , IDataQuery query )
        {
            IList<IViewBattlResults> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewBattlResults> GetTop( int top, IDataQuery query )

        #region IList<IViewBattlResults> Find( IDataQuery query )

        public IList<IViewBattlResults> Find( IDataQuery query )
        {
            IList<IViewBattlResults> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewBattlResults> Find( IDataQuery query )

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

        #region Add( IViewBattlResults pEntity )

        public IViewBattlResults Add( IViewBattlResults pEntity )
        {
            IViewBattlResults entity = pEntity;

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

        #endregion Add( IViewBattlResults pEntity )

        #region IViewBattlResults Update( IViewBattlResults pEntity )

        public IViewBattlResults Update( IViewBattlResults pEntity )
        {
            IViewBattlResults entity = pEntity;

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

        #endregion IViewBattlResults Update( IViewBattlResults pEntity )

        #region IList<IViewBattlResults> Collection

        public IList<IViewBattlResults> Collection
        {
            get { return (IList<IViewBattlResults>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewBattlResults> Collection

        #region IRepository<IViewBattlResults> repositorieDAL

        public IRepository<IViewBattlResults> repositorieDAL
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

        #endregion IRepository<IViewBattlResults> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewBattlResults entity )

        public void Validate( IViewBattlResults entity )
        {
            //TODO
        }

        #endregion Validate( IViewBattlResults entity )

        #endregion IRepositoryBLL<IViewBattlResults> Members
    }
}