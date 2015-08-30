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
    public class AlbumRepository : IRepository<IAlbum>
    {
        private Database _dataBase;
        private IList<IAlbum> _collection;

        #region Constructor

        public AlbumRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IAlbum>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IAlbum GetById(int id)
        {
            IAlbum album = new Album();
            string sqlCommand = "albumFind";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" albumId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        album.AlbumId = Convert.ToInt32(reader["albumId"].ToString());
                        album.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        album.Year = reader["year"] == DBNull.Value ? null : (DateTime?)reader["year"];
                        album.AlbumCover = reader["albumCover"].ToString();
                        album.Name = reader["name"].ToString();
                        album.Description = reader["description"].ToString();
                    }
                }
            }

            return album;
        }

        #endregion GetById( int id )

        #region GetTop<IAlbumQueryParams>(int top,IAlbumQueryParams query )

        public IList<IAlbum> GetTop<IAlbumQueryParams>(int top, IAlbumQueryParams query)
        {
            _collection = new List<IAlbum>();
            string sqlCommand = "albumGetTop";

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
                        IAlbum album = new Album();

                        album.AlbumId = Convert.ToInt32(reader["albumId"].ToString());
                        album.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        album.Year = reader["year"] == DBNull.Value ? null : (DateTime?)reader["year"];
                        album.AlbumCover = reader["albumCover"].ToString();
                        album.Name = reader["name"].ToString();
                        album.Description = reader["description"].ToString();
                        _collection.Add(album);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IAlbumQueryParams>(int top,IAlbumQueryParams query )

        #region Find<IAlbumQueryParams>( IAlbumQueryParams query )

        public IList<IAlbum> Find<IAlbumQueryParams>(IAlbumQueryParams query)
        {
            _collection = new List<IAlbum>();
            string sqlCommand = "albumFind";

            // Create a suitable command type and add the required parameter.
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, ((IDataQuery)query).From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, ((IDataQuery)query).Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, ((IDataQuery)query).OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        IAlbum album = new Album();

                        album.AlbumId = Convert.ToInt32(reader["albumId"].ToString());
                        album.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        album.Year = reader["year"] == DBNull.Value ? null : (DateTime?)reader["year"];
                        album.AlbumCover = reader["albumCover"].ToString();
                        album.Name = reader["name"].ToString();
                        album.Description = reader["description"].ToString();
                        _collection.Add(album);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IAlbumQueryParams>( IAlbumQueryParams query )

        #region Count<IAlbumQueryParams>( IAlbumQueryParams query )

        public int Count<IAlbumQueryParams>(IAlbumQueryParams query)
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

        #endregion Count<IAlbumQueryParams>( IAlbumQueryParams query )

        #region Sum<IAlbumQueryParams>( IAlbumQueryParams query )

        public decimal Sum<IAlbumQueryParams>(IAlbumQueryParams query)
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

        #endregion Sum<IAlbumQueryParams>( IAlbumQueryParams query )

        #region Add( IAlbum )

        public IAlbum Add(IAlbum album)
        {
            int id = 0;
            string sqlCommand = "albumAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@artistId", DbType.Int32, album.ArtistId);
                _dataBase.AddInParameter(dbCmd, "@year", DbType.Int32, album.Year);
                _dataBase.AddInParameter(dbCmd, "@albumCover", DbType.String, album.AlbumCover);
                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, album.Name);
                _dataBase.AddInParameter(dbCmd, "@description", DbType.String, album.Description);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));
                album = this.GetById(id);
            }

            return album;
        }

        #endregion Add( IAlbum )

        #region Update( IAlbum )

        public IAlbum Update(IAlbum album)
        {
            IAlbum albumUpdated = new Album();
            string sqlCommand = "albumUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@albumId", DbType.Int32, album.AlbumId);
                _dataBase.AddInParameter(dbCmd, "@artistId", DbType.Int32, album.ArtistId);
                _dataBase.AddInParameter(dbCmd, "@year", DbType.Int32, album.Year);
                _dataBase.AddInParameter(dbCmd, "@albumCover", DbType.String, album.AlbumCover);
                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, album.Name);
                _dataBase.AddInParameter(dbCmd, "@description", DbType.String, album.Description);

                _dataBase.ExecuteScalar(dbCmd);
                albumUpdated = this.GetById(album.AlbumId);
            }

            return albumUpdated;
        }

        #endregion Update( IAlbum )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;

            string sqlCommand = "albumRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@albumId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IAlbum> Collection
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