using System.Collections.Generic;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.repositories
{
    public partial class ViewTopAlbumsRepositoryBLL
    {
        #region IRepositoryBLL<IViewTopAlbums> Members

        #region IList<IViewTopAlbums> ExecuteProcedure( string procedureName, IDataQuery query, int count=0 )

        public IList<IViewTopAlbums> ExecuteProcedure( string procedureName , IDataQuery query , int count = 0 )
        {
            IList<IViewTopAlbums> collection = ((ViewTopAlbumsRepository)_repositorieDAL).ExecuteProcedure(procedureName , query , count);

            return collection;
        }

        #endregion IList<IViewTopAlbums> ExecuteProcedure( string procedureName, IDataQuery query, int count=0 )

        #endregion IRepositoryBLL<IViewTopAlbums> Members
    }
}