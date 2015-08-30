namespace MusicBattlDAL.models.interfaces
{
    public interface IViewBattlResults
    {
        int BattlId { get; set; }

        int FirstSongId { get; set; }

        int SecondSongId { get; set; }

        string ArtistNameSecond { get; set; }

        string ArtistNameFirst { get; set; }

        int? TotalSecond { get; set; }

        int? TotalFirst { get; set; }

        int ProfileId { get; set; }

        bool Active { get; set; }
    }
}