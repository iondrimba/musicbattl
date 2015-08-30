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
    public class ProfileRepository : IRepository<IProfile>
    {
        private Database _dataBase;
        private IList<IProfile> _collection;

        #region Constructor

        public ProfileRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IProfile>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IProfile GetById(int id)
        {
            IProfile profile = new Profile();
            string sqlCommand = "profileFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" profileId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        profile.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        profile.UserId = Convert.ToInt32(reader["userId"].ToString());
                        profile.Picture = reader["picture"].ToString();
                        profile.Upadted = (DateTime)reader["upadted"];
                        profile.Removed = Convert.ToBoolean(reader["removed"].ToString());
                    }
                }
            }

            return profile;
        }

        #endregion GetById( int id )

        #region GetTop<IProfileQueryParams>(int top,IProfileQueryParams query )

        public IList<IProfile> GetTop<IProfileQueryParams>(int top, IProfileQueryParams query)
        {
            _collection = new List<IProfile>();
            string sqlCommand = "profileGetTop";

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
                        IProfile profile = new Profile();

                        profile.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        profile.UserId = Convert.ToInt32(reader["userId"].ToString());
                        profile.Picture = reader["picture"].ToString();
                        profile.Upadted = (DateTime)reader["upadted"];
                        profile.Removed = Convert.ToBoolean(reader["removed"].ToString());
                        _collection.Add(profile);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IProfileQueryParams>(int top,IProfileQueryParams query )

        #region Find<IProfileQueryParams>( IProfileQueryParams query )

        public IList<IProfile> Find<IProfileQueryParams>(IProfileQueryParams query)
        {
            _collection = new List<IProfile>();
            string sqlCommand = "profileFind";

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
                        IProfile profile = new Profile();

                        profile.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        profile.UserId = Convert.ToInt32(reader["userId"].ToString());
                        profile.Picture = reader["picture"].ToString();
                        profile.Upadted = (DateTime)reader["upadted"];
                        profile.Removed = Convert.ToBoolean(reader["removed"].ToString());
                        _collection.Add(profile);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IProfileQueryParams>( IProfileQueryParams query )

        #region Count<IProfileQueryParams>( IProfileQueryParams query )

        public int Count<IProfileQueryParams>(IProfileQueryParams query)
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

        #endregion Count<IProfileQueryParams>( IProfileQueryParams query )

        #region Sum<IProfileQueryParams>( IProfileQueryParams query )

        public decimal Sum<IProfileQueryParams>(IProfileQueryParams query)
        {
            decimal sum = 0;
            string sqlCommand = "sumByParams";
            // Create a suitable command type and add the required parameter.
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "fromParam", DbType.String, ((IDataQuery)query).From);
                _dataBase.AddInParameter(dbCmd, "whereParam", DbType.String, ((IDataQuery)query).Where);
                _dataBase.AddInParameter(dbCmd, "columnParam", DbType.String, ((IDataQuery)query).Column);

                sum = Convert.ToDecimal(_dataBase.ExecuteScalar(dbCmd));
            }

            return sum;
        }

        #endregion Sum<IProfileQueryParams>( IProfileQueryParams query )

        #region Add( IProfile )

        public IProfile Add(IProfile profile)
        {
            IProfile profileAdded = new Profile();
            int id = 0;
            string sqlCommand = "profileAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@userId", DbType.Int32, profile.UserId);
                _dataBase.AddInParameter(dbCmd, "@picture", DbType.String, profile.Picture);
                _dataBase.AddInParameter(dbCmd, "@upadted", DbType.DateTime, profile.Upadted);
                _dataBase.AddInParameter(dbCmd, "@removed", DbType.Boolean, profile.Removed);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));

                profileAdded = this.GetById(id);
            }

            return profileAdded;
        }

        #endregion Add( IProfile )

        #region Update( IProfile )

        public IProfile Update(IProfile profile)
        {
            IProfile profileUpdated = new Profile();
            string sqlCommand = "profileUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@profileId", DbType.Int32, profile.ProfileId);
                _dataBase.AddInParameter(dbCmd, "@userId", DbType.Int32, profile.UserId);
                _dataBase.AddInParameter(dbCmd, "@picture", DbType.String, profile.Picture);
                _dataBase.AddInParameter(dbCmd, "@upadted", DbType.DateTime, profile.Upadted);
                _dataBase.AddInParameter(dbCmd, "@removed", DbType.Boolean, profile.Removed);
                _dataBase.ExecuteScalar(dbCmd);

                profileUpdated = this.GetById(profile.ProfileId);
            }

            return profileUpdated;
        }

        #endregion Update( IProfile )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;
            string sqlCommand = "profileRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@profileId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IProfile> Collection
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