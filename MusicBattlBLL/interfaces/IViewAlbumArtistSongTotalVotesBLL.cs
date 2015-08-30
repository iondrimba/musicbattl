using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IViewAlbumArtistSongTotalVotesBLL
    {
        IList<IViewAlbumArtistSongTotalVotes> GetTopMostVotedSong( int page = 0 , int rowCount = 0 );

        IList<IViewAlbumArtistSongTotalVotes> GetTopMostVotedAlbum( int page = 0 , int rowCount = 0 );

        IList<IViewAlbumArtistSongTotalVotes> GetTopMostVotedArtist( int page = 0 , int rowCount = 0 );

        IList<IViewAlbumArtistSongTotalVotes> GetMostVotesToday( int page = 0 , int rowCount = 0 );

        IList<IViewAlbumArtistSongTotalVotes> GetMostVotedThisWeek( int page = 0 , int rowCount = 0 );

        IList<IViewAlbumArtistSongTotalVotes> GetMostVotedThisMonth( int page = 0 , int rowCount = 0 );

        int Total { get; set; }

        string OrderBy { get; set; }

        IList<IViewAlbumArtistSongTotalVotes> Collection { get; set; }
    }
}