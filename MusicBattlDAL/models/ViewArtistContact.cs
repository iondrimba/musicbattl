using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewArtistContact : IViewArtistContact
    {
        #region Properties

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

        private int _artistId;

        public int ArtistId
        {
            get { return _artistId; }
            set { _artistId = value; }
        }

        private int _idArtistContact;

        public int IdArtistContact
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

        #endregion Properties

        #region Constructor

        public ViewArtistContact()
        {
        }

        #endregion Constructor
    }
}