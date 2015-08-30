using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewGenderTotalRepositoryBLL : IRepositoryBLL<IViewGenderTotal>
    {
        private IRepository<IViewGenderTotal> _repositorieDAL;

        #region Constructor

        public ViewGenderTotalRepositoryBLL( IRepository<IViewGenderTotal> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewGenderTotal> Members

        #region IViewGenderTotal GetById( int id )

        public IViewGenderTotal GetById( int id )
        {
            IViewGenderTotal entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewGenderTotal GetById( int id )

        #region IList<IViewGenderTotal> GetTop( int top, IDataQuery query )

        public IList<IViewGenderTotal> GetTop( int top , IDataQuery query )
        {
            IList<IViewGenderTotal> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewGenderTotal> GetTop( int top, IDataQuery query )

        #region IList<IViewGenderTotal> Find( IDataQuery query )

        public IList<IViewGenderTotal> Find( IDataQuery query )
        {
            IList<IViewGenderTotal> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewGenderTotal> Find( IDataQuery query )

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

        #region Add( IViewGenderTotal pEntity )

        public IViewGenderTotal Add( IViewGenderTotal pEntity )
        {
            IViewGenderTotal entity = pEntity;

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

        #endregion Add( IViewGenderTotal pEntity )

        #region IViewGenderTotal Update( IViewGenderTotal pEntity )

        public IViewGenderTotal Update( IViewGenderTotal pEntity )
        {
            IViewGenderTotal entity = pEntity;

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

        #endregion IViewGenderTotal Update( IViewGenderTotal pEntity )

        #region IList<IViewGenderTotal> Collection

        public IList<IViewGenderTotal> Collection
        {
            get { return (IList<IViewGenderTotal>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewGenderTotal> Collection

        #region IRepository<IViewGenderTotal> repositorieDAL

        public IRepository<IViewGenderTotal> repositorieDAL
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

        #endregion IRepository<IViewGenderTotal> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewGenderTotal entity )

        public void Validate( IViewGenderTotal entity )
        {
            //TODO
        }

        #endregion Validate( IViewGenderTotal entity )

        #endregion IRepositoryBLL<IViewGenderTotal> Members
    }
}