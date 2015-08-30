using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public class ViewAlbumArtistSongTotalVotesByArtistRepositoryBLL : IRepositoryBLL<IViewAlbumArtistSongTotalVotesByArtist>
    {
        private IRepository<IViewAlbumArtistSongTotalVotesByArtist> _repositorieDAL;

        #region Constructor

        public ViewAlbumArtistSongTotalVotesByArtistRepositoryBLL( IRepository<IViewAlbumArtistSongTotalVotesByArtist> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewAlbumArtistSongTotalVotesByArtist> Members

        #region IViewAlbumArtistSongTotalVotesByArtist GetById( int id )

        public IViewAlbumArtistSongTotalVotesByArtist GetById( int id )
        {
            IViewAlbumArtistSongTotalVotesByArtist entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewAlbumArtistSongTotalVotesByArtist GetById( int id )

        #region IList<IViewAlbumArtistSongTotalVotesByArtist> GetTop( int top, IDataQuery query )

        public IList<IViewAlbumArtistSongTotalVotesByArtist> GetTop( int top , IDataQuery query )
        {
            IList<IViewAlbumArtistSongTotalVotesByArtist> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewAlbumArtistSongTotalVotesByArtist> GetTop( int top, IDataQuery query )

        #region IList<IViewAlbumArtistSongTotalVotesByArtist> Find( IDataQuery query )

        public IList<IViewAlbumArtistSongTotalVotesByArtist> Find( IDataQuery query )
        {
            IList<IViewAlbumArtistSongTotalVotesByArtist> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewAlbumArtistSongTotalVotesByArtist> Find( IDataQuery query )

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

        #region Add( IViewAlbumArtistSongTotalVotesByArtist pEntity )

        public IViewAlbumArtistSongTotalVotesByArtist Add( IViewAlbumArtistSongTotalVotesByArtist pEntity )
        {
            IViewAlbumArtistSongTotalVotesByArtist entity = pEntity;

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

        #endregion Add( IViewAlbumArtistSongTotalVotesByArtist pEntity )

        #region IViewAlbumArtistSongTotalVotesByArtist Update( IViewAlbumArtistSongTotalVotesByArtist pEntity )

        public IViewAlbumArtistSongTotalVotesByArtist Update( IViewAlbumArtistSongTotalVotesByArtist pEntity )
        {
            IViewAlbumArtistSongTotalVotesByArtist entity = pEntity;

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

        #endregion IViewAlbumArtistSongTotalVotesByArtist Update( IViewAlbumArtistSongTotalVotesByArtist pEntity )

        #region IList<IViewAlbumArtistSongTotalVotesByArtist> Collection

        public IList<IViewAlbumArtistSongTotalVotesByArtist> Collection
        {
            get { return (IList<IViewAlbumArtistSongTotalVotesByArtist>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewAlbumArtistSongTotalVotesByArtist> Collection

        #region IRepository<IViewAlbumArtistSongTotalVotesByArtist> repositorieDAL

        public IRepository<IViewAlbumArtistSongTotalVotesByArtist> repositorieDAL
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

        #endregion IRepository<IViewAlbumArtistSongTotalVotesByArtist> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewAlbumArtistSongTotalVotesByArtist entity )

        public void Validate( IViewAlbumArtistSongTotalVotesByArtist entity )
        {
            //TODO
        }

        #endregion Validate( IViewAlbumArtistSongTotalVotesByArtist entity )

        #endregion IRepositoryBLL<IViewAlbumArtistSongTotalVotesByArtist> Members
    }
}