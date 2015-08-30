namespace MusicBattlDAL.models.interfaces
{
    public interface IViewArtistContact
    {
        string Name { get; set; }

        string Description { get; set; }

        string Picture { get; set; }

        int ArtistId { get; set; }

        int IdArtistContact { get; set; }

        string Bandcamp { get; set; }

        string Soundcloud { get; set; }

        string Website { get; set; }

        string Tumblr { get; set; }

        string Facebook { get; set; }

        string Twitter { get; set; }

        string Email { get; set; }
    }
}