using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IViewArtistsBLL
    {
        IList<IViewArtists> GetArtists( int page = 0 , int rowCount = 0 );

        int Total { get; set; }

        IList<IViewArtists> Collection { get; set; }
    }
}