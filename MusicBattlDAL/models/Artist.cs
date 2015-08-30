using MusicBattlDAL.models.interfaces;
using System;

namespace MusicBattlDAL
{
    [Serializable]
    public class Artist : IArtist
    {
        #region Properties

        private int _artistId;

        public int ArtistId
        {
            get { return _artistId; }
            set { _artistId = value; }
        }

        private string _picture;

        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
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

        #endregion Properties

        #region Constructor

        public Artist()
        {
        }

        #endregion Constructor
    }
}