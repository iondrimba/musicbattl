using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IViewUserBattlResultBLL
    {
        IList<IViewUserBattlResult> GetBattlsWonByProfileId( int profileId , int page = 0 , int rowCount = 0 );

        IList<IViewUserBattlResult> GetBattlsLostByProfileId( int profileId , int page = 0 , int rowCount = 0 );

        IViewUserFavoritesSongsBLL GetFavoritesByProfileId( int profileId , int page = 0 , int rowCount = 0 );

        int Total { get; set; }

        IList<IViewUserBattlResult> Collection { get; set; }
    }
}