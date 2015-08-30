using MusicBattlBLL.interfaces;

namespace MusicBattlBLL.models
{
    public class PieChartItem : IPieChartItem
    {
        private decimal _value;
        private string _legend = string.Empty;

        #region IPieChartItem Members

        public decimal Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Legend
        {
            get { return _legend; }
            set { _legend = value; }
        }

        #endregion IPieChartItem Members
    }
}