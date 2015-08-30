using MusicBattlDAL.interfaces;
using MusicBattlDAL.repositories.interfaces;

namespace MusicBattlDAL.concrete
{
    public class VoteQueryParams : IVoteQueryParams , IDataQuery
    {
        #region IVoteQueryParams Members

        private string _voteId;

        public string VoteId
        {
            get { return _voteId; }
            set { _voteId = value; }
        }

        private string _battlId;

        public string BattlId
        {
            get { return _battlId; }
            set { _battlId = value; }
        }

        private string _songId;

        public string SongId
        {
            get { return _songId; }
            set { _songId = value; }
        }

        private string _profileId;

        public string ProfileId
        {
            get { return _profileId; }
            set { _profileId = value; }
        }

        private string _votes;

        public string Votes
        {
            get { return _votes; }
            set { _votes = value; }
        }

        #endregion IVoteQueryParams Members

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