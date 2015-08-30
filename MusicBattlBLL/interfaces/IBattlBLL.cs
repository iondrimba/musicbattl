using System;
using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;
using MusicBattlDAL.repositories.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IBattlBLL
    {
        IViewBattl CreateBattl();

        IViewBattl CreateBattl( DateTime time );

        IViewBattl GetActiveBattl( IViewBattlQueryParams queryParams );

        IList<IBattl> GetPastBattls( int count );

        int BattlInterval { get; set; }

        void EndActiveBattl();
    }
}