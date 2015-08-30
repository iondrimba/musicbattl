using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IViewArtistContactBLL
    {
        IViewArtistContact ArtistContactGet( int id );
    }
}