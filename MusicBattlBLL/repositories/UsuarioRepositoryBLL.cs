using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class UsuarioRepositoryBLL : IRepositoryBLL<IUsuario>
    {
        private IRepository<IUsuario> _repositorieDAL;

        #region Constructor

        public UsuarioRepositoryBLL( IRepository<IUsuario> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IUsuario> Members

        #region IUsuario GetById( int id )

        public IUsuario GetById( int id )
        {
            IUsuario entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IUsuario GetById( int id )

        #region IList<IUsuario> GetTop( int top, IDataQuery query )

        public IList<IUsuario> GetTop( int top , IDataQuery query )
        {
            IList<IUsuario> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IUsuario> GetTop( int top, IDataQuery query )

        #region IList<IUsuario> Find( IDataQuery query )

        public IList<IUsuario> Find( IDataQuery query )
        {
            IList<IUsuario> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IUsuario> Find( IDataQuery query )

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

        #region Add( IUsuario pEntity )

        public IUsuario Add( IUsuario pEntity )
        {
            IUsuario entity = pEntity;

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

        #endregion Add( IUsuario pEntity )

        #region IUsuario Update( IUsuario pEntity )

        public IUsuario Update( IUsuario pEntity )
        {
            IUsuario entity = pEntity;

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

        #endregion IUsuario Update( IUsuario pEntity )

        #region IList<IUsuario> Collection

        public IList<IUsuario> Collection
        {
            get { return (IList<IUsuario>)_repositorieDAL.Collection; }
        }

        #endregion IList<IUsuario> Collection

        #region IRepository<IUsuario> repositorieDAL

        public IRepository<IUsuario> repositorieDAL
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

        #endregion IRepository<IUsuario> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IUsuario entity )

        public void Validate( IUsuario entity )
        {
            //TODO
        }

        #endregion Validate( IUsuario entity )

        #endregion IRepositoryBLL<IUsuario> Members
    }
}