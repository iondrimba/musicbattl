namespace MusicBattlDAL.repositories.interfaces
{
    public interface IViewUserFavoritesSongsQueryParams
    {
        string SongId { set; get; }

        string UsuarioId { set; get; }

        string ProfileId { set; get; }

        string TotalSong { set; get; }

        string AlbumId { set; get; }

        string ArtistId { set; get; }

        string AlbumCover { set; get; }

        string AlbumName { set; get; }

        string ArtistName { set; get; }

        string SongName { set; get; }
    }
}