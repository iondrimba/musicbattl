namespace MusicBattlBLL.repositories.interfaces
{
    public interface IViewTopAlbumsQueryParams
    {
        string ArtistId { set; get; }

        string TotalVotes { set; get; }

        string AlbumName { set; get; }

        string ArtistName { set; get; }

        string AlbumCover { set; get; }

        string BattlDate { set; get; }
    }
}