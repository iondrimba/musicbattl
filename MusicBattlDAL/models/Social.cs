using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class Social : ISocial
    {
        #region Properties

        private int _socialId;

        public int SocialId
        {
            get { return _socialId; }
            set { _socialId = value; }
        }

        private int? _userId;

        public int? UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private int? _socialTypeId;

        public int? SocialTypeId
        {
            get { return _socialTypeId; }
            set { _socialTypeId = value; }
        }

        #endregion Properties

        #region Constructor

        public Social()
        {
        }

        #endregion Constructor
    }
}