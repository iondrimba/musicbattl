using MusicBattlDAL.models.interfaces;
using System;

namespace MusicBattlDAL
{
    [Serializable]
    public class Discography : IDiscography
    {
        #region Properties

        private int _discographyId;

        public int DiscographyId
        {
            get { return _discographyId; }
            set { _discographyId = value; }
        }

        private int _artistId;

        public int ArtistId
        {
            get { return _artistId; }
            set { _artistId = value; }
        }

        #endregion Properties

        #region Constructor

        public Discography()
        {
        }

        #endregion Constructor
    }
}