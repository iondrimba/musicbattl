using MusicBattlDAL.models.interfaces;
using System;

namespace MusicBattlDAL
{
    [Serializable]
    public class Song : ISong
    {
        #region Properties

        private int _songId;

        public int SongId
        {
            get { return _songId; }
            set { _songId = value; }
        }

        private int _albumId;

        public int AlbumId
        {
            get { return _albumId; }
            set { _albumId = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _duration;

        public string Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        private string _soundCloudUrl;

        public string SoundCloudUrl
        {
            get { return _soundCloudUrl; }
            set { _soundCloudUrl = value; }
        }

        private int _trackNumber;

        public int TrackNumber
        {
            get { return _trackNumber; }
            set { _trackNumber = value; }
        }

        #endregion Properties

        #region Constructor

        public Song()
        {
        }

        #endregion Constructor
    }
}