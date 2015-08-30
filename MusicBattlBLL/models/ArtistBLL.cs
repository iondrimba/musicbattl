using System.Collections.Generic;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ArtistBLL : IArtistBLL
    {
        private IRepositoryBLL<IArtist> _artistRepository;
        private IDataBaseAccess _dataBaseAccess;

        public ArtistBLL( IRepositoryBLL<IArtist> artistRepository )
        {
            _artistRepository = artistRepository;
            _dataBaseAccess = _artistRepository.repositorieDAL.DataBaseAccess;
        }

        #region IArtistBLL Members

        #region IArtist GetRandomArtist( int idArtist )

        public IArtist GetRandomArtist( int idArtist )
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format("artistId <> {0}" , idArtist);
            query.OrderBy = " NEWID() ";
            IArtist artist = _artistRepository.GetTop(1 , query)[0];

            return artist;
        }

        #endregion IArtist GetRandomArtist( int idArtist )

        #region IList<IArtist> GetTopArtistVoted( int count )

        public IList<IArtist> GetTopArtistVoted( int count )
        {
            IList<IArtist> collection = new List<IArtist>();

            IDataQuery query = new DataQuery();
            collection = _artistRepository.Find(query);

            return collection;
        }

        #endregion IList<IArtist> GetTopArtistVoted( int count )

        #endregion IArtistBLL Members
    }
}