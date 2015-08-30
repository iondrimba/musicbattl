using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class TagRepositoryBLL : IRepositoryBLL<ITag>
    {
        private IRepository<ITag> _repositorieDAL;

        #region Constructor

        public TagRepositoryBLL( IRepository<ITag> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<ITag> Members

        #region ITag GetById( int id )

        public ITag GetById( int id )
        {
            ITag entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion ITag GetById( int id )

        #region IList<ITag> GetTop( int top, IDataQuery query )

        public IList<ITag> GetTop( int top , IDataQuery query )
        {
            IList<ITag> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<ITag> GetTop( int top, IDataQuery query )

        #region IList<ITag> Find( IDataQuery query )

        public IList<ITag> Find( IDataQuery query )
        {
            IList<ITag> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<ITag> Find( IDataQuery query )

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

        #region Add( ITag pEntity )

        public ITag Add( ITag pEntity )
        {
            ITag entity = pEntity;

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

        #endregion Add( ITag pEntity )

        #region ITag Update( ITag pEntity )

        public ITag Update( ITag pEntity )
        {
            ITag entity = pEntity;

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

        #endregion ITag Update( ITag pEntity )

        #region IList<ITag> Collection

        public IList<ITag> Collection
        {
            get { return (IList<ITag>)_repositorieDAL.Collection; }
        }

        #endregion IList<ITag> Collection

        #region IRepository<ITag> repositorieDAL

        public IRepository<ITag> repositorieDAL
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

        #endregion IRepository<ITag> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( ITag entity )

        public void Validate( ITag entity )
        {
            //TODO
        }

        #endregion Validate( ITag entity )

        #endregion IRepositoryBLL<ITag> Members
    }
}