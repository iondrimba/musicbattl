using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class AddressRepositoryBLL : IRepositoryBLL<IAddress>
    {
        private IRepository<IAddress> _repositorieDAL;

        #region Constructor

        public AddressRepositoryBLL( IRepository<IAddress> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IAddress> Members

        #region IAddress GetById( int id )

        public IAddress GetById( int id )
        {
            IAddress entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IAddress GetById( int id )

        #region IList<IAddress> GetTop( int top, IDataQuery query )

        public IList<IAddress> GetTop( int top , IDataQuery query )
        {
            IList<IAddress> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IAddress> GetTop( int top, IDataQuery query )

        #region IList<IAddress> Find( IDataQuery query )

        public IList<IAddress> Find( IDataQuery query )
        {
            IList<IAddress> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IAddress> Find( IDataQuery query )

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

        #region Add( IAddress pEntity )

        public IAddress Add( IAddress pEntity )
        {
            IAddress entity = pEntity;

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

        #endregion Add( IAddress pEntity )

        #region IAddress Update( IAddress pEntity )

        public IAddress Update( IAddress pEntity )
        {
            IAddress entity = pEntity;

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

        #endregion IAddress Update( IAddress pEntity )

        #region IList<IAddress> Collection

        public IList<IAddress> Collection
        {
            get { return (IList<IAddress>)_repositorieDAL.Collection; }
        }

        #endregion IList<IAddress> Collection

        #region IRepository<IAddress> repositorieDAL

        public IRepository<IAddress> repositorieDAL
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

        #endregion IRepository<IAddress> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IAddress entity )

        public void Validate( IAddress entity )
        {
            //TODO
        }

        #endregion Validate( IAddress entity )

        #endregion IRepositoryBLL<IAddress> Members
    }
}