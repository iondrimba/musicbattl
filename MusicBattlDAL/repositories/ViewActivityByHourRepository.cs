using System;
using System.Collections.Generic;
using System.Data;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace MusicBattlDAL
{
    public class ViewActivityByHourRepository : IRepository<IViewActivityByHour>
    {
        private IList<IViewActivityByHour> _collection;
        private Database _dataBase;

        #region Constructor

        public ViewActivityByHourRepository( Database pDataBaseAccess )
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewActivityByHour>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewActivityByHour GetById( int id )
        {
            IViewActivityByHour viewActivityByHour = new ViewActivityByHour();
            string sqlCommand = "viewActivityByHourFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewActivityByHour.Hour = Convert.ToInt32(reader["hour"].ToString());
                        viewActivityByHour.TotalByHour = Convert.ToInt32(reader["totalByHour"].ToString());
                    }
                }
            }

            return viewActivityByHour;
        }

        #endregion GetById( int id )

        #region GetTop<IViewActivityByHourQueryParams>(int top,IViewActivityByHourQueryParams query )

        public IList<IViewActivityByHour> GetTop<IViewActivityByHourQueryParams>( int top , IViewActivityByHourQueryParams query )
        {
            _collection = new List<IViewActivityByHour>();
            string sqlCommand = "viewActivityByHourGetTop";
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
                        IViewActivityByHour viewActivityByHour = new ViewActivityByHour();

                        viewActivityByHour.Hour = Convert.ToInt32(reader["hour"].ToString());
                        viewActivityByHour.TotalByHour = Convert.ToInt32(reader["totalByHour"].ToString());
                        _collection.Add(viewActivityByHour);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewActivityByHourQueryParams>(int top,IViewActivityByHourQueryParams query )

        #region Find<IViewActivityByHourQueryParams>( IViewActivityByHourQueryParams query )

        public IList<IViewActivityByHour> Find<IViewActivityByHourQueryParams>( IViewActivityByHourQueryParams query )
        {
            _collection = new List<IViewActivityByHour>();
            string sqlCommand = "viewActivityByHourFind";

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
                        IViewActivityByHour viewActivityByHour = new ViewActivityByHour();

                        viewActivityByHour.Hour = Convert.ToInt32(reader["hour"].ToString());
                        viewActivityByHour.TotalByHour = Convert.ToInt32(reader["totalByHour"].ToString());
                        _collection.Add(viewActivityByHour);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewActivityByHourQueryParams>( IViewActivityByHourQueryParams query )

        #region Count<IViewActivityByHourQueryParams>( IViewActivityByHourQueryParams query )

        public int Count<IViewActivityByHourQueryParams>( IViewActivityByHourQueryParams query )
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

        #endregion Count<IViewActivityByHourQueryParams>( IViewActivityByHourQueryParams query )

        #region Sum<IViewActivityByHourQueryParams>( IViewActivityByHourQueryParams query )

        public decimal Sum<IViewActivityByHourQueryParams>( IViewActivityByHourQueryParams query )
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

        #endregion Sum<IViewActivityByHourQueryParams>( IViewActivityByHourQueryParams query )

        #region Add( IViewActivityByHour )

        public IViewActivityByHour Add( IViewActivityByHour viewActivityByHour )
        {
            string message = "IViewActivityByHour Add not supported";
            throw new NotSupportedException(message);
        }

        #endregion Add( IViewActivityByHour )

        #region Update( IViewActivityByHour )

        public IViewActivityByHour Update( IViewActivityByHour viewActivityByHour )
        {
            string message = "IViewActivityByHour Update not supported";
            throw new NotSupportedException(message);
        }

        #endregion Update( IViewActivityByHour )

        #region Remove( id)

        public bool Remove( int id )
        {
            string message = "IViewActivityByHour Remove not supported";
            throw new NotSupportedException(message);

        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewActivityByHour> Collection
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