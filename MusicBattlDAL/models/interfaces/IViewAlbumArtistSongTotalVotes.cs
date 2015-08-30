using System;

namespace MusicBattlDAL.models.interfaces
{
    public interface IViewAlbumArtistSongTotalVotes
    {
        int SongId { get; set; }

        int? Total { get; set; }

        string SongName { get; set; }

        string AlbumName { get; set; }

        string ArtistName { get; set; }

        int ArtistId { get; set; }

        string AlbumCover { get; set; }

        string Picture { get; set; }

        DateTime BattlDate { get; set; }
    }
}