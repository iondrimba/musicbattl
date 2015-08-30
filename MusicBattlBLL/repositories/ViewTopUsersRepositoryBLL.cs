using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewTopUsersRepositoryBLL : IRepositoryBLL<IViewTopUsers>
    {
        private IRepository<IViewTopUsers> _repositorieDAL;

        #region Constructor

        public ViewTopUsersRepositoryBLL( IRepository<IViewTopUsers> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewTopUsers> Members

        #region IViewTopUsers GetById( int id )

        public IViewTopUsers GetById( int id )
        {
            IViewTopUsers entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewTopUsers GetById( int id )

        #region IList<IViewTopUsers> GetTop( int top, IDataQuery query )

        public IList<IViewTopUsers> GetTop( int top , IDataQuery query )
        {
            IList<IViewTopUsers> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewTopUsers> GetTop( int top, IDataQuery query )

        #region IList<IViewTopUsers> Find( IDataQuery query )

        public IList<IViewTopUsers> Find( IDataQuery query )
        {
            IList<IViewTopUsers> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewTopUsers> Find( IDataQuery query )

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

        #region Add( IViewTopUsers pEntity )

        public IViewTopUsers Add( IViewTopUsers pEntity )
        {
            IViewTopUsers entity = pEntity;

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

        #endregion Add( IViewTopUsers pEntity )

        #region IViewTopUsers Update( IViewTopUsers pEntity )

        public IViewTopUsers Update( IViewTopUsers pEntity )
        {
            IViewTopUsers entity = pEntity;

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

        #endregion IViewTopUsers Update( IViewTopUsers pEntity )

        #region IList<IViewTopUsers> Collection

        public IList<IViewTopUsers> Collection
        {
            get { return (IList<IViewTopUsers>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewTopUsers> Collection

        #region IRepository<IViewTopUsers> repositorieDAL

        public IRepository<IViewTopUsers> repositorieDAL
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

        #endregion IRepository<IViewTopUsers> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewTopUsers entity )

        public void Validate( IViewTopUsers entity )
        {
            //TODO
        }

        #endregion Validate( IViewTopUsers entity )

        #endregion IRepositoryBLL<IViewTopUsers> Members
    }
}