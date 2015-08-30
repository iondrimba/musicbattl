using MusicBattlDAL.interfaces;
using MusicBattlDAL.repositories.interfaces;

namespace MusicBattlDAL.concrete
{
    public class ViewUserTotalVotesQueryParams : IViewUserTotalVotesQueryParams , IDataQuery
    {
        #region IViewUserTotalVotesQueryParams Members

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

        private string _total;

        public string Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _usuarioId;

        public string UsuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        private string _picture;

        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        private string _songName;

        public string SongName
        {
            get { return _songName; }
            set { _songName = value; }
        }

        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        #endregion IViewUserTotalVotesQueryParams Members

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