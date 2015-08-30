using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewBattlRepositoryBLL : IRepositoryBLL<IViewBattl>
    {
        private IRepository<IViewBattl> _repositorieDAL;

        #region Constructor

        public ViewBattlRepositoryBLL( IRepository<IViewBattl> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewBattl> Members

        #region IViewBattl GetById( int id )

        public IViewBattl GetById( int id )
        {
            IViewBattl entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewBattl GetById( int id )

        #region IList<IViewBattl> GetTop( int top, IDataQuery query )

        public IList<IViewBattl> GetTop( int top , IDataQuery query )
        {
            IList<IViewBattl> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewBattl> GetTop( int top, IDataQuery query )

        #region IList<IViewBattl> Find( IDataQuery query )

        public IList<IViewBattl> Find( IDataQuery query )
        {
            IList<IViewBattl> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewBattl> Find( IDataQuery query )

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

        #region Add( IViewBattl pEntity )

        public IViewBattl Add( IViewBattl pEntity )
        {
            IViewBattl entity = pEntity;

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

        #endregion Add( IViewBattl pEntity )

        #region IViewBattl Update( IViewBattl pEntity )

        public IViewBattl Update( IViewBattl pEntity )
        {
            IViewBattl entity = pEntity;

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

        #endregion IViewBattl Update( IViewBattl pEntity )

        #region IList<IViewBattl> Collection

        public IList<IViewBattl> Collection
        {
            get { return (IList<IViewBattl>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewBattl> Collection

        #region IRepository<IViewBattl> repositorieDAL

        public IRepository<IViewBattl> repositorieDAL
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

        #endregion IRepository<IViewBattl> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewBattl entity )

        public void Validate( IViewBattl entity )
        {
            //TODO
        }

        #endregion Validate( IViewBattl entity )

        #endregion IRepositoryBLL<IViewBattl> Members
    }
}