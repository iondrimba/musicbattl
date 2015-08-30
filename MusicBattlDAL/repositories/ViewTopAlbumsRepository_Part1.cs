using MusicBattlDAL;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace MusicBattlBLL
{
    public partial class ViewTopAlbumsRepository
    {
        #region IList<IViewTopAlbums> ExecuteProcedure<IViewTopAlbumsQueryParams>( string procedureName , IViewTopAlbumsQueryParams query , int top = 0 )

        public IList<IViewTopAlbums> ExecuteProcedure<IViewTopAlbumsQueryParams>(string procedureName, IViewTopAlbumsQueryParams query, int top = 0)
        {
            _collection = new List<IViewTopAlbums>();
            string sqlCommand = procedureName;

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@topParam", DbType.Int32, top);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, ((IDataQuery)query).Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, ((IDataQuery)query).OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        IViewTopAlbums viewTopAlbums = new ViewTopAlbums();

                        viewTopAlbums.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewTopAlbums.TotalVotes = Convert.ToInt32(reader["totalVotes"].ToString());
                        viewTopAlbums.AlbumName = reader["albumName"].ToString();
                        viewTopAlbums.ArtistName = reader["artistName"].ToString();
                        viewTopAlbums.AlbumCover = reader["albumCover"].ToString();

                        try
                        {
                            viewTopAlbums.BattlDate = (DateTime)reader["battlDate"];
                        }
                        catch (Exception) { }

                        _collection.Add(viewTopAlbums);
                    }
                }
            }

            return _collection;
        }

        #endregion IList<IViewTopAlbums> ExecuteProcedure<IViewTopAlbumsQueryParams>( string procedureName , IViewTopAlbumsQueryParams query , int top = 0 )
    }
}