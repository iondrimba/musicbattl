namespace MusicBattlDAL.repositories.interfaces
{
    public interface ISongQueryParams
    {
        string SongId { set; get; }

        string AlbumId { set; get; }

        string Name { set; get; }

        string Duration { set; get; }

        string TrackNumber { set; get; }
    }
}