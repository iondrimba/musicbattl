using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewArtistsRepositoryBLL : IRepositoryBLL<IViewArtists>
    {
        private IRepository<IViewArtists> _repositorieDAL;

        #region Constructor

        public ViewArtistsRepositoryBLL( IRepository<IViewArtists> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewArtists> Members

        #region IViewArtists GetById( int id )

        public IViewArtists GetById( int id )
        {
            IViewArtists entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewArtists GetById( int id )

        #region IList<IViewArtists> GetTop( int top, IDataQuery query )

        public IList<IViewArtists> GetTop( int top , IDataQuery query )
        {
            IList<IViewArtists> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewArtists> GetTop( int top, IDataQuery query )

        #region IList<IViewArtists> Find( IDataQuery query )

        public IList<IViewArtists> Find( IDataQuery query )
        {
            IList<IViewArtists> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewArtists> Find( IDataQuery query )

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

        #region Add( IViewArtists pEntity )

        public IViewArtists Add( IViewArtists pEntity )
        {
            IViewArtists entity = pEntity;

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

        #endregion Add( IViewArtists pEntity )

        #region IViewArtists Update( IViewArtists pEntity )

        public IViewArtists Update( IViewArtists pEntity )
        {
            IViewArtists entity = pEntity;

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

        #endregion IViewArtists Update( IViewArtists pEntity )

        #region IList<IViewArtists> Collection

        public IList<IViewArtists> Collection
        {
            get { return (IList<IViewArtists>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewArtists> Collection

        #region IRepository<IViewArtists> repositorieDAL

        public IRepository<IViewArtists> repositorieDAL
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

        #endregion IRepository<IViewArtists> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewArtists entity )

        public void Validate( IViewArtists entity )
        {
            //TODO
        }

        #endregion Validate( IViewArtists entity )

        #endregion IRepositoryBLL<IViewArtists> Members
    }
}