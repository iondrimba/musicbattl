using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewUserFavoritesSongsRepositoryBLL : IRepositoryBLL<IViewUserFavoritesSongs>
    {
        private IRepository<IViewUserFavoritesSongs> _repositorieDAL;

        #region Constructor

        public ViewUserFavoritesSongsRepositoryBLL( IRepository<IViewUserFavoritesSongs> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewUserFavoritesSongs> Members

        #region IViewUserFavoritesSongs GetById( int id )

        public IViewUserFavoritesSongs GetById( int id )
        {
            IViewUserFavoritesSongs entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewUserFavoritesSongs GetById( int id )

        #region IList<IViewUserFavoritesSongs> GetTop( int top, IDataQuery query )

        public IList<IViewUserFavoritesSongs> GetTop( int top , IDataQuery query )
        {
            IList<IViewUserFavoritesSongs> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewUserFavoritesSongs> GetTop( int top, IDataQuery query )

        #region IList<IViewUserFavoritesSongs> Find( IDataQuery query )

        public IList<IViewUserFavoritesSongs> Find( IDataQuery query )
        {
            IList<IViewUserFavoritesSongs> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewUserFavoritesSongs> Find( IDataQuery query )

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

        #region Add( IViewUserFavoritesSongs pEntity )

        public IViewUserFavoritesSongs Add( IViewUserFavoritesSongs pEntity )
        {
            IViewUserFavoritesSongs entity = pEntity;

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

        #endregion Add( IViewUserFavoritesSongs pEntity )

        #region IViewUserFavoritesSongs Update( IViewUserFavoritesSongs pEntity )

        public IViewUserFavoritesSongs Update( IViewUserFavoritesSongs pEntity )
        {
            IViewUserFavoritesSongs entity = pEntity;

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

        #endregion IViewUserFavoritesSongs Update( IViewUserFavoritesSongs pEntity )

        #region IList<IViewUserFavoritesSongs> Collection

        public IList<IViewUserFavoritesSongs> Collection
        {
            get { return (IList<IViewUserFavoritesSongs>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewUserFavoritesSongs> Collection

        #region IRepository<IViewUserFavoritesSongs> repositorieDAL

        public IRepository<IViewUserFavoritesSongs> repositorieDAL
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

        #endregion IRepository<IViewUserFavoritesSongs> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewUserFavoritesSongs entity )

        public void Validate( IViewUserFavoritesSongs entity )
        {
            //TODO
        }

        #endregion Validate( IViewUserFavoritesSongs entity )

        #endregion IRepositoryBLL<IViewUserFavoritesSongs> Members
    }
}