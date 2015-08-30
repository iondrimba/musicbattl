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
    public class SocialRepository : IRepository<ISocial>
    {
        private Database _dataBase;
        private IList<ISocial> _collection;

        #region Constructor

        public SocialRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<ISocial>();
        }

        #endregion Constructor

        #region GetById( int id )

        public ISocial GetById(int id)
        {
            ISocial social = new Social();
            string sqlCommand = "socialFind";
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
                        social.SocialId = Convert.ToInt32(reader["socialId"].ToString());
                        social.UserId = Convert.ToInt32(reader["userId"].ToString());
                        social.SocialTypeId = Convert.ToInt32(reader["socialTypeId"].ToString());
                    }
                }
            }

            return social;
        }

        #endregion GetById( int id )

        #region GetTop<ISocialQueryParams>(int top,ISocialQueryParams query )

        public IList<ISocial> GetTop<ISocialQueryParams>(int top, ISocialQueryParams query)
        {
            _collection = new List<ISocial>();
            string sqlCommand = "socialGetTop";
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
                        ISocial social = new Social();

                        social.SocialId = Convert.ToInt32(reader["socialId"].ToString());
                        social.UserId = Convert.ToInt32(reader["userId"].ToString());
                        social.SocialTypeId = Convert.ToInt32(reader["socialTypeId"].ToString());
                        _collection.Add(social);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<ISocialQueryParams>(int top,ISocialQueryParams query )

        #region Find<ISocialQueryParams>( ISocialQueryParams query )

        public IList<ISocial> Find<ISocialQueryParams>(ISocialQueryParams query)
        {
            _collection = new List<ISocial>();
            string sqlCommand = "socialFind";
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
                        ISocial social = new Social();

                        social.SocialId = Convert.ToInt32(reader["socialId"].ToString());
                        social.UserId = Convert.ToInt32(reader["userId"].ToString());
                        social.SocialTypeId = Convert.ToInt32(reader["socialTypeId"].ToString());
                        _collection.Add(social);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<ISocialQueryParams>( ISocialQueryParams query )

        #region Count<ISocialQueryParams>( ISocialQueryParams query )

        public int Count<ISocialQueryParams>(ISocialQueryParams query)
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

        #endregion Count<ISocialQueryParams>( ISocialQueryParams query )

        #region Sum<ISocialQueryParams>( ISocialQueryParams query )

        public decimal Sum<ISocialQueryParams>(ISocialQueryParams query)
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

        #endregion Sum<ISocialQueryParams>( ISocialQueryParams query )

        #region Add( ISocial )

        public ISocial Add(ISocial social)
        {
            ISocial retorno = new Social();
            int id = 0;

            ISocial socialAdded = new Social();
            string sqlCommand = "socialAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@userId", DbType.Int32, social.UserId);
                _dataBase.AddInParameter(dbCmd, "@socialTypeId", DbType.Int32, social.SocialTypeId);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));

                socialAdded = this.GetById(id);
            }

            return socialAdded;
        }

        #endregion Add( ISocial )

        #region Update( ISocial )

        public ISocial Update(ISocial social)
        {
            ISocial socialUpdated = new Social();
            string sqlCommand = "socialUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@socialId", DbType.Int32, social.SocialId);
                _dataBase.AddInParameter(dbCmd, "@userId", DbType.Int32, social.UserId);
                _dataBase.AddInParameter(dbCmd, "@socialTypeId", DbType.Int32, social.SocialTypeId);

                _dataBase.ExecuteScalar(dbCmd);

                socialUpdated = this.GetById(social.SocialId);
            }

            return socialUpdated;
        }

        #endregion Update( ISocial )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;

            string sqlCommand = "socialRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@socialId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<ISocial> Collection
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