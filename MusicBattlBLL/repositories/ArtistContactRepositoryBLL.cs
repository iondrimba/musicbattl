using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using System;
using System.Collections.Generic;

namespace MusicBattlBLL.repositories
{
    public class ArtistContactRepositoryBLL : IRepositoryBLL<IArtistContact>
    {
        private IRepository<IArtistContact> _repositorieDAL;

        #region Constructor

        public ArtistContactRepositoryBLL(IRepository<IArtistContact> repositorieDAL)
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IArtist> Members

        #region IArtist GetById( int id )

        public IArtistContact GetById(int id)
        {
            IArtistContact entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IArtist GetById( int id )

        #region IList<IArtist> GetTop( int top, IDataQuery query )

        public IList<IArtistContact> GetTop(int top, IDataQuery query)
        {
            IList<IArtistContact> collection = _repositorieDAL.GetTop(top, query);

            return collection;
        }

        #endregion IList<IArtist> GetTop( int top, IDataQuery query )

        #region IList<IArtist> Find( IDataQuery query )

        public IList<IArtistContact> Find(IDataQuery query)
        {
            IList<IArtistContact> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IArtist> Find( IDataQuery query )

        #region Count<Q>( Q query )

        public int Count<Q>(Q query)
        {
            throw new NotImplementedException();
        }

        #endregion Count<Q>( Q query )

        #region Sum<Q>( Q query )

        public decimal Sum<Q>(Q query)
        {
            throw new NotImplementedException();
        }

        #endregion Sum<Q>( Q query )

        #region Add( IArtist pEntity )

        public IArtistContact Add(IArtistContact pEntity)
        {
            IArtistContact entity = pEntity;

            try
            {
                Validate(entity);
                entity = _repositorieDAL.Add(pEntity);
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        #endregion Add( IArtist pEntity )

        #region IArtist Update( IArtist pEntity )

        public IArtistContact Update(IArtistContact pEntity)
        {
            IArtistContact entity = pEntity;

            try
            {
                Validate(entity);
                entity = _repositorieDAL.Update(pEntity);
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        #endregion IArtist Update( IArtist pEntity )

        #region IList<IArtist> Collection

        public IList<IArtistContact> Collection
        {
            get { return (IList<IArtistContact>)_repositorieDAL.Collection; }
        }

        #endregion IList<IArtist> Collection

        #region IRepository<IArtist> repositorieDAL

        public IRepository<IArtistContact> repositorieDAL
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

        public bool Remove(int id)
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IArtist entity )

        public void Validate(IArtistContact entity)
        {
            //TODO
        }

        #endregion Validate( IArtist entity )

        #endregion IRepositoryBLL<IArtist> Members
    }
}