using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewUserAges : IViewUserAges
    {
        #region Properties

        private int? _age;

        public int? Age
        {
            get { return _age; }
            set { _age = value; }
        }

        #endregion Properties

        #region Constructor

        public ViewUserAges()
        {
        }

        #endregion Constructor
    }
}