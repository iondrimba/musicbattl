namespace MusicBattlDAL.models.interfaces
{
    public interface IArtistContact
    {
        int IdArtistContact { get; set; }

        int ArtistId { get; set; }

        string Soundcloud { get; set; }

        string Bandcamp { get; set; }

        string Website { get; set; }

        string Tumblr { get; set; }

        string Facebook { get; set; }

        string Twitter { get; set; }

        string Email { get; set; }
    }
}