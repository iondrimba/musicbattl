namespace MusicBattlDAL.repositories.interfaces
{
    public interface IViewBattlResultsQueryParams
    {
        string BattlId { set; get; }

        string FirstSongId { set; get; }

        string SecondSongId { set; get; }

        string ArtistNameSecond { set; get; }

        string ArtistNameFirst { set; get; }

        string TotalSecond { set; get; }

        string TotalFirst { set; get; }

        string ProfileId { set; get; }
    }
}