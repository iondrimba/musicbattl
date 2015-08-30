namespace MusicBattlDAL.repositories.interfaces
{
    public interface IViewAlbumArtistSongTotalVotesQueryParams
    {
        string SongId { set; get; }

        string Total { set; get; }

        string SongName { set; get; }

        string AlbumName { set; get; }

        string ArtistName { set; get; }

        string ArtistId { set; get; }

        string AlbumCover { set; get; }

        string BattlDate { set; get; }
    }
}