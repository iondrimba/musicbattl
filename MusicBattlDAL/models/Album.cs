using System;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    [Serializable]
    public class Album : IAlbum
    {
        #region Properties

        private int _albumId;

        public int AlbumId
        {
            get { return _albumId; }
            set { _albumId = value; }
        }

        private int _artistId;

        public int ArtistId
        {
            get { return _artistId; }
            set { _artistId = value; }
        }

        private DateTime? _year;

        public DateTime? Year
        {
            get { return _year; }
            set { _year = value; }
        }

        private string _albumCover;

        public string AlbumCover
        {
            get { return _albumCover; }
            set { _albumCover = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        #endregion Properties

        #region Constructor

        public Album()
        {
        }

        #endregion Constructor
    }
}