using System;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class Profile : IProfile
    {
        #region Properties

        private int _profileId;

        public int ProfileId
        {
            get { return _profileId; }
            set { _profileId = value; }
        }

        private int _userId;

        public int UserId
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

        private DateTime _upadted;

        public DateTime Upadted
        {
            get { return _upadted; }
            set { _upadted = value; }
        }

        private bool _removed;

        public bool Removed
        {
            get { return _removed; }
            set { _removed = value; }
        }

        #endregion Properties

        #region Constructor

        public Profile()
        {
        }

        #endregion Constructor
    }
}