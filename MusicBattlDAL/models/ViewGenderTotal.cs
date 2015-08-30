using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewGenderTotal : IViewGenderTotal
    {
        #region Properties

        private int _total;
        private int _totalFemale;
        private int _totalMale;

        #endregion Properties

        #region Constructor

        public ViewGenderTotal()
        {
        }

        #endregion Constructor

        #region IViewGenderTotal Members

        public int Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
            }
        }

        public int TotalFemale
        {
            get
            {
                return _totalFemale;
            }
            set
            {
                _totalFemale = value;
            }
        }

        public int TotalMale
        {
            get
            {
                return _totalMale;
            }
            set
            {
                _totalMale = value;
            }
        }

        #endregion IViewGenderTotal Members
    }
}