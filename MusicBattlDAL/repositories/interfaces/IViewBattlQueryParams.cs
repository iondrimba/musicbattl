namespace MusicBattlDAL.repositories.interfaces
{
    public interface IViewBattlQueryParams
    {
        string BattlId { set; get; }

        string FirstSongId { set; get; }

        string FirstArtistId { set; get; }

        string StartTime { set; get; }

        string EndTime { set; get; }

        string BattlDate { set; get; }

        string FirstAlbumCover { set; get; }

        string FirstSongName { set; get; }

        string FirstArtistName { set; get; }

        string FirstAlbumName { set; get; }

        string SecondSongId { set; get; }

        string SecondArtistId { set; get; }

        string SecondSongName { set; get; }

        string SecondArtistName { set; get; }

        string SecondAlbumCover { set; get; }

        string SecondAlbumName { set; get; }

        bool Active { set; get; }
    }
}