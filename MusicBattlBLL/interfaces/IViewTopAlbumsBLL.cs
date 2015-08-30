using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IViewTopAlbumsBLL
    {
        IList<IViewTopAlbums> GetMostVotedAlbumToday( int page = 0 , int rowCount = 0 );

        IList<IViewTopAlbums> GetMostVotedAlbumThisWeek( int page = 0 , int rowCount = 0 );

        IList<IViewTopAlbums> GetMostVotedAlbumThisMonth( int page = 0 , int rowCount = 0 );

        int Total { get; set; }

        string OrderBy { get; set; }

        IList<IViewTopAlbums> Collection { get; set; }
    }
}