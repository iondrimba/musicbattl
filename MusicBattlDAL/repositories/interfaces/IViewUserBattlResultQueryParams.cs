namespace MusicBattlDAL.repositories.interfaces
{
    public interface IViewUserBattlResultQueryParams
    {
        string BattlId { set; get; }

        string FirstSongId { set; get; }

        string SecondSongId { set; get; }

        string ArtistNameFirst { set; get; }

        string ArtistNameSecond { set; get; }

        string TotalFirst { set; get; }

        string TotalSecond { set; get; }

        string ProfileIdFirst { set; get; }

        string TotalFirstSong { set; get; }

        string NameFirst { set; get; }

        string ProfileIdSecond { set; get; }

        string TotalSecondSong { set; get; }

        string NameSecond { set; get; }

        string ArtistIdFirst { set; get; }

        string ArtistIdSecond { set; get; }

        string FirstAlbumCover { set; get; }

        string SecondAlbumCover { set; get; }
    }
}