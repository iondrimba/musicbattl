namespace MusicBattlDAL.repositories.interfaces
{
    public interface IAlbumQueryParams
    {
        string AlbumId { set; get; }

        string ArtistId { set; get; }

        string Year { set; get; }

        string AlbumCover { set; get; }

        string Name { set; get; }

        string Description { set; get; }
    }
}