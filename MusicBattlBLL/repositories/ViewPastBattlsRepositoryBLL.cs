using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewPastBattlsRepositoryBLL : IRepositoryBLL<IViewPastBattls>
    {
        private IRepository<IViewPastBattls> _repositorieDAL;

        #region Constructor

        public ViewPastBattlsRepositoryBLL( IRepository<IViewPastBattls> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewPastBattls> Members

        #region IViewPastBattls GetById( int id )

        public IViewPastBattls GetById( int id )
        {
            IViewPastBattls entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewPastBattls GetById( int id )

        #region IList<IViewPastBattls> GetTop( int top, IDataQuery query )

        public IList<IViewPastBattls> GetTop( int top , IDataQuery query )
        {
            IList<IViewPastBattls> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewPastBattls> GetTop( int top, IDataQuery query )

        #region IList<IViewPastBattls> Find( IDataQuery query )

        public IList<IViewPastBattls> Find( IDataQuery query )
        {
            IList<IViewPastBattls> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewPastBattls> Find( IDataQuery query )

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

        #region Add( IViewPastBattls pEntity )

        public IViewPastBattls Add( IViewPastBattls pEntity )
        {
            IViewPastBattls entity = pEntity;

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

        #endregion Add( IViewPastBattls pEntity )

        #region IViewPastBattls Update( IViewPastBattls pEntity )

        public IViewPastBattls Update( IViewPastBattls pEntity )
        {
            IViewPastBattls entity = pEntity;

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

        #endregion IViewPastBattls Update( IViewPastBattls pEntity )

        #region IList<IViewPastBattls> Collection

        public IList<IViewPastBattls> Collection
        {
            get { return (IList<IViewPastBattls>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewPastBattls> Collection

        #region IRepository<IViewPastBattls> repositorieDAL

        public IRepository<IViewPastBattls> repositorieDAL
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

        #endregion IRepository<IViewPastBattls> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewPastBattls entity )

        public void Validate( IViewPastBattls entity )
        {
            //TODO
        }

        #endregion Validate( IViewPastBattls entity )

        #endregion IRepositoryBLL<IViewPastBattls> Members
    }
}