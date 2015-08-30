using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IViewTopSongsBLL
    {
        IList<IViewTopSongs> GetTopSongsSilver( int page = 0 , int rowCount = 0 );

        IList<IViewTopSongs> GetTopSongsGold( int page = 0 , int rowCount = 0 );

        IList<IViewTopSongs> GetTopSongsBronze( int page = 0 , int rowCount = 0 );

        int Total { get; set; }

        IList<IViewTopSongs> Collection { get; set; }
    }
}