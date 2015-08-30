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
    public class BattlRepository : IRepository<IBattl>
    {
        private Database _dataBase;
        private IList<IBattl> _collection;

        public Database DataBase
        {
            get { return _dataBase; }
            set { _dataBase = value; }
        }

        #region Constructor

        public BattlRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IBattl>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IBattl GetById(int id)
        {
            IBattl battl = new Battl();
            string sqlCommand = "battlFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" battlId = {0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        battl.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        battl.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        battl.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        battl.StartTime = (DateTime)reader["startTime"];
                        battl.EndTime = (DateTime)reader["endTime"];
                        battl.BattlDate = (DateTime)reader["battlDate"];
                    }
                }
            }

            return battl;
        }

        #endregion GetById( int id )

        #region GetTop<IBattlQueryParams>(int top,IBattlQueryParams query )

        public IList<IBattl> GetTop<IBattlQueryParams>(int top, IBattlQueryParams query)
        {
            _collection = new List<IBattl>();
            string sqlCommand = "battlGetTop";

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
                        IBattl battl = new Battl();

                        battl.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        battl.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        battl.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        battl.StartTime = (DateTime)reader["startTime"];
                        battl.EndTime = (DateTime)reader["endTime"];
                        battl.BattlDate = (DateTime)reader["battlDate"];
                        _collection.Add(battl);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IBattlQueryParams>(int top,IBattlQueryParams query )

        #region Find<IBattlQueryParams>( IBattlQueryParams query )

        public IList<IBattl> Find<IBattlQueryParams>(IBattlQueryParams query)
        {
            _collection = new List<IBattl>();
            string sqlCommand = "battlFind";

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
                        IBattl battl = new Battl();

                        battl.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        battl.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        battl.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        battl.StartTime = (DateTime)reader["startTime"];
                        battl.EndTime = (DateTime)reader["endTime"];
                        battl.BattlDate = (DateTime)reader["battlDate"];
                        battl.Active = Convert.ToBoolean(reader["active"].ToString());
                        _collection.Add(battl);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IBattlQueryParams>( IBattlQueryParams query )

        #region Count<IBattlQueryParams>( IBattlQueryParams query )

        public int Count<IBattlQueryParams>(IBattlQueryParams query)
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

        #endregion Count<IBattlQueryParams>( IBattlQueryParams query )

        #region Sum<IBattlQueryParams>( IBattlQueryParams query )

        public decimal Sum<IBattlQueryParams>(IBattlQueryParams query)
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

        #endregion Sum<IBattlQueryParams>( IBattlQueryParams query )

        #region Add( IBattl )

        public IBattl Add(IBattl battl)
        {
            IBattl battlAdded = new Battl();
            int id = 0;
            string sqlCommand = "battlAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@firstSongId", DbType.Int32, battl.FirstSongId);
                _dataBase.AddInParameter(dbCmd, "@secondSongId", DbType.Int32, battl.SecondSongId);
                _dataBase.AddInParameter(dbCmd, "@startTime", DbType.DateTime, battl.StartTime);
                _dataBase.AddInParameter(dbCmd, "@endTime", DbType.DateTime, battl.EndTime);
                _dataBase.AddInParameter(dbCmd, "@battlDate", DbType.DateTime, battl.BattlDate);
                _dataBase.AddInParameter(dbCmd, "@active", DbType.Int32, battl.Active ? 1 : 0);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));

                battlAdded = this.GetById(id);
            }

            return battlAdded;
        }

        #endregion Add( IBattl )

        #region Update( IBattl )

        public IBattl Update(IBattl battl)
        {
            IBattl battlUpdated = new Battl();
            string sqlCommand = "battlUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@battlId", DbType.Int32, battl.BattlId);
                _dataBase.AddInParameter(dbCmd, "@firstSongId", DbType.Int32, battl.FirstSongId);
                _dataBase.AddInParameter(dbCmd, "@secondSongId", DbType.Int32, battl.SecondSongId);
                _dataBase.AddInParameter(dbCmd, "@startTime", DbType.DateTime, battl.StartTime);
                _dataBase.AddInParameter(dbCmd, "@endTime", DbType.DateTime, battl.EndTime);
                _dataBase.AddInParameter(dbCmd, "@battlDate", DbType.DateTime, battl.BattlDate);
                _dataBase.AddInParameter(dbCmd, "@active", DbType.Int32, battl.Active ? 1 : 0);

                _dataBase.ExecuteScalar(dbCmd);

                battlUpdated = this.GetById(battlUpdated.BattlId);
            }

            return battlUpdated;
        }

        #endregion Update( IBattl )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;
            string sqlCommand = "battlRemove";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@battlId", DbType.Int32, id);
                int rowsAffected = _dataBase.ExecuteNonQuery(dbCmd);

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IBattl> Collection
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