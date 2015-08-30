using Microsoft.Practices.EnterpriseLibrary.Data;
using MusicBattlBLL.interfaces;
using MusicBattlBLL.repositories;
using MusicBattlDAL;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using System;
using System.Collections.Generic;

namespace MusicBattlBLL.models
{
    [Serializable]
    public class LoadSongsViewModel : ILoadSongsViewModel
    {
        private Database _dataBase;

        public LoadSongsViewModel()
        {
            _artist = new Artist();
            _album = new Album();
            _discography = new Discography();
            _songs = new List<Song>();
            _artistContact = new ArtistContact();
        }

        public LoadSongsViewModel(Database IDataBaseAccess)
        {
            _dataBase = IDataBaseAccess;
        }

        public void Save()
        {
            Database db = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase();

            if (_artist.ArtistId == 0)
            {
                //ADD ARTIST
                IRepository<IArtist> artist = new ArtistRepository(db);
                IRepositoryBLL<IArtist> artistRepoBll = new ArtistRepositoryBLL(artist);
                _artist = artistRepoBll.Add(_artist);

                //ADD ARTIST CONTACT
                IRepository<IArtistContact> contact1 = new ArtistContactRepository(db);
                IRepositoryBLL<IArtistContact> contactBll = new ArtistContactRepositoryBLL(contact1);
                _artistContact.ArtistId = _artist.ArtistId;
                _artistContact = contactBll.Add(_artistContact);

                //ADD DISCOGRAPHY
                IRepository<IDiscography> disco = new DiscographyRepository(db);
                IRepositoryBLL<IDiscography> discoBll = new DiscographyRepositoryBLL(disco);
                _discography.ArtistId = _artist.ArtistId;
                _discography = discoBll.Add(_discography);
            }

            if (_album.AlbumId == 0)
            {
                //ADD ALBUM
                IRepository<IAlbum> album1 = new AlbumRepository(db);
                IRepositoryBLL<IAlbum> albumBll = new AlbumRepositoryBLL(album1);
                _album.ArtistId = _artist.ArtistId;
                _album = albumBll.Add(_album);
            }

            //ADD SONGS
            IRepository<ISong> song1 = new SongRepository(db);
            IRepositoryBLL<ISong> songBll = new SongRepositoryBLL(song1);
            foreach (Song item in _songs)
            {
                item.AlbumId = _album.AlbumId;
                songBll.Add(item);
            }
        }

        private IArtist _artist;

        public IArtist Artist
        {
            get
            {
                return _artist;
            }
            set
            {
                _artist = value;
            }
        }

        private IArtistContact _artistContact;

        public IArtistContact ArtistContact
        {
            get
            {
                return _artistContact;
            }
            set
            {
                _artistContact = value;
            }
        }

        private IDiscography _discography;

        public IDiscography Discography
        {
            get
            {
                return _discography;
            }
            set
            {
                _discography = value;
            }
        }

        private IList<Song> _songs;

        public IList<Song> Songs
        {
            get
            {
                return _songs;
            }
            set
            {
                _songs = value;
            }
        }

        private IAlbum _album;

        public IAlbum Album
        {
            get
            {
                return _album;
            }
            set
            {
                _album = value;
            }
        }
    }
}