namespace MusicBattlDAL.repositories.interfaces
{
    public interface IViewArtistContactQueryParams
    {
        string Name { set; get; }

        string Description { set; get; }

        string Picture { set; get; }

        string ArtistId { set; get; }

        string IdArtistContact { set; get; }

        string Bandcamp { set; get; }

        string Soundcloud { set; get; }

        string Website { set; get; }

        string Tumblr { set; get; }

        string Facebook { set; get; }

        string Twitter { set; get; }

        string Email { set; get; }
    }
}