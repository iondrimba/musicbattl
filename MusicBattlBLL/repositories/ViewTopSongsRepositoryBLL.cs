using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewTopSongsRepositoryBLL : IRepositoryBLL<IViewTopSongs>
    {
        private IRepository<IViewTopSongs> _repositorieDAL;

        #region Constructor

        public ViewTopSongsRepositoryBLL( IRepository<IViewTopSongs> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewTopSongs> Members

        #region IViewTopSongs GetById( int id )

        public IViewTopSongs GetById( int id )
        {
            IViewTopSongs entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewTopSongs GetById( int id )

        #region IList<IViewTopSongs> GetTop( int top, IDataQuery query )

        public IList<IViewTopSongs> GetTop( int top , IDataQuery query )
        {
            IList<IViewTopSongs> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewTopSongs> GetTop( int top, IDataQuery query )

        #region IList<IViewTopSongs> Find( IDataQuery query )

        public IList<IViewTopSongs> Find( IDataQuery query )
        {
            IList<IViewTopSongs> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewTopSongs> Find( IDataQuery query )

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

        #region Add( IViewTopSongs pEntity )

        public IViewTopSongs Add( IViewTopSongs pEntity )
        {
            IViewTopSongs entity = pEntity;

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

        #endregion Add( IViewTopSongs pEntity )

        #region IViewTopSongs Update( IViewTopSongs pEntity )

        public IViewTopSongs Update( IViewTopSongs pEntity )
        {
            IViewTopSongs entity = pEntity;

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

        #endregion IViewTopSongs Update( IViewTopSongs pEntity )

        #region IList<IViewTopSongs> Collection

        public IList<IViewTopSongs> Collection
        {
            get { return (IList<IViewTopSongs>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewTopSongs> Collection

        #region IRepository<IViewTopSongs> repositorieDAL

        public IRepository<IViewTopSongs> repositorieDAL
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

        #endregion IRepository<IViewTopSongs> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewTopSongs entity )

        public void Validate( IViewTopSongs entity )
        {
            //TODO
        }

        #endregion Validate( IViewTopSongs entity )

        #endregion IRepositoryBLL<IViewTopSongs> Members
    }
}