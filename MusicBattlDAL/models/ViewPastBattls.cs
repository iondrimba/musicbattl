using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewPastBattls : IViewPastBattls
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

        private string _firstSoundCloudUrl;

        public string FirstSoundCloudUrl
        {
            get { return _firstSoundCloudUrl; }
            set { _firstSoundCloudUrl = value; }
        }

        private string _secondSoundCloudUrl;

        public string SecondSoundCloudUrl
        {
            get { return _secondSoundCloudUrl; }
            set { _secondSoundCloudUrl = value; }
        }

        private int _firstAlbumId;

        public int FirstAlbumId
        {
            get { return _firstAlbumId; }
            set { _firstAlbumId = value; }
        }

        private int? _totalSecond;

        public int? TotalSecond
        {
            get { return _totalSecond; }
            set { _totalSecond = value; }
        }

        private int? _totalFirst;

        public int? TotalFirst
        {
            get { return _totalFirst; }
            set { _totalFirst = value; }
        }

        private int _firstArtistId;

        public int FirstArtistId
        {
            get { return _firstArtistId; }
            set { _firstArtistId = value; }
        }

        private string _firstSongName;

        public string FirstSongName
        {
            get { return _firstSongName; }
            set { _firstSongName = value; }
        }

        private string _firstAlbumName;

        public string FirstAlbumName
        {
            get { return _firstAlbumName; }
            set { _firstAlbumName = value; }
        }

        private string _firstArtistName;

        public string FirstArtistName
        {
            get { return _firstArtistName; }
            set { _firstArtistName = value; }
        }

        private int _secondSongId;

        public int SecondSongId
        {
            get { return _secondSongId; }
            set { _secondSongId = value; }
        }

        private int _secondAlbumId;

        public int SecondAlbumId
        {
            get { return _secondAlbumId; }
            set { _secondAlbumId = value; }
        }

        private int _secondArtistId;

        public int SecondArtistId
        {
            get { return _secondArtistId; }
            set { _secondArtistId = value; }
        }

        private string _secondSongName;

        public string SecondSongName
        {
            get { return _secondSongName; }
            set { _secondSongName = value; }
        }

        private string _secondAlbumName;

        public string SecondAlbumName
        {
            get { return _secondAlbumName; }
            set { _secondAlbumName = value; }
        }

        private string _secondArtistName;

        public string SecondArtistName
        {
            get { return _secondArtistName; }
            set { _secondArtistName = value; }
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

        public ViewPastBattls()
        {
        }

        #endregion Constructor
    }
}