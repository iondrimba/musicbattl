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
    public class SongRepository : IRepository<ISong>
    {
        private Database _dataBase;

        public Database DataBase
        {
            get { return _dataBase; }
            set { _dataBase = value; }
        }

        private IList<ISong> _collection;

        #region Constructor

        public SongRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<ISong>();
        }

        #endregion Constructor

        #region GetById( int id )

        public ISong GetById(int id)
        {
            ISong song = new Song();
            string sqlCommand = "songFind";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" songId = {0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        song.SongId = Convert.ToInt32(reader["songId"].ToString());
                        song.AlbumId = Convert.ToInt32(reader["albumId"].ToString());
                        song.Name = reader["name"].ToString();
                        song.Duration = reader["duration"].ToString();
                        song.SoundCloudUrl = reader["soundCloudUrl"].ToString();
                        song.TrackNumber = Convert.ToInt32(reader["trackNumber"].ToString());
                    }
                }
            }

            return song;
        }

        #endregion GetById( int id )

        #region GetTop<ISongQueryParams>(int top,ISongQueryParams query )

        public IList<ISong> GetTop<ISongQueryParams>(int top, ISongQueryParams query)
        {
            _collection = new List<ISong>();
            string sqlCommand = "songGetTop";

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
                        ISong song = new Song();

                        song.SongId = Convert.ToInt32(reader["songId"].ToString());
                        song.AlbumId = Convert.ToInt32(reader["albumId"].ToString());
                        song.Name = reader["name"].ToString();
                        song.Duration = reader["duration"].ToString();
                        song.SoundCloudUrl = reader["soundCloudUrl"].ToString();
                        song.TrackNumber = Convert.ToInt32(reader["trackNumber"].ToString());
                        _collection.Add(song);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<ISongQueryParams>(int top,ISongQueryParams query )

        #region Find<ISongQueryParams>( ISongQueryParams query )

        public IList<ISong> Find<ISongQueryParams>(ISongQueryParams query)
        {
            _collection = new List<ISong>();
            string sqlCommand = "songFind";
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
                        ISong song = new Song();

                        song.SongId = Convert.ToInt32(reader["songId"].ToString());
                        song.AlbumId = Convert.ToInt32(reader["albumId"].ToString());
                        song.Name = reader["name"].ToString();
                        song.Duration = reader["duration"].ToString();
                        song.SoundCloudUrl = reader["soundCloudUrl"].ToString();
                        song.TrackNumber = Convert.ToInt32(reader["trackNumber"].ToString());
                        _collection.Add(song);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<ISongQueryParams>( ISongQueryParams query )

        #region Count<ISongQueryParams>( ISongQueryParams query )

        public int Count<ISongQueryParams>(ISongQueryParams query)
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

        #endregion Count<ISongQueryParams>( ISongQueryParams query )

        #region Sum<ISongQueryParams>( ISongQueryParams query )

        public decimal Sum<ISongQueryParams>(ISongQueryParams query)
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

        #endregion Sum<ISongQueryParams>( ISongQueryParams query )

        #region Add( ISong )

        public ISong Add(ISong song)
        {
            int id = 0;
            string sqlCommand = "songAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@albumId", DbType.Int32, song.AlbumId);
                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, song.Name);
                _dataBase.AddInParameter(dbCmd, "@duration", DbType.String, song.Duration);                
                _dataBase.AddInParameter(dbCmd, "@trackNumber", DbType.Int32, song.TrackNumber);
                _dataBase.AddInParameter(dbCmd, "@soundCloudUrl", DbType.String, song.SoundCloudUrl);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));

                song = this.GetById(id);
            }
            return song;
        }

        #endregion Add( ISong )

        #region Update( ISong )

        public ISong Update(ISong song)
        {
            ISong songUpdated = new Song();
            string sqlCommand = "songUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@songId", DbType.Int32, song.SongId);
                _dataBase.AddInParameter(dbCmd, "@albumId", DbType.Int32, song.AlbumId);
                _dataBase.AddInParameter(dbCmd, "@name", DbType.Int32, song.Name);
                _dataBase.AddInParameter(dbCmd, "@duration", DbType.Int32, song.Duration);                
                _dataBase.AddInParameter(dbCmd, "@trackNumber", DbType.Int32, song.TrackNumber);
                _dataBase.AddInParameter(dbCmd, "@soundCloudUrl", DbType.String, song.SoundCloudUrl);
                _dataBase.ExecuteScalar(dbCmd);

                songUpdated = this.GetById(song.SongId);
            }

            return songUpdated;
        }

        #endregion Update( ISong )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;
            string sqlCommand = "songRemove";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@songId", DbType.Int32, id);
                int rowsAffected = _dataBase.ExecuteNonQuery(dbCmd);

                success = (rowsAffected > 0);
            }

            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<ISong> Collection
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