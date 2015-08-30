using MusicBattlDAL.interfaces;
using MusicBattlDAL.repositories.interfaces;

namespace MusicBattlDAL.concrete
{
    public class ViewBattlQueryParams : IViewBattlQueryParams , IDataQuery
    {
        #region IViewBattlQueryParams Members

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

        private string _firstArtistId;

        public string FirstArtistId
        {
            get { return _firstArtistId; }
            set { _firstArtistId = value; }
        }

        private string _secondArtistId;

        public string SecondArtistId
        {
            get { return _secondArtistId; }
            set { _secondArtistId = value; }
        }

        private string _secondArtistName;

        public string SecondArtistName
        {
            get { return _secondArtistName; }
            set { _secondArtistName = value; }
        }

        private string _firstArtistName;

        public string FirstArtistName
        {
            get { return _firstArtistName; }
            set { _firstArtistName = value; }
        }

        private string _startTime;

        public string StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private string _endTime;

        public string EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        private string _battlDate;

        public string BattlDate
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

        private string _firstAlbumName;

        public string FirstAlbumName
        {
            get { return _firstAlbumName; }
            set { _firstAlbumName = value; }
        }

        private string _secondSongId;

        public string SecondSongId
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

        private bool _active;

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        #endregion IViewBattlQueryParams Members

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