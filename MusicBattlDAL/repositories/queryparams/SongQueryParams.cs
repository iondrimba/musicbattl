using MusicBattlDAL.interfaces;
using MusicBattlDAL.repositories.interfaces;

namespace MusicBattlDAL.concrete
{
    public class SongQueryParams : ISongQueryParams , IDataQuery
    {
        #region ISongQueryParams Members

        private string _songId;

        public string SongId
        {
            get { return _songId; }
            set { _songId = value; }
        }

        private string _albumId;

        public string AlbumId
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

        private string _trackNumber;

        public string TrackNumber
        {
            get { return _trackNumber; }
            set { _trackNumber = value; }
        }

        #endregion ISongQueryParams Members

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