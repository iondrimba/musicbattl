namespace MusicBattlDAL.models.interfaces
{
    public interface ISong
    {
        int SongId { get; set; }

        int AlbumId { get; set; }

        string Name { get; set; }

        string Duration { get; set; }

        int TrackNumber { get; set; }

        string SoundCloudUrl { get; set; }
    }
}