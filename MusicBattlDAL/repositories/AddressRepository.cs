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
    public class AddressRepository : IRepository<IAddress>
    {
        private Database _dataBase;
        private IList<IAddress> _collection;

        #region Constructor

        public AddressRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IAddress>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IAddress GetById(int id)
        {
            IAddress address = new Address();
            string sqlCommand = "addressFind";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" addressId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        address.AddressId = Convert.ToInt32(reader["addressId"].ToString());
                        address.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        address.Country = reader["country"].ToString();
                        address.City = reader["city"].ToString();
                    }
                }
            }

            return address;
        }

        #endregion GetById( int id )

        #region GetTop<IAddressQueryParams>(int top,IAddressQueryParams query )

        public IList<IAddress> GetTop<IAddressQueryParams>(int top, IAddressQueryParams query)
        {
            _collection = new List<IAddress>();
            string sqlCommand = "addressGetTop";
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
                        IAddress address = new Address();

                        address.AddressId = Convert.ToInt32(reader["addressId"].ToString());
                        address.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        address.Country = reader["country"].ToString();
                        address.City = reader["city"].ToString();
                        _collection.Add(address);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IAddressQueryParams>(int top,IAddressQueryParams query )

        #region Find<IAddressQueryParams>( IAddressQueryParams query )

        public IList<IAddress> Find<IAddressQueryParams>(IAddressQueryParams query)
        {
            _collection = new List<IAddress>();
            string sqlCommand = "addressFind";

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
                        IAddress address = new Address();

                        address.AddressId = Convert.ToInt32(reader["addressId"].ToString());
                        address.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        address.Country = reader["country"].ToString();
                        address.City = reader["city"].ToString();
                        _collection.Add(address);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IAddressQueryParams>( IAddressQueryParams query )

        #region Count<IAddressQueryParams>( IAddressQueryParams query )

        public int Count<IAddressQueryParams>(IAddressQueryParams query)
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

        #endregion Count<IAddressQueryParams>( IAddressQueryParams query )

        #region Sum<IAddressQueryParams>( IAddressQueryParams query )

        public decimal Sum<IAddressQueryParams>(IAddressQueryParams query)
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

        #endregion Sum<IAddressQueryParams>( IAddressQueryParams query )

        #region Add( IAddress )

        public IAddress Add(IAddress address)
        {
            IAddress addressAdded = new Address();
            int id = 0;
            string sqlCommand = "addressAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@profileId", DbType.Int32, address.ProfileId);
                _dataBase.AddInParameter(dbCmd, "@country", DbType.String, address.Country);
                _dataBase.AddInParameter(dbCmd, "@city", DbType.String, address.City);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));
                addressAdded = this.GetById(id);
            }

            return addressAdded;
        }

        #endregion Add( IAddress )

        #region Update( IAddress )

        public IAddress Update(IAddress address)
        {
            IAddress addressUpdated = new Address();
            string sqlCommand = "addressAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@addressId", DbType.Int32, address.AddressId);
                _dataBase.AddInParameter(dbCmd, "@profileId", DbType.Int32, address.ProfileId);
                _dataBase.AddInParameter(dbCmd, "@country", DbType.String, address.Country);
                _dataBase.AddInParameter(dbCmd, "@city", DbType.String, address.City);

                _dataBase.ExecuteScalar(dbCmd);
                addressUpdated = this.GetById(address.AddressId);
            }

            return addressUpdated;
        }

        #endregion Update( IAddress )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;

            string sqlCommand = "addressRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@addressId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IAddress> Collection
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