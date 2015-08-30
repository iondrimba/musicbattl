using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewActivityByHour : IViewActivityByHour
    {
        #region Properties

        private int _hour;

        public int Hour
        {
            get { return _hour; }
            set { _hour = value; }
        }

        private int? _totalByHour;

        public int? TotalByHour
        {
            get { return _totalByHour; }
            set { _totalByHour = value; }
        }

        #endregion Properties

        #region Constructor

        public ViewActivityByHour()
        {
        }

        #endregion Constructor
    }
}