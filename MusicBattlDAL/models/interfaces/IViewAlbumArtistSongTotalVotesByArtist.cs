namespace MusicBattlDAL.models.interfaces
{
    public interface IViewAlbumArtistSongTotalVotesByArtist
    {
        int ArtistId { get; set; }

        int? Total { get; set; }

        string AlbumName { get; set; }

        string ArtistName { get; set; }

        string AlbumCover { get; set; }

        string Picture { get; set; }
    }
}