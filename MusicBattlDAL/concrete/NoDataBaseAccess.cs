using System;
using System.Collections.Generic;
using System.Data;
using MusicBattlDAL.interfaces;

namespace MusicBattlDAL.concrete
{
    public class NoDataBaseAccess<T> : IDataBaseAccess
    {
        private IEnumerable<T> _data;

        public NoDataBaseAccess( IList<T> data )
        {
            _data = new List<T>();
            _data = data;
        }

        #region IDataBaseAccess Members

        public System.Data.IDbConnection GetConnection()
        {
            throw new NotImplementedException();
        }

        public System.Data.IDbCommand GetCommand( string text , System.Data.CommandType type )
        {
            throw new NotImplementedException();
        }

        public void AddParameter( string name , object value )
        {
            throw new NotImplementedException();
        }

        public IDbConnection Connect( string connectionString )
        {
            return null;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetMockData<T>()
        {
            return (IEnumerable<T>)_data;
        }

        #endregion IDataBaseAccess Members

        #region IDataBaseAccess Members

        public string ConnectionString
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IDbConnection Connect()
        {
            throw new NotImplementedException();
        }

        #endregion IDataBaseAccess Members
    }
}