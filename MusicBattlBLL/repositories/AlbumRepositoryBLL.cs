using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class AlbumRepositoryBLL : IRepositoryBLL<IAlbum>
    {
        private IRepository<IAlbum> _repositorieDAL;

        #region Constructor

        public AlbumRepositoryBLL( IRepository<IAlbum> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IAlbum> Members

        #region IAlbum GetById( int id )

        public IAlbum GetById( int id )
        {
            IAlbum entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IAlbum GetById( int id )

        #region IList<IAlbum> GetTop( int top, IDataQuery query )

        public IList<IAlbum> GetTop( int top , IDataQuery query )
        {
            IList<IAlbum> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IAlbum> GetTop( int top, IDataQuery query )

        #region IList<IAlbum> Find( IDataQuery query )

        public IList<IAlbum> Find( IDataQuery query )
        {
            IList<IAlbum> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IAlbum> Find( IDataQuery query )

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

        #region Add( IAlbum pEntity )

        public IAlbum Add( IAlbum pEntity )
        {
            IAlbum entity = pEntity;

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

        #endregion Add( IAlbum pEntity )

        #region IAlbum Update( IAlbum pEntity )

        public IAlbum Update( IAlbum pEntity )
        {
            IAlbum entity = pEntity;

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

        #endregion IAlbum Update( IAlbum pEntity )

        #region IList<IAlbum> Collection

        public IList<IAlbum> Collection
        {
            get { return (IList<IAlbum>)_repositorieDAL.Collection; }
        }

        #endregion IList<IAlbum> Collection

        #region IRepository<IAlbum> repositorieDAL

        public IRepository<IAlbum> repositorieDAL
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

        #endregion IRepository<IAlbum> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IAlbum entity )

        public void Validate( IAlbum entity )
        {
            //TODO
        }

        #endregion Validate( IAlbum entity )

        #endregion IRepositoryBLL<IAlbum> Members
    }
}