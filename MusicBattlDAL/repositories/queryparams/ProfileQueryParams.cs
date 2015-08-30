using MusicBattlDAL.interfaces;
using MusicBattlDAL.repositories.interfaces;

namespace MusicBattlDAL.concrete
{
    public class ProfileQueryParams : IProfileQueryParams , IDataQuery
    {
        #region IProfileQueryParams Members

        private string _profileId;

        public string ProfileId
        {
            get { return _profileId; }
            set { _profileId = value; }
        }

        private string _userId;

        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _picture;

        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        private string _upadted;

        public string Upadted
        {
            get { return _upadted; }
            set { _upadted = value; }
        }

        private string _removed;

        public string Removed
        {
            get { return _removed; }
            set { _removed = value; }
        }

        #endregion IProfileQueryParams Members

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