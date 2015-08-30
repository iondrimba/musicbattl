using System.Collections.Generic;

namespace MusicBattlBLL.interfaces
{
    public interface IViewUserAgesTotalBLL
    {
        IList<IPieChartItem> GetTotals();
    }
}