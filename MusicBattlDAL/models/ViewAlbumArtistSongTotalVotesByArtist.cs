using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewAlbumArtistSongTotalVotesByArtist : IViewAlbumArtistSongTotalVotesByArtist
    {
        #region Properties

        private int _artistId;

        public int ArtistId
        {
            get { return _artistId; }
            set { _artistId = value; }
        }

        private int? _total;

        public int? Total
        {
            get { return _total; }
            set { _total = value; }
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

        private string _picture;

        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        #endregion Properties

        #region Constructor

        public ViewAlbumArtistSongTotalVotesByArtist()
        {
        }

        #endregion Constructor
    }
}