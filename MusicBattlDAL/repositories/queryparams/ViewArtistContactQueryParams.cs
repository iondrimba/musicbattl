using MusicBattlDAL.interfaces;
using MusicBattlDAL.repositories.interfaces;

namespace MusicBattlDAL.concrete
{
    public class ViewArtistContactQueryParams : IViewArtistContactQueryParams , IDataQuery
    {
        #region IViewArtistContactQueryParams Members

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

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _picture;

        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        private string _artistId;

        public string ArtistId
        {
            get { return _artistId; }
            set { _artistId = value; }
        }

        private string _idArtistContact;

        public string IdArtistContact
        {
            get { return _idArtistContact; }
            set { _idArtistContact = value; }
        }

        private string _bandcamp;

        public string Bandcamp
        {
            get { return _bandcamp; }
            set { _bandcamp = value; }
        }

        private string _soundcloud;

        public string Soundcloud
        {
            get { return _soundcloud; }
            set { _soundcloud = value; }
        }

        private string _website;

        public string Website
        {
            get { return _website; }
            set { _website = value; }
        }

        private string _tumblr;

        public string Tumblr
        {
            get { return _tumblr; }
            set { _tumblr = value; }
        }

        private string _facebook;

        public string Facebook
        {
            get { return _facebook; }
            set { _facebook = value; }
        }

        private string _twitter;

        public string Twitter
        {
            get { return _twitter; }
            set { _twitter = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        #endregion IViewArtistContactQueryParams Members

        #region IDataQuery Members

        private string _column;
        private string _from;
        private string _where;
        private string _orderBy;

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