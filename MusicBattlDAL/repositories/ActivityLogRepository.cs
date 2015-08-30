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
    public class ActivityLogRepository : IRepository<IActivityLog>
    {
        private Database _dataBase;
        private IList<IActivityLog> _collection;

        #region Constructor

        public ActivityLogRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IActivityLog>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IActivityLog GetById(int id)
        {
            IActivityLog activityLog = new ActivityLog();
            string sqlCommand = "activityLogFind";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" activityLogId = {0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        activityLog.ActivityLogId = Convert.ToInt32(reader["activityLogId"].ToString());
                        activityLog.UserId = Convert.ToInt32(reader["userId"].ToString());
                        activityLog.ActionId = Convert.ToInt32(reader["actionId"].ToString());
                        activityLog.Date = (DateTime)reader["data"];
                    }
                }
            }

            return activityLog;
        }

        #endregion GetById( int id )

        #region GetTop<IActivityLogQueryParams>(int top,IActivityLogQueryParams query )

        public IList<IActivityLog> GetTop<IActivityLogQueryParams>(int top, IActivityLogQueryParams query)
        {
            _collection = new List<IActivityLog>();
            string sqlCommand = "activityLogGetTop";
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
                        IActivityLog activityLog = new ActivityLog();

                        activityLog.ActivityLogId = Convert.ToInt32(reader["activityLogId"].ToString());
                        activityLog.UserId = Convert.ToInt32(reader["userId"].ToString());
                        activityLog.ActionId = Convert.ToInt32(reader["actionId"].ToString());
                        activityLog.Date = (DateTime)reader["date"];
                        _collection.Add(activityLog);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IActivityLogQueryParams>(int top,IActivityLogQueryParams query )

        #region Find<IActivityLogQueryParams>( IActivityLogQueryParams query )

        public IList<IActivityLog> Find<IActivityLogQueryParams>(IActivityLogQueryParams query)
        {
            _collection = new List<IActivityLog>();
            string sqlCommand = "activityLogFind";
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
                        IActivityLog activityLog = new ActivityLog();

                        activityLog.ActivityLogId = Convert.ToInt32(reader["activityLogId"].ToString());
                        activityLog.UserId = Convert.ToInt32(reader["userId"].ToString());
                        activityLog.ActionId = Convert.ToInt32(reader["actionId"].ToString());
                        activityLog.Date = (DateTime)reader["data"];
                        _collection.Add(activityLog);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IActivityLogQueryParams>( IActivityLogQueryParams query )

        #region Count<IActivityLogQueryParams>( IActivityLogQueryParams query )

        public int Count<IActivityLogQueryParams>(IActivityLogQueryParams query)
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

        #endregion Count<IActivityLogQueryParams>( IActivityLogQueryParams query )

        #region Sum<IActivityLogQueryParams>( IActivityLogQueryParams query )

        public decimal Sum<IActivityLogQueryParams>(IActivityLogQueryParams query)
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

        #endregion Sum<IActivityLogQueryParams>( IActivityLogQueryParams query )

        #region Add( IActivityLog )

        public IActivityLog Add(IActivityLog activityLog)
        {
            IActivityLog activityLogAdded = new ActivityLog();
            int id = 0;
            string sqlCommand = "activityLogAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@userId", DbType.Int32, activityLog.UserId);
                _dataBase.AddInParameter(dbCmd, "@actionId", DbType.Int32, activityLog.ActionId);
                _dataBase.AddInParameter(dbCmd, "@data", DbType.DateTime, activityLog.Date);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));

                activityLogAdded = this.GetById(id);
            }

            return activityLogAdded;
        }

        #endregion Add( IActivityLog )

        #region Update( IActivityLog )

        public IActivityLog Update(IActivityLog activityLog)
        {
            IActivityLog activityLogUpdated = new ActivityLog();
            string sqlCommand = "activityLogUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@activityLogId", DbType.Int32, activityLog.ActivityLogId);
                _dataBase.AddInParameter(dbCmd, "@userId", DbType.Int32, activityLog.UserId);
                _dataBase.AddInParameter(dbCmd, "@actionId", DbType.Int32, activityLog.ActionId);
                _dataBase.AddInParameter(dbCmd, "@data", DbType.DateTime, activityLog.Date);

                _dataBase.ExecuteScalar(dbCmd);

                activityLogUpdated = this.GetById(activityLog.ActivityLogId);
            }
            return activityLogUpdated;
        }

        #endregion Update( IActivityLog )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;

            string sqlCommand = "activityLogRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@activityLogId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IActivityLog> Collection
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