namespace MusicBattlDAL.models.interfaces
{
    public interface IViewUserBattlResult
    {
        int BattlId { get; set; }

        int FirstSongId { get; set; }

        int SecondSongId { get; set; }

        string ArtistNameFirst { get; set; }

        string ArtistNameSecond { get; set; }

        int? TotalFirst { get; set; }

        int? TotalSecond { get; set; }

        int ProfileIdFirst { get; set; }

        int? TotalFirstSong { get; set; }

        string NameFirst { get; set; }

        int ProfileIdSecond { get; set; }

        int? TotalSecondSong { get; set; }

        string NameSecond { get; set; }

        int? ArtistIdFirst { get; set; }

        int? ArtistIdSecond { get; set; }

        string FirstAlbumCover { get; set; }

        string SecondAlbumCover { get; set; }

        string SongNameFirst { get; set; }

        string SongNameSecond { get; set; }

        string AlbumNameFirst { get; set; }

        string AlbumNameSecond { get; set; }

        bool Active { get; set; }
    }
}