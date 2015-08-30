using MusicBattlDAL.interfaces;
using MusicBattlDAL.repositories.interfaces;

namespace MusicBattlDAL.concrete
{
    public class DiscographyQueryParams : IDiscographyQueryParams , IDataQuery
    {
        #region IDiscographyQueryParams Members

        private string _discographyId;

        public string DiscographyId
        {
            get { return _discographyId; }
            set { _discographyId = value; }
        }

        private string _artistId;

        public string ArtistId
        {
            get { return _artistId; }
            set { _artistId = value; }
        }

        #endregion IDiscographyQueryParams Members

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