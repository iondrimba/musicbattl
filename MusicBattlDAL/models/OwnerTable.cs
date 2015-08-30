using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class OwnerTable : IOwnerTable
    {
        #region Properties

        private int _ownerTableId;

        public int OwnerTableId
        {
            get { return _ownerTableId; }
            set { _ownerTableId = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion Properties

        #region Constructor

        public OwnerTable()
        {
        }

        #endregion Constructor
    }
}