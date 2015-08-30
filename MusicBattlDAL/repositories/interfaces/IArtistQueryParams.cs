namespace MusicBattlDAL.repositories.interfaces
{
    public interface IArtistQueryParams
    {
        string ArtistId { set; get; }

        string Name { set; get; }

        string Description { set; get; }
    }
}