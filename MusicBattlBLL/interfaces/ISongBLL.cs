using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface ISongBLL
    {
        ISong GetRandomSong( int artistId );
    }
}