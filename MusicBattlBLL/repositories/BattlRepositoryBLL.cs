using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class BattlRepositoryBLL : IRepositoryBLL<IBattl>
    {
        private IRepository<IBattl> _repositorieDAL;

        #region Constructor

        public BattlRepositoryBLL( IRepository<IBattl> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IBattl> Members

        #region IBattl GetById( int id )

        public IBattl GetById( int id )
        {
            IBattl entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IBattl GetById( int id )

        #region IList<IBattl> GetTop( int top, IDataQuery query )

        public IList<IBattl> GetTop( int top , IDataQuery query )
        {
            IList<IBattl> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IBattl> GetTop( int top, IDataQuery query )

        #region IList<IBattl> Find( IDataQuery query )

        public IList<IBattl> Find( IDataQuery query )
        {
            IList<IBattl> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IBattl> Find( IDataQuery query )

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

        #region Add( IBattl pEntity )

        public IBattl Add( IBattl pEntity )
        {
            IBattl entity = pEntity;

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

        #endregion Add( IBattl pEntity )

        #region IBattl Update( IBattl pEntity )

        public IBattl Update( IBattl pEntity )
        {
            IBattl entity = pEntity;

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

        #endregion IBattl Update( IBattl pEntity )

        #region IList<IBattl> Collection

        public IList<IBattl> Collection
        {
            get { return (IList<IBattl>)_repositorieDAL.Collection; }
        }

        #endregion IList<IBattl> Collection

        #region IRepository<IBattl> repositorieDAL

        public IRepository<IBattl> repositorieDAL
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

        #endregion IRepository<IBattl> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IBattl entity )

        public void Validate( IBattl entity )
        {
            //TODO
        }

        #endregion Validate( IBattl entity )

        #endregion IRepositoryBLL<IBattl> Members
    }
}