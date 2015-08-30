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
    public class ArtistRepository : IRepository<IArtist>
    {
        private Database _dataBase;
        private IList<IArtist> _collection;

        #region Constructor

        public ArtistRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IArtist>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IArtist GetById(int id)
        {
            IArtist artist = new Artist();

            string sqlCommand = "artistFind";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" artistId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        artist.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        artist.Name = reader["name"].ToString();
                        artist.Picture = reader["picture"].ToString();
                        artist.Description = reader["description"].ToString();
                    }
                }
            }
            return artist;
        }

        #endregion GetById( int id )

        #region GetTop<IArtistQueryParams>(int top,IArtistQueryParams query )

        public IList<IArtist> GetTop<IArtistQueryParams>(int top, IArtistQueryParams query)
        {
            _collection = new List<IArtist>();

            string sqlCommand = "artistGetTop";

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
                        IArtist artist = new Artist();

                        artist.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        artist.Name = reader["name"].ToString();
                        artist.Picture = reader["picture"].ToString();
                        artist.Description = reader["description"].ToString();
                        _collection.Add(artist);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IArtistQueryParams>(int top,IArtistQueryParams query )

        #region Find<IArtistQueryParams>( IArtistQueryParams query )

        public IList<IArtist> Find<IArtistQueryParams>(IArtistQueryParams query)
        {
            _collection = new List<IArtist>();
            string sqlCommand = "artistFind";

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
                        IArtist artist = new Artist();

                        artist.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        artist.Name = reader["name"].ToString();
                        artist.Description = reader["description"].ToString();
                        artist.Picture = reader["picture"].ToString();
                        _collection.Add(artist);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IArtistQueryParams>( IArtistQueryParams query )

        #region Count<IArtistQueryParams>( IArtistQueryParams query )

        public int Count<IArtistQueryParams>(IArtistQueryParams query)
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

        #endregion Count<IArtistQueryParams>( IArtistQueryParams query )

        #region Sum<IArtistQueryParams>( IArtistQueryParams query )

        public decimal Sum<IArtistQueryParams>(IArtistQueryParams query)
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

        #endregion Sum<IArtistQueryParams>( IArtistQueryParams query )

        #region Add( IArtist )

        public IArtist Add(IArtist artist)
        {
            int id = 0;
            string sqlCommand = "artistAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, artist.Name);
                _dataBase.AddInParameter(dbCmd, "@picture", DbType.String, artist.Picture);
                _dataBase.AddInParameter(dbCmd, "@description", DbType.String, artist.Description);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));
                artist = this.GetById(id);
            }

            return artist;
        }

        #endregion Add( IArtist )

        #region Update( IArtist )

        public IArtist Update(IArtist artist)
        {
            IArtist artistUpdated = new Artist();
            string sqlCommand = "artistUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@artistId", DbType.Int32, artist.ArtistId);
                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, artist.Name);
                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, artist.Picture);
                _dataBase.AddInParameter(dbCmd, "@description", DbType.String, artist.Description);

                _dataBase.ExecuteScalar(dbCmd);
                artistUpdated = this.GetById(artist.ArtistId);
            }

            return artistUpdated;
        }

        #endregion Update( IArtist )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;

            string sqlCommand = "artistRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@artistId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IArtist> Collection
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