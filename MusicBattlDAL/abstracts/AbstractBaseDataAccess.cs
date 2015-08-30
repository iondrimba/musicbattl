using System;
using System.Collections.Generic;
using System.Data;
using MusicBattlDAL.interfaces;

namespace MusicBattlDAL.abstracts
{
    public abstract class AbstractDataBaseAccess : IDataBaseAccess
    {
        #region IDataBaseAcces Members

        #region Properties

        protected IDbConnection _connection;
        protected IDbCommand _command;
        protected IDataParameter _parameter;
        protected IDataReader _dataReader;
        protected IDataRecord _dataRecord;
        protected string _connectionString = string.Empty;

        #endregion Properties

        #region Connect

        public virtual IDbConnection Connect()
        {
            if( _connection.ConnectionString == string.Empty )
            {
                _connection.ConnectionString = _connectionString;
            }

            if( _connection.State == ConnectionState.Closed )
            {
                _connection.Open();
            }

            return _connection;
        }

        #endregion Connect

        #region Close

        public virtual void Close()
        {
            _connection.Close();
        }

        #endregion Close

        #region GetConnection

        public virtual IDbConnection GetConnection()
        {
            if( _connection.ConnectionString == string.Empty )
            {
                _connection.ConnectionString = _connectionString;
            }

            return _connection;
        }

        #endregion GetConnection

        #region GetCommand

        public virtual IDbCommand GetCommand( string text , CommandType type )
        {
            _command.Connection = _connection;
            _command.CommandText = text;
            _command.CommandType = type;

            return _command;
        }

        #endregion GetCommand

        #region AddParameter

        public virtual void AddParameter( string name , object value )
        {
            throw new NotImplementedException();
        }

        #endregion AddParameter

        #region IList<T> GetMockData<T>()

        public virtual IEnumerable<T> GetMockData<T>()
        {
            throw new NotImplementedException();
        }

        #endregion IList<T> GetMockData<T>()

        #endregion IDataBaseAcces Members

        #region IDataBaseAccess Members

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        #endregion IDataBaseAccess Members
    }
}