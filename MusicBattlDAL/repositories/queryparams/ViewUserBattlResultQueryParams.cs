using MusicBattlDAL.interfaces;
using MusicBattlDAL.repositories.interfaces;

namespace MusicBattlDAL.concrete
{
    public class ViewUserBattlResultQueryParams : IViewUserBattlResultQueryParams , IDataQuery
    {
        #region IViewUserBattlResultQueryParams Members

        private string _battlId;

        public string BattlId
        {
            get { return _battlId; }
            set { _battlId = value; }
        }

        private string _firstSongId;

        public string FirstSongId
        {
            get { return _firstSongId; }
            set { _firstSongId = value; }
        }

        private string _secondSongId;

        public string SecondSongId
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

        private string _totalFirst;

        public string TotalFirst
        {
            get { return _totalFirst; }
            set { _totalFirst = value; }
        }

        private string _totalSecond;

        public string TotalSecond
        {
            get { return _totalSecond; }
            set { _totalSecond = value; }
        }

        private string _profileIdFirst;

        public string ProfileIdFirst
        {
            get { return _profileIdFirst; }
            set { _profileIdFirst = value; }
        }

        private string _totalFirstSong;

        public string TotalFirstSong
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

        private string _profileIdSecond;

        public string ProfileIdSecond
        {
            get { return _profileIdSecond; }
            set { _profileIdSecond = value; }
        }

        private string _totalSecondSong;

        public string TotalSecondSong
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

        private string _artistIdFirst;

        public string ArtistIdFirst
        {
            get { return _artistIdFirst; }
            set { _artistIdFirst = value; }
        }

        private string _artistIdSecond;

        public string ArtistIdSecond
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

        #endregion IViewUserBattlResultQueryParams Members

        #region IDataQuery Members

        private string _column;
        private string _from;
        private string _where;
        private string _orderBy;
        private int _page = 0;

        public int Page
        {
            get { return _page; }
            set { _page = value; }
        }

        private int _rowCount = 0;

        public int RowCount
        {
            get { return _rowCount; }
            set { _rowCount = value; }
        }

        public string From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
            }
        }

        public string Where
        {
            get
            {
                return _where;
            }
            set
            {
                _where = value;
            }
        }

        public string OrderBy
        {
            get
            {
                return _orderBy;
            }
            set
            {
                _orderBy = value;
            }
        }

        public string Column
        {
            get
            {
                return _column;
            }
            set
            {
                _column = value;
            }
        }

        #endregion IDataQuery Members
    }
}