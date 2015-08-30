namespace MusicBattlDAL.repositories.interfaces
{
    public interface IViewPastBattlsQueryParams
    {
        string BattlId { set; get; }

        string FirstSongId { set; get; }

        string FirstAlbumId { set; get; }

        string FirstArtistId { set; get; }

        string FirstSongName { set; get; }

        string FirstAlbumName { set; get; }

        string FirstArtistName { set; get; }

        string SecondSongId { set; get; }

        string SecondAlbumId { set; get; }

        string SecondArtistId { set; get; }

        string SecondSongName { set; get; }

        string SecondAlbumName { set; get; }

        string SecondArtistName { set; get; }

        string FirstAlbumCover { set; get; }

        string SecondAlbumCover { set; get; }
    }
}