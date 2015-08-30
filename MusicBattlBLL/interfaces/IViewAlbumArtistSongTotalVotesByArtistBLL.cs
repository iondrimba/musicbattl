using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IViewAlbumArtistSongTotalVotesByArtistBLL
    {
        IList<IViewAlbumArtistSongTotalVotesByArtist> GetTopMostVotedArtist( int page = 0 , int rowCount = 0 );

        int Total { get; set; }

        IList<IViewAlbumArtistSongTotalVotesByArtist> Collection { get; set; }
    }
}