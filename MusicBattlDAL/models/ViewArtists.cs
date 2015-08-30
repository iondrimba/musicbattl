using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewArtists : IViewArtists
    {
        #region Properties

        private int _artistId;

        public int ArtistId
        {
            get { return _artistId; }
            set { _artistId = value; }
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

        #endregion Properties

        #region Constructor

        public ViewArtists()
        {
        }

        #endregion Constructor
    }
}