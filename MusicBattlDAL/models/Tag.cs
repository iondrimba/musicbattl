using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class Tag : ITag
    {
        #region Properties

        private int _tagId;

        public int TagId
        {
            get { return _tagId; }
            set { _tagId = value; }
        }

        private int _ownerTableId;

        public int OwnerTableId
        {
            get { return _ownerTableId; }
            set { _ownerTableId = value; }
        }

        private int _ownerId;

        public int OwnerId
        {
            get { return _ownerId; }
            set { _ownerId = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion Properties

        #region Constructor

        public Tag()
        {
        }

        #endregion Constructor
    }
}