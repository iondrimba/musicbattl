using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewUserBattlResult : IViewUserBattlResult
    {
        #region Properties

        private int _battlId;

        public int BattlId
        {
            get { return _battlId; }
            set { _battlId = value; }
        }

        private int _firstSongId;

        public int FirstSongId
        {
            get { return _firstSongId; }
            set { _firstSongId = value; }
        }

        private int _secondSongId;

        public int SecondSongId
        {
            get { return _secondSongId; }
            set { _secondSongId = value; }
        }

        private string _artistNameFirst;

        public string ArtistNameFirst
        {
            get { return _artistNameFirst; }
            set { _artistNameFirst = value; }
        }

        private string _artistNameSecond;

        public string ArtistNameSecond
        {
            get { return _artistNameSecond; }
            set { _artistNameSecond = value; }
        }

        private string _albumNameFirst;

        public string AlbumNameFirst
        {
            get { return _albumNameFirst; }
            set { _albumNameFirst = value; }
        }

        private string _albumNameSecond;

        public string AlbumNameSecond
        {
            get { return _albumNameSecond; }
            set { _albumNameSecond = value; }
        }

        private string _songNameFirst;

        public string SongNameFirst
        {
            get { return _songNameFirst; }
            set { _songNameFirst = value; }
        }


        private string _songNameSecond;

        public string SongNameSecond
        {
            get { return _songNameSecond; }
            set { _songNameSecond = value; }
        }

        private int? _totalFirst;

        public int? TotalFirst
        {
            get { return _totalFirst; }
            set { _totalFirst = value; }
        }

        private int? _totalSecond;

        public int? TotalSecond
        {
            get { return _totalSecond; }
            set { _totalSecond = value; }
        }

        private int _profileIdFirst;

        public int ProfileIdFirst
        {
            get { return _profileIdFirst; }
            set { _profileIdFirst = value; }
        }

        private int? _totalFirstSong;

        public int? TotalFirstSong
        {
            get { return _totalFirstSong; }
            set { _totalFirstSong = value; }
        }

        private string _nameFirst;

        public string NameFirst
        {
            get { return _nameFirst; }
            set { _nameFirst = value; }
        }

        private int _profileIdSecond;

        public int ProfileIdSecond
        {
            get { return _profileIdSecond; }
            set { _profileIdSecond = value; }
        }

        private int? _totalSecondSong;

        public int? TotalSecondSong
        {
            get { return _totalSecondSong; }
            set { _totalSecondSong = value; }
        }

        private string _nameSecond;

        public string NameSecond
        {
            get { return _nameSecond; }
            set { _nameSecond = value; }
        }

        private int? _artistIdFirst;

        public int? ArtistIdFirst
        {
            get { return _artistIdFirst; }
            set { _artistIdFirst = value; }
        }

        private int? _artistIdSecond;

        public int? ArtistIdSecond
        {
            get { return _artistIdSecond; }
            set { _artistIdSecond = value; }
        }

        private string _firstAlbumCover;

        public string FirstAlbumCover
        {
            get { return _firstAlbumCover; }
            set { _firstAlbumCover = value; }
        }

        private string _secondAlbumCover;

        public string SecondAlbumCover
        {
            get { return _secondAlbumCover; }
            set { _secondAlbumCover = value; }
        }

        private bool _active;

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        #endregion Properties

        #region Constructor

        public ViewUserBattlResult()
        {
        }

        #endregion Constructor
    }
}