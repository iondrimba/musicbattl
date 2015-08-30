namespace MusicBattlDAL.repositories.interfaces
{
    public interface IViewAlbumArtistSongTotalVotesByArtistQueryParams
    {
        string ArtistId { set; get; }

        string Total { set; get; }

        string AlbumName { set; get; }

        string ArtistName { set; get; }

        string AlbumCover { set; get; }

        string Picture { set; get; }
    }
}