using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewArtistContactRepositoryBLL : IRepositoryBLL<IViewArtistContact>
    {
        private IRepository<IViewArtistContact> _repositorieDAL;

        #region Constructor

        public ViewArtistContactRepositoryBLL( IRepository<IViewArtistContact> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewArtistContact> Members

        #region IViewArtistContact GetById( int id )

        public IViewArtistContact GetById( int id )
        {
            IViewArtistContact entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewArtistContact GetById( int id )

        #region IList<IViewArtistContact> GetTop( int top, IDataQuery query )

        public IList<IViewArtistContact> GetTop( int top , IDataQuery query )
        {
            IList<IViewArtistContact> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewArtistContact> GetTop( int top, IDataQuery query )

        #region IList<IViewArtistContact> Find( IDataQuery query )

        public IList<IViewArtistContact> Find( IDataQuery query )
        {
            IList<IViewArtistContact> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewArtistContact> Find( IDataQuery query )

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

        #region Add( IViewArtistContact pEntity )

        public IViewArtistContact Add( IViewArtistContact pEntity )
        {
            IViewArtistContact entity = pEntity;

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

        #endregion Add( IViewArtistContact pEntity )

        #region IViewArtistContact Update( IViewArtistContact pEntity )

        public IViewArtistContact Update( IViewArtistContact pEntity )
        {
            IViewArtistContact entity = pEntity;

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

        #endregion IViewArtistContact Update( IViewArtistContact pEntity )

        #region IList<IViewArtistContact> Collection

        public IList<IViewArtistContact> Collection
        {
            get { return (IList<IViewArtistContact>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewArtistContact> Collection

        #region IRepository<IViewArtistContact> repositorieDAL

        public IRepository<IViewArtistContact> repositorieDAL
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

        #endregion IRepository<IViewArtistContact> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewArtistContact entity )

        public void Validate( IViewArtistContact entity )
        {
            //TODO
        }

        #endregion Validate( IViewArtistContact entity )

        #endregion IRepositoryBLL<IViewArtistContact> Members
    }
}