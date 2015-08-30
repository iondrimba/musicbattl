using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ArtistRepositoryBLL : IRepositoryBLL<IArtist>
    {
        private IRepository<IArtist> _repositorieDAL;

        #region Constructor

        public ArtistRepositoryBLL( IRepository<IArtist> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IArtist> Members

        #region IArtist GetById( int id )

        public IArtist GetById( int id )
        {
            IArtist entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IArtist GetById( int id )

        #region IList<IArtist> GetTop( int top, IDataQuery query )

        public IList<IArtist> GetTop( int top , IDataQuery query )
        {
            IList<IArtist> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IArtist> GetTop( int top, IDataQuery query )

        #region IList<IArtist> Find( IDataQuery query )

        public IList<IArtist> Find( IDataQuery query )
        {
            IList<IArtist> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IArtist> Find( IDataQuery query )

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

        #region Add( IArtist pEntity )

        public IArtist Add( IArtist pEntity )
        {
            IArtist entity = pEntity;

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

        #endregion Add( IArtist pEntity )

        #region IArtist Update( IArtist pEntity )

        public IArtist Update( IArtist pEntity )
        {
            IArtist entity = pEntity;

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

        #endregion IArtist Update( IArtist pEntity )

        #region IList<IArtist> Collection

        public IList<IArtist> Collection
        {
            get { return (IList<IArtist>)_repositorieDAL.Collection; }
        }

        #endregion IList<IArtist> Collection

        #region IRepository<IArtist> repositorieDAL

        public IRepository<IArtist> repositorieDAL
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

        #endregion IRepository<IArtist> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IArtist entity )

        public void Validate( IArtist entity )
        {
            //TODO
        }

        #endregion Validate( IArtist entity )

        #endregion IRepositoryBLL<IArtist> Members
    }
}