using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class DiscographyRepositoryBLL : IRepositoryBLL<IDiscography>
    {
        private IRepository<IDiscography> _repositorieDAL;

        #region Constructor

        public DiscographyRepositoryBLL( IRepository<IDiscography> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IDiscography> Members

        #region IDiscography GetById( int id )

        public IDiscography GetById( int id )
        {
            IDiscography entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IDiscography GetById( int id )

        #region IList<IDiscography> GetTop( int top, IDataQuery query )

        public IList<IDiscography> GetTop( int top , IDataQuery query )
        {
            IList<IDiscography> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IDiscography> GetTop( int top, IDataQuery query )

        #region IList<IDiscography> Find( IDataQuery query )

        public IList<IDiscography> Find( IDataQuery query )
        {
            IList<IDiscography> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IDiscography> Find( IDataQuery query )

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

        #region Add( IDiscography pEntity )

        public IDiscography Add( IDiscography pEntity )
        {
            IDiscography entity = pEntity;

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

        #endregion Add( IDiscography pEntity )

        #region IDiscography Update( IDiscography pEntity )

        public IDiscography Update( IDiscography pEntity )
        {
            IDiscography entity = pEntity;

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

        #endregion IDiscography Update( IDiscography pEntity )

        #region IList<IDiscography> Collection

        public IList<IDiscography> Collection
        {
            get { return (IList<IDiscography>)_repositorieDAL.Collection; }
        }

        #endregion IList<IDiscography> Collection

        #region IRepository<IDiscography> repositorieDAL

        public IRepository<IDiscography> repositorieDAL
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

        #endregion IRepository<IDiscography> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IDiscography entity )

        public void Validate( IDiscography entity )
        {
            //TODO
        }

        #endregion Validate( IDiscography entity )

        #endregion IRepositoryBLL<IDiscography> Members
    }
}