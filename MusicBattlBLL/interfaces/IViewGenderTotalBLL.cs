using System.Collections.Generic;

namespace MusicBattlBLL.interfaces
{
    public interface IViewGenderTotalBLL
    {
        IList<IPieChartItem> GetTotals();
    }
}