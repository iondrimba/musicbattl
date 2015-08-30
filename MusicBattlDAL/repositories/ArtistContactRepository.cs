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
    public class ArtistContactRepository : IRepository<IArtistContact>
    {
        private Database _dataBase;
        private IList<IArtistContact> _collection;

        #region Constructor

        public ArtistContactRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IArtistContact>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IArtistContact GetById(int id)
        {
            IArtistContact artistContact = new ArtistContact();

            string sqlCommand = "artistContactFind";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" idArtistContact={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        artistContact.IdArtistContact = Convert.ToInt32(reader["idArtistContact"].ToString());
                        artistContact.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        artistContact.Email = reader["email"].ToString();
                        artistContact.Facebook = reader["facebook"].ToString();
                        artistContact.Soundcloud = reader["soundcloud"].ToString();
                        artistContact.Tumblr = reader["tumblr"].ToString();
                        artistContact.Twitter = reader["twitter"].ToString();
                        artistContact.Website = reader["website"].ToString();
                        artistContact.Bandcamp = reader["bandcamp"].ToString();
                    }
                }
            }
            return artistContact;
        }

        #endregion GetById( int id )

        #region GetTop<IArtistQueryParams>(int top,IArtistQueryParams query )

        public IList<IArtistContact> GetTop<IArtistQueryParams>(int top, IArtistQueryParams query)
        {
            _collection = new List<IArtistContact>();

            string sqlCommand = "artistContactGetTop";

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
                        IArtistContact artistContact = new ArtistContact();

                        artistContact.IdArtistContact = Convert.ToInt32(reader["idArtistContact"].ToString());
                        artistContact.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        artistContact.Email = reader["email"].ToString();
                        artistContact.Facebook = reader["facebook"].ToString();
                        artistContact.Soundcloud = reader["soundcloud"].ToString();
                        artistContact.Tumblr = reader["tumblr"].ToString();
                        artistContact.Twitter = reader["twitter"].ToString();
                        artistContact.Website = reader["website"].ToString();
                        artistContact.Bandcamp = reader["bandcamp"].ToString();
                        _collection.Add(artistContact);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IArtistQueryParams>(int top,IArtistQueryParams query )

        #region Find<IArtistQueryParams>( IArtistQueryParams query )

        public IList<IArtistContact> Find<IArtistQueryParams>(IArtistQueryParams query)
        {
            _collection = new List<IArtistContact>();
            string sqlCommand = "artistContactFind";

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
                        IArtistContact artistContact = new ArtistContact();

                        artistContact.IdArtistContact = Convert.ToInt32(reader["idArtistContact"].ToString());
                        artistContact.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        artistContact.Email = reader["email"].ToString();
                        artistContact.Facebook = reader["facebook"].ToString();
                        artistContact.Soundcloud = reader["soundcloud"].ToString();
                        artistContact.Tumblr = reader["tumblr"].ToString();
                        artistContact.Twitter = reader["twitter"].ToString();
                        artistContact.Website = reader["website"].ToString();
                        artistContact.Bandcamp = reader["bandcamp"].ToString();
                        _collection.Add(artistContact);
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

        #region Add( IArtistContact )

        public IArtistContact Add(IArtistContact artistContact)
        {
            int id = 0;
            string sqlCommand = "artistContactAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@artistId", DbType.Int32, artistContact.ArtistId);
                _dataBase.AddInParameter(dbCmd, "@bandcamp", DbType.String, artistContact.Bandcamp);
                _dataBase.AddInParameter(dbCmd, "@website", DbType.String, artistContact.Website);
                _dataBase.AddInParameter(dbCmd, "@facebook", DbType.String, artistContact.Facebook);
                _dataBase.AddInParameter(dbCmd, "@tumblr", DbType.String, artistContact.Tumblr);
                _dataBase.AddInParameter(dbCmd, "@email", DbType.String, artistContact.Email);
                _dataBase.AddInParameter(dbCmd, "@soundcloud", DbType.String, artistContact.Soundcloud);
                _dataBase.AddInParameter(dbCmd, "@twitter", DbType.String, artistContact.Twitter);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));
                artistContact = this.GetById(id);
            }

            return artistContact;
        }

        #endregion Add( IArtistContact )

        #region Update( IArtistContact )

        public IArtistContact Update(IArtistContact artist)
        {
            IArtistContact artistContactUpdated = new ArtistContact();
            string sqlCommand = "artistUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@idartistcontact", DbType.Int32, artistContactUpdated.IdArtistContact);
                _dataBase.AddInParameter(dbCmd, "@artistId", DbType.Int32, artistContactUpdated.ArtistId);
                _dataBase.AddInParameter(dbCmd, "@bandcamp", DbType.String, artistContactUpdated.Bandcamp);
                _dataBase.AddInParameter(dbCmd, "@website", DbType.String, artistContactUpdated.Website);
                _dataBase.AddInParameter(dbCmd, "@facebook", DbType.String, artistContactUpdated.Facebook);
                _dataBase.AddInParameter(dbCmd, "@tumblr", DbType.String, artistContactUpdated.Tumblr);
                _dataBase.AddInParameter(dbCmd, "@email", DbType.String, artistContactUpdated.Email);
                _dataBase.AddInParameter(dbCmd, "@soundcloud", DbType.String, artistContactUpdated.Soundcloud);
                _dataBase.AddInParameter(dbCmd, "@twitter", DbType.String, artistContactUpdated.Twitter);

                _dataBase.ExecuteScalar(dbCmd);
                artistContactUpdated = this.GetById(artist.ArtistId);
            }

            return artistContactUpdated;
        }

        #endregion Update( IArtistContact )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;

            string sqlCommand = "artistContactRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@idartistContact", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IArtistContact> Collection
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