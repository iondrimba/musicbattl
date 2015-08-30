using System;

namespace MusicBattlDAL.models.interfaces
{
    public interface IViewTopAlbums
    {
        int ArtistId { get; set; }

        int? TotalVotes { get; set; }

        string AlbumName { get; set; }

        string ArtistName { get; set; }

        string AlbumCover { get; set; }

        DateTime BattlDate { get; set; }
    }
}