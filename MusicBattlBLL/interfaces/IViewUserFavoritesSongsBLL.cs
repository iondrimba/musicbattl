using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IViewUserFavoritesSongsBLL
    {
        IList<IViewUserFavoritesSongs> GetFavoriteSongsByProfileId( int profileId , int page = 0 , int rowCount = 0 );

        int Total { get; set; }

        IList<IViewUserFavoritesSongs> Collection { get; set; }
    }
}