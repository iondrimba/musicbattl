using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewBattlResults : IViewBattlResults
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

        private string _artistNameSecond;

        public string ArtistNameSecond
        {
            get { return _artistNameSecond; }
            set { _artistNameSecond = value; }
        }

        private string _artistNameFirst;

        public string ArtistNameFirst
        {
            get { return _artistNameFirst; }
            set { _artistNameFirst = value; }
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

        private int _profileId;

        public int ProfileId
        {
            get { return _profileId; }
            set { _profileId = value; }
        }

        private bool _active;

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        #endregion Properties

        #region Constructor

        public ViewBattlResults()
        {
        }

        #endregion Constructor
    }
}