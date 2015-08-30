namespace MusicBattlDAL.models.interfaces
{
    public interface IArtist
    {
        int ArtistId { get; set; }

        string Name { get; set; }

        string Picture { get; set; }

        string Description { get; set; }
    }
}