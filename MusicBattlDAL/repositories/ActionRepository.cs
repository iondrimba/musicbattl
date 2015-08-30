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
    public class ActionRepository : IRepository<IAction>
    {
        private IList<IAction> _collection;
        private Database _dataBase;

        #region Constructor

        public ActionRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IAction>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IAction GetById(int id)
        {
            IAction action = new Action();
            string sqlCommand = "actionFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" actionId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        action.ActionId = Convert.ToInt32(reader["actionId"].ToString());
                        action.Name = reader["name"].ToString();
                    }
                }
            }

            return action;
        }

        #endregion GetById( int id )

        #region GetTop<IActionQueryParams>(int top,IActionQueryParams query )

        public IList<IAction> GetTop<IActionQueryParams>(int top, IActionQueryParams query)
        {
            _collection = new List<IAction>();
            string sqlCommand = "actionGetTop";

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
                        IAction action = new Action();

                        action.ActionId = Convert.ToInt32(reader["actionId"].ToString());
                        action.Name = reader["name"].ToString();
                        _collection.Add(action);
                    }
                }
            }
            return _collection;
        }

        #endregion GetTop<IActionQueryParams>(int top,IActionQueryParams query )

        #region Find<IActionQueryParams>( IActionQueryParams query )

        public IList<IAction> Find<IActionQueryParams>(IActionQueryParams query)
        {
            _collection = new List<IAction>();
            string sqlCommand = "actionFind";

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
                        IAction action = new Action();

                        action.ActionId = Convert.ToInt32(reader["actionId"].ToString());
                        action.Name = reader["name"].ToString();
                        _collection.Add(action);
                    }
                }
            }
            return _collection;
        }

        #endregion Find<IActionQueryParams>( IActionQueryParams query )

        #region Count<IActionQueryParams>( IActionQueryParams query )

        public int Count<IActionQueryParams>(IActionQueryParams query)
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

        #endregion Count<IActionQueryParams>( IActionQueryParams query )

        #region Sum<IActionQueryParams>( IActionQueryParams query )

        public decimal Sum<IActionQueryParams>(IActionQueryParams query)
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

        #endregion Sum<IActionQueryParams>( IActionQueryParams query )

        #region Add( IAction )

        public IAction Add(IAction action)
        {
            IAction actionAdded = new Action();
            int id = 0;
            string sqlCommand = "actionAdd";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, action.Name);
                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));
                actionAdded = this.GetById(id);
            }
            return actionAdded;
        }

        #endregion Add( IAction )

        #region Update( IAction )

        public IAction Update(IAction action)
        {
            IAction actionUpdated = new Action();
            string sqlCommand = "actionUpdate";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@actionId", DbType.Int32, action.ActionId);
                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, action.Name);
                _dataBase.ExecuteScalar(dbCmd);
                actionUpdated = this.GetById(action.ActionId);
            }

            return actionUpdated;
        }

        #endregion Update( IAction )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;

            string sqlCommand = "actionRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@actionId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IAction> Collection
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