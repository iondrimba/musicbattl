using Microsoft.Practices.EnterpriseLibrary.Data;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace MusicBattlDAL
{
    public class ViewGenderTotalRepository : IRepository<IViewGenderTotal>
    {
        private Database _dataBase;
        private IList<IViewGenderTotal> _collection;

        #region Constructor

        public ViewGenderTotalRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewGenderTotal>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewGenderTotal GetById(int id)
        {
            string message = "IViewGenderTotal GetById not implemented";
            throw new NotImplementedException(message);
        }

        #endregion GetById( int id )

        #region GetTop<IViewGenderTotalQueryParams>(int top,IViewGenderTotalQueryParams query )

        public IList<IViewGenderTotal> GetTop<IViewGenderTotalQueryParams>(int top, IViewGenderTotalQueryParams query)
        {
            string message = "IViewGenderTotal GetTop not implemented";
            throw new NotImplementedException(message);
        }

        #endregion GetTop<IViewGenderTotalQueryParams>(int top,IViewGenderTotalQueryParams query )

        #region Find<IViewGenderTotalQueryParams>( IViewGenderTotalQueryParams query )

        public IList<IViewGenderTotal> Find<IViewGenderTotalQueryParams>(IViewGenderTotalQueryParams query)
        {
            _collection = new List<IViewGenderTotal>();
            string sqlCommand = "viewGenderTotalFind";
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
                        IViewGenderTotal viewGenderTotal = new ViewGenderTotal();
                        viewGenderTotal.Total = Convert.ToInt32(reader["total"].ToString());
                        viewGenderTotal.TotalFemale = Convert.ToInt32(reader["totalFemale"].ToString());
                        viewGenderTotal.TotalMale = Convert.ToInt32(reader["totalMale"].ToString());

                        _collection.Add(viewGenderTotal);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewGenderTotalQueryParams>( IViewGenderTotalQueryParams query )

        #region Count<IViewGenderTotalQueryParams>( IViewGenderTotalQueryParams query )

        public int Count<IViewGenderTotalQueryParams>(IViewGenderTotalQueryParams query)
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

        #endregion Count<IViewGenderTotalQueryParams>( IViewGenderTotalQueryParams query )

        #region Sum<IViewGenderTotalQueryParams>( IViewGenderTotalQueryParams query )

        public decimal Sum<IViewGenderTotalQueryParams>(IViewGenderTotalQueryParams query)
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

        #endregion Sum<IViewGenderTotalQueryParams>( IViewGenderTotalQueryParams query )

        #region Add( IViewGenderTotal )

        public IViewGenderTotal Add(IViewGenderTotal viewGenderTotal)
        {
            string message = "IViewGenderTotal Add not supported";
            throw new NotSupportedException(message);
        }

        #endregion Add( IViewGenderTotal )

        #region Update( IViewGenderTotal )

        public IViewGenderTotal Update(IViewGenderTotal viewGenderTotal)
        {
            string message = "IViewGenderTotal Update not supported";
            throw new NotSupportedException(message);
        }

        #endregion Update( IViewGenderTotal )

        #region Remove( id)

        public bool Remove(int id)
        {
            string message = "IViewGenderTotal Remove not supported";
            throw new NotSupportedException(message);
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewGenderTotal> Collection
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