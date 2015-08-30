using MusicBattlDAL.interfaces;
using MusicBattlDAL.repositories.interfaces;

namespace MusicBattlDAL.concrete
{
    public class BattlQueryParams : IBattlQueryParams , IDataQuery
    {
        #region IBattlQueryParams Members

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

        #endregion IBattlQueryParams Members

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