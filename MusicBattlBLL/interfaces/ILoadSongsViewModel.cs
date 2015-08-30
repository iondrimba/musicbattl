using MusicBattlDAL;
using MusicBattlDAL.models.interfaces;
using System.Collections.Generic;

namespace MusicBattlBLL.interfaces
{
    public interface ILoadSongsViewModel
    {
        IArtist Artist{ get;set;}

        IArtistContact ArtistContact { get; set; }

        IDiscography Discography { get; set; }

        IList<Song> Songs { get; set; }

        IAlbum Album { get; set; }

        void Save();
    }
}