using System;
using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public partial class ViewAlbumArtistSongTotalVotesRepositoryBLL : IRepositoryBLL<IViewAlbumArtistSongTotalVotes>
    {
        private IRepository<IViewAlbumArtistSongTotalVotes> _repositorieDAL;

        #region Constructor

        public ViewAlbumArtistSongTotalVotesRepositoryBLL( IRepository<IViewAlbumArtistSongTotalVotes> repositorieDAL )
        {
            _repositorieDAL = repositorieDAL;
        }

        #endregion Constructor

        #region IRepositoryBLL<IViewAlbumArtistSongTotalVotes> Members

        #region IViewAlbumArtistSongTotalVotes GetById( int id )

        public IViewAlbumArtistSongTotalVotes GetById( int id )
        {
            IViewAlbumArtistSongTotalVotes entity = _repositorieDAL.GetById(id);

            return entity;
        }

        #endregion IViewAlbumArtistSongTotalVotes GetById( int id )

        #region IList<IViewAlbumArtistSongTotalVotes> GetTop( int top, IDataQuery query )

        public IList<IViewAlbumArtistSongTotalVotes> GetTop( int top , IDataQuery query )
        {
            IList<IViewAlbumArtistSongTotalVotes> collection = _repositorieDAL.GetTop(top , query);

            return collection;
        }

        #endregion IList<IViewAlbumArtistSongTotalVotes> GetTop( int top, IDataQuery query )

        #region IList<IViewAlbumArtistSongTotalVotes> Find( IDataQuery query )

        public IList<IViewAlbumArtistSongTotalVotes> Find( IDataQuery query )
        {
            IList<IViewAlbumArtistSongTotalVotes> collection = _repositorieDAL.Find(query);

            return collection;
        }

        #endregion IList<IViewAlbumArtistSongTotalVotes> Find( IDataQuery query )

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

        #region Add( IViewAlbumArtistSongTotalVotes pEntity )

        public IViewAlbumArtistSongTotalVotes Add( IViewAlbumArtistSongTotalVotes pEntity )
        {
            IViewAlbumArtistSongTotalVotes entity = pEntity;

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

        #endregion Add( IViewAlbumArtistSongTotalVotes pEntity )

        #region IViewAlbumArtistSongTotalVotes Update( IViewAlbumArtistSongTotalVotes pEntity )

        public IViewAlbumArtistSongTotalVotes Update( IViewAlbumArtistSongTotalVotes pEntity )
        {
            IViewAlbumArtistSongTotalVotes entity = pEntity;

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

        #endregion IViewAlbumArtistSongTotalVotes Update( IViewAlbumArtistSongTotalVotes pEntity )

        #region IList<IViewAlbumArtistSongTotalVotes> Collection

        public IList<IViewAlbumArtistSongTotalVotes> Collection
        {
            get { return (IList<IViewAlbumArtistSongTotalVotes>)_repositorieDAL.Collection; }
        }

        #endregion IList<IViewAlbumArtistSongTotalVotes> Collection

        #region IRepository<IViewAlbumArtistSongTotalVotes> repositorieDAL

        public IRepository<IViewAlbumArtistSongTotalVotes> repositorieDAL
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

        #endregion IRepository<IViewAlbumArtistSongTotalVotes> repositorieDAL

        #region bool Remove( int id )

        public bool Remove( int id )
        {
            bool retorno = _repositorieDAL.Remove(id);

            return retorno;
        }

        #endregion bool Remove( int id )

        #region Validate( IViewAlbumArtistSongTotalVotes entity )

        public void Validate( IViewAlbumArtistSongTotalVotes entity )
        {
            //TODO
        }

        #endregion Validate( IViewAlbumArtistSongTotalVotes entity )

        #endregion IRepositoryBLL<IViewAlbumArtistSongTotalVotes> Members
    }
}