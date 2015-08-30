using System;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewTopAlbums : IViewTopAlbums
    {
        #region Properties

        private int _artistId;

        public int ArtistId
        {
            get { return _artistId; }
            set { _artistId = value; }
        }

        private int? _totalVotes;

        public int? TotalVotes
        {
            get { return _totalVotes; }
            set { _totalVotes = value; }
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

        private string _albumCover;

        public string AlbumCover
        {
            get { return _albumCover; }
            set { _albumCover = value; }
        }

        private DateTime _battlDate;

        public DateTime BattlDate
        {
            get { return _battlDate; }
            set { _battlDate = value; }
        }

        #endregion Properties

        #region Constructor

        public ViewTopAlbums()
        {
        }

        #endregion Constructor
    }
}