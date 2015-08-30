using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IViewTopUsersBLL
    {
        IList<IViewTopUsers> GetTopUsersSilver( int page , int rowCount = 0 );

        IList<IViewTopUsers> GetTopUsersGold( int page , int rowCount = 0 );

        IList<IViewTopUsers> GetTopUsersBronze( int page , int rowCount = 0 );

        int Total { get; set; }

        IList<IViewTopUsers> Collection { get; set; }
    }
}