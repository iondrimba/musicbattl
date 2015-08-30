namespace MusicBattlDAL.models.interfaces
{
    public interface IViewPastBattls
    {
        int BattlId { get; set; }

        int FirstSongId { get; set; }

        int FirstAlbumId { get; set; }

        int FirstArtistId { get; set; }

        string FirstSongName { get; set; }

        string FirstAlbumName { get; set; }

        string FirstArtistName { get; set; }

        int SecondSongId { get; set; }

        int SecondAlbumId { get; set; }

        int SecondArtistId { get; set; }

        int? TotalSecond { get; set; }

        int? TotalFirst { get; set; }

        string SecondSongName { get; set; }

        string SecondSoundCloudUrl { get; set; }

        string FirstSoundCloudUrl { get; set; }

        string SecondAlbumName { get; set; }

        string SecondArtistName { get; set; }

        string FirstAlbumCover { get; set; }

        string SecondAlbumCover { get; set; }

        bool Active { get; set; }
    }
}