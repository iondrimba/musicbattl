using System.Collections.Generic;

namespace MusicBattlBLL.interfaces
{
    public interface IViewActivityByHourBLL
    {
        IList<IPieChartItem> GetTotals();
    }
}