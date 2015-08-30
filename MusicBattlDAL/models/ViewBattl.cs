using System;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewBattl : IViewBattl
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

        private int _firstArtistId;

        public int FirstArtistId
        {
            get { return _firstArtistId; }
            set { _firstArtistId = value; }
        }

        private int _secondtArtistId;

        public int SecondArtistId
        {
            get { return _secondtArtistId; }
            set { _secondtArtistId = value; }
        }

        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private DateTime _endTime;

        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        private DateTime _battlDate;

        public DateTime BattlDate
        {
            get { return _battlDate; }
            set { _battlDate = value; }
        }

        private string _firstAlbumCover;

        public string FirstAlbumCover
        {
            get { return _firstAlbumCover; }
            set { _firstAlbumCover = value; }
        }

        private string _firstSongName;

        public string FirstSongName
        {
            get { return _firstSongName; }
            set { _firstSongName = value; }
        }

        private string _firstSongUrl;

        public string FirstSongUrl
        {
            get { return _firstSongUrl; }
            set { _firstSongUrl = value; }
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

        private string _secondArtistName;

        public string SecondArtistName
        {
            get { return _secondArtistName; }
            set { _secondArtistName = value; }
        }

        private int _secondSongId;

        public int SecondSongId
        {
            get { return _secondSongId; }
            set { _secondSongId = value; }
        }

        private string _secondSongName;

        public string SecondSongName
        {
            get { return _secondSongName; }
            set { _secondSongName = value; }
        }

        private string _secondSongUrl;

        public string SecondSongUrl
        {
            get { return _secondSongUrl; }
            set { _secondSongUrl = value; }
        }

        private string _secondAlbumCover;

        public string SecondAlbumCover
        {
            get { return _secondAlbumCover; }
            set { _secondAlbumCover = value; }
        }

        private string _secondAlbumName;

        public string SecondAlbumName
        {
            get { return _secondAlbumName; }
            set { _secondAlbumName = value; }
        }

        private int _firstSongVotes;

        public int FirstSongVotes
        {
            get { return _firstSongVotes; }
            set { _firstSongVotes = value; }
        }

        private int _secondSongVotes;

        public int SecondSongVotes
        {
            get { return _secondSongVotes; }
            set { _secondSongVotes = value; }
        }

        private bool _active;

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        #endregion Properties

        #region Constructor

        public ViewBattl()
        {
        }

        #endregion Constructor
    }
}