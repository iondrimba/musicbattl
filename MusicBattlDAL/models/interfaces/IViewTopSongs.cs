namespace MusicBattlDAL.models.interfaces
{
    public interface IViewTopSongs
    {
        int ArtistId { get; set; }

        int SongId { get; set; }

        string SongName { get; set; }

        string ArtistName { get; set; }

        string AlbumName { get; set; }

        string AlbumCover { get; set; }

        int? TotalVotes { get; set; }
    }
}