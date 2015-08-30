using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IArtistBLL
    {
        IArtist GetRandomArtist( int idArtist );

        IList<IArtist> GetTopArtistVoted( int count );
    }
}