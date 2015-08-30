using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IViewBattlResultBLL
    {
        IList<IViewBattlResults> GetBattlsWonByProfileId( int profileId , int count = 0 );

        IList<IViewBattlResults> GetBattlsLostByProfileId( int profileId , int count = 0 );
    }
}