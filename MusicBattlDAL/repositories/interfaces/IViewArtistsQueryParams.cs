namespace MusicBattlDAL.repositories.interfaces
{
    public interface IViewArtistsQueryParams
    {
        string ArtistId { set; get; }

        string Name { set; get; }

        string Description { set; get; }

        string Picture { set; get; }
    }
}