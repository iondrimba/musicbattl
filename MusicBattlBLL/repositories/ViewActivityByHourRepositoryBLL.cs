using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewActivityByHourRepositoryBLL : IRepositoryBLL<IViewActivityByHour>
    {
        private IRepository<IViewActivityByHour> _repositorieDAL;

        #region Constructor

        public ViewActivityByHourRepositoryBLL( IRepository<IViewActivityByHour> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewActivityByHour> Members

        #region IViewActivityByHour GetById( int id )

        public IViewActivityByHour GetById( int id )
        {
            IViewActivityByHour entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewActivityByHour GetById( int id )

        #region IList<IViewActivityByHour> GetTop( int top, IDataQuery query )

        public IList<IViewActivityByHour> GetTop( int top , IDataQuery query )
        {
            IList<IViewActivityByHour> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewActivityByHour> GetTop( int top, IDataQuery query )

        #region IList<IViewActivityByHour> Find( IDataQuery query )

        public IList<IViewActivityByHour> Find( IDataQuery query )
        {
            IList<IViewActivityByHour> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewActivityByHour> Find( IDataQuery query )

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

        #region Add( IViewActivityByHour pEntity )

        public IViewActivityByHour Add( IViewActivityByHour pEntity )
        {
            IViewActivityByHour entity = pEntity;

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

        #endregion Add( IViewActivityByHour pEntity )

        #region IViewActivityByHour Update( IViewActivityByHour pEntity )

        public IViewActivityByHour Update( IViewActivityByHour pEntity )
        {
            IViewActivityByHour entity = pEntity;

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

        #endregion IViewActivityByHour Update( IViewActivityByHour pEntity )

        #region IList<IViewActivityByHour> Collection

        public IList<IViewActivityByHour> Collection
        {
            get { return (IList<IViewActivityByHour>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewActivityByHour> Collection

        #region IRepository<IViewActivityByHour> repositorieDAL

        public IRepository<IViewActivityByHour> repositorieDAL
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

        #endregion IRepository<IViewActivityByHour> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewActivityByHour entity )

        public void Validate( IViewActivityByHour entity )
        {
            //TODO
        }

        #endregion Validate( IViewActivityByHour entity )

        #endregion IRepositoryBLL<IViewActivityByHour> Members
    }
}