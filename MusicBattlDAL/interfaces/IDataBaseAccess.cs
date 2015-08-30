using System.Collections.Generic;
using System.Data;

namespace MusicBattlDAL.interfaces
{
    public interface IDataBaseAccess
    {
        IDbConnection GetConnection();

        IDbCommand GetCommand( string text , CommandType type );

        void AddParameter( string name , object value );

        string ConnectionString { get; set; }

        IDbConnection Connect();

        void Close();

        IEnumerable<T> GetMockData<T>();
    }
}