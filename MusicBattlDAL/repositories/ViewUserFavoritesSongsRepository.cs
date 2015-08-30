using Microsoft.Practices.EnterpriseLibrary.Data;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace MusicBattlDAL
{
    public class ViewUserFavoritesSongsRepository : IRepository<IViewUserFavoritesSongs>
    {
        private IList<IViewUserFavoritesSongs> _collection;
        private Database _dataBase;

        #region Constructor

        public ViewUserFavoritesSongsRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewUserFavoritesSongs>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewUserFavoritesSongs GetById(int id)
        {
            IViewUserFavoritesSongs viewUserFavoritesSongs = new ViewUserFavoritesSongs();
            string sqlCommand = "viewUserFavoritesSongsFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" viewUserFavoritesSongsId = {0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewUserFavoritesSongs.SongId = Convert.ToInt32(reader["songId"].ToString());
                        viewUserFavoritesSongs.UsuarioId = Convert.ToInt32(reader["usuarioId"].ToString());
                        viewUserFavoritesSongs.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        viewUserFavoritesSongs.TotalSong = Convert.ToInt32(reader["totalSong"].ToString());
                        viewUserFavoritesSongs.AlbumId = Convert.ToInt32(reader["albumId"].ToString());
                        viewUserFavoritesSongs.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewUserFavoritesSongs.AlbumCover = reader["albumCover"].ToString();
                        viewUserFavoritesSongs.AlbumName = reader["albumName"].ToString();
                        viewUserFavoritesSongs.ArtistName = reader["artistName"].ToString();
                        viewUserFavoritesSongs.SongName = reader["songName"].ToString();
                    }
                }
            }

            return viewUserFavoritesSongs;
        }

        #endregion GetById( int id )

        #region GetTop<IViewUserFavoritesSongsQueryParams>(int top,IViewUserFavoritesSongsQueryParams query )

        public IList<IViewUserFavoritesSongs> GetTop<IViewUserFavoritesSongsQueryParams>(int top, IViewUserFavoritesSongsQueryParams query)
        {
            _collection = new List<IViewUserFavoritesSongs>();
            string sqlCommand = "viewUserFavoritesSongsGetTop";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@topParam", DbType.Int32, top);
                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, ((IDataQuery)query).From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, ((IDataQuery)query).Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, ((IDataQuery)query).OrderBy);

                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        IViewUserFavoritesSongs viewUserFavoritesSongs = new ViewUserFavoritesSongs();

                        viewUserFavoritesSongs.SongId = Convert.ToInt32(reader["songId"].ToString());
                        viewUserFavoritesSongs.UsuarioId = Convert.ToInt32(reader["usuarioId"].ToString());
                        viewUserFavoritesSongs.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        viewUserFavoritesSongs.TotalSong = Convert.ToInt32(reader["totalSong"].ToString());
                        viewUserFavoritesSongs.AlbumId = Convert.ToInt32(reader["albumId"].ToString());
                        viewUserFavoritesSongs.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewUserFavoritesSongs.AlbumCover = reader["albumCover"].ToString();
                        viewUserFavoritesSongs.AlbumName = reader["albumName"].ToString();
                        viewUserFavoritesSongs.ArtistName = reader["artistName"].ToString();
                        viewUserFavoritesSongs.SongName = reader["songName"].ToString();
                        _collection.Add(viewUserFavoritesSongs);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewUserFavoritesSongsQueryParams>(int top,IViewUserFavoritesSongsQueryParams query )

        #region Find<IViewUserFavoritesSongsQueryParams>( IViewUserFavoritesSongsQueryParams query )

        public IList<IViewUserFavoritesSongs> Find<IViewUserFavoritesSongsQueryParams>(IViewUserFavoritesSongsQueryParams query)
        {
            _collection = new List<IViewUserFavoritesSongs>();
            string sqlCommand = "viewUserFavoritesSongsFind";
            // Create a suitable command type and add the required parameter.
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, ((IDataQuery)query).From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, ((IDataQuery)query).Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, ((IDataQuery)query).OrderBy);
                _dataBase.AddInParameter(dbCmd, "@pageNumber", DbType.String, ((IDataQuery)query).Page);
                _dataBase.AddInParameter(dbCmd, "@rowCount", DbType.String, ((IDataQuery)query).RowCount);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        IViewUserFavoritesSongs viewUserFavoritesSongs = new ViewUserFavoritesSongs();

                        viewUserFavoritesSongs.SongId = Convert.ToInt32(reader["songId"].ToString());
                        viewUserFavoritesSongs.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        viewUserFavoritesSongs.TotalSong = Convert.ToInt32(reader["totalSong"].ToString());
                        viewUserFavoritesSongs.AlbumId = Convert.ToInt32(reader["albumId"].ToString());
                        viewUserFavoritesSongs.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewUserFavoritesSongs.AlbumCover = reader["albumCover"].ToString();
                        viewUserFavoritesSongs.AlbumName = reader["albumName"].ToString();
                        viewUserFavoritesSongs.ArtistName = reader["artistName"].ToString();
                        viewUserFavoritesSongs.SongName = reader["songName"].ToString();
                        _collection.Add(viewUserFavoritesSongs);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewUserFavoritesSongsQueryParams>( IViewUserFavoritesSongsQueryParams query )

        #region Count<IViewUserFavoritesSongsQueryParams>( IViewUserFavoritesSongsQueryParams query )

        public int Count<IViewUserFavoritesSongsQueryParams>(IViewUserFavoritesSongsQueryParams query)
        {
            int count = 0;
            string sqlCommand = "countByParams";

            // Create a suitable command type and add the required parameter.
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, ((IDataQuery)query).From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, ((IDataQuery)query).Where);

                count = (int)_dataBase.ExecuteScalar(dbCmd);
            }

            return count;
        }

        #endregion Count<IViewUserFavoritesSongsQueryParams>( IViewUserFavoritesSongsQueryParams query )

        #region Sum<IViewUserFavoritesSongsQueryParams>( IViewUserFavoritesSongsQueryParams query )

        public decimal Sum<IViewUserFavoritesSongsQueryParams>(IViewUserFavoritesSongsQueryParams query)
        {
            decimal sum = 0;
            string sqlCommand = "sumByParams";
            // Create a suitable command type and add the required parameter.
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, ((IDataQuery)query).From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, ((IDataQuery)query).Where);
                _dataBase.AddInParameter(dbCmd, "@columnParam", DbType.String, ((IDataQuery)query).Column);

                sum = Convert.ToDecimal(_dataBase.ExecuteScalar(dbCmd));
            }

            return sum;
        }

        #endregion Sum<IViewUserFavoritesSongsQueryParams>( IViewUserFavoritesSongsQueryParams query )

        #region Add( IViewUserFavoritesSongs )

        public IViewUserFavoritesSongs Add(IViewUserFavoritesSongs viewUserFavoritesSongs)
        {
            IViewUserFavoritesSongs viewUserFavoritesSongsAdded = new ViewUserFavoritesSongs();
            int id = 0;
            string sqlCommand = "viewUserFavoritesSongsAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@songId", DbType.Int32, viewUserFavoritesSongs.SongId);
                _dataBase.AddInParameter(dbCmd, "@usuarioId", DbType.Int32, viewUserFavoritesSongs.UsuarioId);
                _dataBase.AddInParameter(dbCmd, "@profileId", DbType.Int32, viewUserFavoritesSongs.ProfileId);
                _dataBase.AddInParameter(dbCmd, "@totalSong", DbType.Int32, viewUserFavoritesSongs.TotalSong);
                _dataBase.AddInParameter(dbCmd, "@albumId", DbType.Int32, viewUserFavoritesSongs.AlbumId);
                _dataBase.AddInParameter(dbCmd, "@artistId", DbType.Int32, viewUserFavoritesSongs.ArtistId);
                _dataBase.AddInParameter(dbCmd, "@albumCover", DbType.String, viewUserFavoritesSongs.AlbumCover);
                _dataBase.AddInParameter(dbCmd, "@albumName", DbType.String, viewUserFavoritesSongs.AlbumName);
                _dataBase.AddInParameter(dbCmd, "@artistName", DbType.String, viewUserFavoritesSongs.ArtistName);
                _dataBase.AddInParameter(dbCmd, "@songName", DbType.String, viewUserFavoritesSongs.SongName);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));

                viewUserFavoritesSongsAdded = this.GetById(id);
            }

            return viewUserFavoritesSongsAdded;
        }

        #endregion Add( IViewUserFavoritesSongs )

        #region Update( IViewUserFavoritesSongs )

        public IViewUserFavoritesSongs Update(IViewUserFavoritesSongs viewUserFavoritesSongs)
        {
            IViewUserFavoritesSongs retorno = new ViewUserFavoritesSongs();
            string sqlCommand = "viewUserFavoritesSongsUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@songId", DbType.Int32, viewUserFavoritesSongs.SongId);
                _dataBase.AddInParameter(dbCmd, "@usuarioId", DbType.Int32, viewUserFavoritesSongs.UsuarioId);
                _dataBase.AddInParameter(dbCmd, "@profileId", DbType.Int32, viewUserFavoritesSongs.ProfileId);
                _dataBase.AddInParameter(dbCmd, "@totalSong", DbType.Int32, viewUserFavoritesSongs.TotalSong);
                _dataBase.AddInParameter(dbCmd, "@albumId", DbType.Int32, viewUserFavoritesSongs.AlbumId);
                _dataBase.AddInParameter(dbCmd, "@artistId", DbType.Int32, viewUserFavoritesSongs.ArtistId);
                _dataBase.AddInParameter(dbCmd, "@albumCover", DbType.String, viewUserFavoritesSongs.AlbumCover);
                _dataBase.AddInParameter(dbCmd, "@albumName", DbType.String, viewUserFavoritesSongs.AlbumName);
                _dataBase.AddInParameter(dbCmd, "@artistName", DbType.String, viewUserFavoritesSongs.ArtistName);
                _dataBase.AddInParameter(dbCmd, "@songName", DbType.String, viewUserFavoritesSongs.SongName);

                _dataBase.ExecuteScalar(dbCmd);

                retorno = this.GetById(viewUserFavoritesSongs.SongId);
            }
            return retorno;
        }

        #endregion Update( IViewUserFavoritesSongs )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;
            string sqlCommand = "viewUserFavoritesSongsRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@viewUserFavoritesSongsId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewUserFavoritesSongs> Collection
        {
            get { return _collection; }
        }

        #endregion Collection

        #region IDataBaseAccess

        public IDataBaseAccess DataBaseAccess
        {
            get
            {
                return null;
            }
        }

        #endregion IDataBaseAccess
    }
}