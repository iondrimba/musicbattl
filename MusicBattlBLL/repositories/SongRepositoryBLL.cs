using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class SongRepositoryBLL : IRepositoryBLL<ISong>
    {
        private IRepository<ISong> _repositorieDAL;

        #region Constructor

        public SongRepositoryBLL( IRepository<ISong> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<ISong> Members

        #region ISong GetById( int id )

        public ISong GetById( int id )
        {
            ISong entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion ISong GetById( int id )

        #region IList<ISong> GetTop( int top, IDataQuery query )

        public IList<ISong> GetTop( int top , IDataQuery query )
        {
            IList<ISong> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<ISong> GetTop( int top, IDataQuery query )

        #region IList<ISong> Find( IDataQuery query )

        public IList<ISong> Find( IDataQuery query )
        {
            IList<ISong> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<ISong> Find( IDataQuery query )

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

        #region Add( ISong pEntity )

        public ISong Add( ISong pEntity )
        {
            ISong entity = pEntity;

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

        #endregion Add( ISong pEntity )

        #region ISong Update( ISong pEntity )

        public ISong Update( ISong pEntity )
        {
            ISong entity = pEntity;

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

        #endregion ISong Update( ISong pEntity )

        #region IList<ISong> Collection

        public IList<ISong> Collection
        {
            get { return (IList<ISong>)_repositorieDAL.Collection; }
        }

        #endregion IList<ISong> Collection

        #region IRepository<ISong> repositorieDAL

        public IRepository<ISong> repositorieDAL
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

        #endregion IRepository<ISong> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( ISong entity )

        public void Validate( ISong entity )
        {
            //TODO
        }

        #endregion Validate( ISong entity )

        #endregion IRepositoryBLL<ISong> Members
    }
}