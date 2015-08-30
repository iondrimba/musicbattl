using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public partial class ViewTopAlbumsRepositoryBLL : IRepositoryBLL<IViewTopAlbums>
    {
        private IRepository<IViewTopAlbums> _repositorieDAL;

        #region Constructor

        public ViewTopAlbumsRepositoryBLL( IRepository<IViewTopAlbums> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewTopAlbums> Members

        #region IViewTopAlbums GetById( int id )

        public IViewTopAlbums GetById( int id )
        {
            IViewTopAlbums entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewTopAlbums GetById( int id )

        #region IList<IViewTopAlbums> GetTop( int top, IDataQuery query )

        public IList<IViewTopAlbums> GetTop( int top , IDataQuery query )
        {
            IList<IViewTopAlbums> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewTopAlbums> GetTop( int top, IDataQuery query )

        #region IList<IViewTopAlbums> Find( IDataQuery query )

        public IList<IViewTopAlbums> Find( IDataQuery query )
        {
            IList<IViewTopAlbums> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewTopAlbums> Find( IDataQuery query )

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

        #region Add( IViewTopAlbums pEntity )

        public IViewTopAlbums Add( IViewTopAlbums pEntity )
        {
            IViewTopAlbums entity = pEntity;

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

        #endregion Add( IViewTopAlbums pEntity )

        #region IViewTopAlbums Update( IViewTopAlbums pEntity )

        public IViewTopAlbums Update( IViewTopAlbums pEntity )
        {
            IViewTopAlbums entity = pEntity;

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

        #endregion IViewTopAlbums Update( IViewTopAlbums pEntity )

        #region IList<IViewTopAlbums> Collection

        public IList<IViewTopAlbums> Collection
        {
            get { return (IList<IViewTopAlbums>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewTopAlbums> Collection

        #region IRepository<IViewTopAlbums> repositorieDAL

        public IRepository<IViewTopAlbums> repositorieDAL
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

        #endregion IRepository<IViewTopAlbums> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewTopAlbums entity )

        public void Validate( IViewTopAlbums entity )
        {
            //TODO
        }

        #endregion Validate( IViewTopAlbums entity )

        #endregion IRepositoryBLL<IViewTopAlbums> Members
    }
}