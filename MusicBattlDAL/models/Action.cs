using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class Action : IAction
    {
        #region Properties

        private int _actionId;

        public int ActionId
        {
            get { return _actionId; }
            set { _actionId = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion Properties

        #region Constructor

        public Action()
        {
        }

        #endregion Constructor
    }
}