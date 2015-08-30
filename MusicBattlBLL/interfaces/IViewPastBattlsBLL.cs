using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;
using System.Threading.Tasks;

namespace MusicBattlBLL.interfaces
{
    public interface IViewPastBattlsBLL
    {
        IList<IViewPastBattls> GetPastBattls(int page = 0, int rowCount = 0);

        int Total { get; set; }

        IList<IViewPastBattls> Collection { get; set; }

        IViewPastBattls GetPastBattlsById( int id );
    }
}