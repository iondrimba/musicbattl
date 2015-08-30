using System;

namespace MusicBattlDAL.models.interfaces
{
    public interface IAlbum
    {
        int AlbumId { get; set; }

        int ArtistId { get; set; }

        DateTime? Year { get; set; }

        string AlbumCover { get; set; }

        string Name { get; set; }

        string Description { get; set; }
    }
}