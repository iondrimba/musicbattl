namespace MusicBattlDAL.repositories.interfaces
{
    public interface IViewTopSongsQueryParams
    {
        string ArtistId { set; get; }

        string SongId { set; get; }

        string SongName { set; get; }

        string ArtistName { set; get; }

        string AlbumName { set; get; }

        string AlbumCover { set; get; }

        string TotalVotes { set; get; }
    }
}