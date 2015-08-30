namespace MusicBattlDAL.models.interfaces
{
    public interface IViewUserFavoritesSongs
    {
        int SongId { get; set; }

        int UsuarioId { get; set; }

        int ProfileId { get; set; }

        int? TotalSong { get; set; }

        int? AlbumId { get; set; }

        int? ArtistId { get; set; }

        string AlbumCover { get; set; }

        string AlbumName { get; set; }

        string ArtistName { get; set; }

        string SongName { get; set; }
    }
}