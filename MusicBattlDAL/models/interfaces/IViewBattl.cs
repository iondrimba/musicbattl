using System;

namespace MusicBattlDAL.models.interfaces
{
    public interface IViewBattl
    {
        int BattlId { get; set; }

        int FirstSongId { get; set; }

        int FirstArtistId { get; set; }

        DateTime StartTime { get; set; }

        DateTime EndTime { get; set; }

        DateTime BattlDate { get; set; }

        string FirstAlbumCover { get; set; }

        string FirstSongName { get; set; }

        string FirstArtistName { get; set; }

        string FirstAlbumName { get; set; }

        string FirstSongUrl { get; set; }

        int SecondSongId { get; set; }

        int SecondArtistId { get; set; }

        string SecondSongName { get; set; }

        string SecondArtistName { get; set; }

        string SecondAlbumCover { get; set; }

        string SecondAlbumName { get; set; }

        string SecondSongUrl { get; set; }

        int SecondSongVotes { get; set; }

        int FirstSongVotes { get; set; }

        bool Active { get; set; }
    }
}