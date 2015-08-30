namespace MusicBattlDAL.models.interfaces
{
    public interface IViewArtists
    {
        int ArtistId { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        string Picture { get; set; }
    }
}