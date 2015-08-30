using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewUserFavoritesSongs : IViewUserFavoritesSongs
    {
        #region Properties

        private int _songId;

        public int SongId
        {
            get { return _songId; }
            set { _songId = value; }
        }

        private int _usuarioId;

        public int UsuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        private int _profileId;

        public int ProfileId
        {
            get { return _profileId; }
            set { _profileId = value; }
        }

        private int? _totalSong;

        public int? TotalSong
        {
            get { return _totalSong; }
            set { _totalSong = value; }
        }

        private int? _albumId;

        public int? AlbumId
        {
            get { return _albumId; }
            set { _albumId = value; }
        }

        private int? _artistId;

        public int? ArtistId
        {
            get { return _artistId; }
            set { _artistId = value; }
        }

        private string _albumCover;

        public string AlbumCover
        {
            get { return _albumCover; }
            set { _albumCover = value; }
        }

        private string _albumName;

        public string AlbumName
        {
            get { return _albumName; }
            set { _albumName = value; }
        }

        private string _artistName;

        public string ArtistName
        {
            get { return _artistName; }
            set { _artistName = value; }
        }

        private string _songName;

        public string SongName
        {
            get { return _songName; }
            set { _songName = value; }
        }

        #endregion Properties

        #region Constructor

        public ViewUserFavoritesSongs()
        {
        }

        #endregion Constructor
    }
}