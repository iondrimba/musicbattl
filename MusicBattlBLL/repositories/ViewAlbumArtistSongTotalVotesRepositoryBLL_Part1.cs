using System.Collections.Generic;
using MusicBattlDAL;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public partial class ViewAlbumArtistSongTotalVotesRepositoryBLL
    {
        #region IRepositoryBLL<IViewTopAlbums> Members

        #region IList<IViewAlbumArtistSongTotalVotes> ExecuteProcedure( string procedureName, IDataQuery query, int count=0 )

        public IList<IViewAlbumArtistSongTotalVotes> ExecuteProcedure( string procedureName , IDataQuery query , int count = 0 )
        {
            IList<IViewAlbumArtistSongTotalVotes> collection = ((ViewAlbumArtistSongTotalVotesRepository)_repositorieDAL).ExecuteProcedure(procedureName , query , count);

            return collection;
        }

        #endregion IList<IViewAlbumArtistSongTotalVotes> ExecuteProcedure( string procedureName, IDataQuery query, int count=0 )

        #endregion IRepositoryBLL<IViewTopAlbums> Members
    }
}