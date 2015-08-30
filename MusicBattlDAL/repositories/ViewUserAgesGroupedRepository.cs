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
    public class ViewUserAgesRepository : IRepository<IViewUserAges>
    {
        private IList<IViewUserAges> _collection;
        private Database _dataBase;

        #region Constructor

        public ViewUserAgesRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewUserAges>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewUserAges GetById(int id)
        {
            IViewUserAges viewUserAges = new ViewUserAges();
            string sqlCommand = "ViewUserAgesFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" viewUserBattlResultId = {0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewUserAges.Age = Convert.ToInt32(reader["age"].ToString());
                    }
                }
            }

            return viewUserAges;
        }

        #endregion GetById( int id )

        #region GetTop<IViewUserAgesQueryParams>(int top,IViewUserAgesQueryParams query )

        public IList<IViewUserAges> GetTop<IViewUserAgesQueryParams>(int top, IViewUserAgesQueryParams query)
        {
            _collection = new List<IViewUserAges>();
            string sqlCommand = "ViewUserAgesGetTop";
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
                        IViewUserAges ViewUserAges = new ViewUserAges();

                        ViewUserAges.Age = Convert.ToInt32(reader["age"].ToString());
                        _collection.Add(ViewUserAges);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewUserAgesQueryParams>(int top,IViewUserAgesQueryParams query )

        #region Find<IViewUserAgesQueryParams>( IViewUserAgesQueryParams query )

        public IList<IViewUserAges> Find<IViewUserAgesQueryParams>(IViewUserAgesQueryParams query)
        {
            _collection = new List<IViewUserAges>();
            string sqlCommand = "ViewUserAgesFind";

            // Create a suitable command type and add the required parameter.
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                 // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        IViewUserAges ViewUserAges = new ViewUserAges();

                        ViewUserAges.Age = Convert.ToInt32(reader["age"].ToString());
                        _collection.Add(ViewUserAges);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewUserAgesQueryParams>( IViewUserAgesQueryParams query )

        #region Count<IViewUserAgesQueryParams>( IViewUserAgesQueryParams query )

        public int Count<IViewUserAgesQueryParams>(IViewUserAgesQueryParams query)
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

        #endregion Count<IViewUserAgesQueryParams>( IViewUserAgesQueryParams query )

        #region Sum<IViewUserAgesQueryParams>( IViewUserAgesQueryParams query )

        public decimal Sum<IViewUserAgesQueryParams>(IViewUserAgesQueryParams query)
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

        #endregion Sum<IViewUserAgesQueryParams>( IViewUserAgesQueryParams query )

        #region Add( IViewUserAges )

        public IViewUserAges Add(IViewUserAges ViewUserAges)
        {
            string message = "IViewUserAges Add not supported";
            throw new NotSupportedException(message);
        }

        #endregion Add( IViewUserAges )

        #region Update( IViewUserAges )

        public IViewUserAges Update(IViewUserAges ViewUserAges)
        {
            string message = "IViewUserAges update not supported";
            throw new NotSupportedException(message);
        }

        #endregion Update( IViewUserAges )

        #region Remove( id)

        public bool Remove(int id)
        {
            string message = "IViewUserAges remove not supported";
            throw new NotSupportedException(message);
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewUserAges> Collection
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