using System.Data;
using System.Data.SqlClient;
using MusicBattlDAL.abstracts;
using MusicBattlDAL.interfaces;

namespace MusicBattlDAL.concrete
{
    public class SQLServerDataBaseAccess : AbstractDataBaseAccess , IDataBaseAccess
    {
        #region Constructor

        public SQLServerDataBaseAccess()
        {
            base._connection = new SqlConnection();
        }

        public SQLServerDataBaseAccess( string cons )
        {
            base._connectionString = cons;
            base._connection = new SqlConnection(base._connectionString);
        }

        #endregion Constructor

        public override IDbConnection Connect()
        {
            base._connection = new SqlConnection();
            return base.Connect();
        }

        #region GetCommand

        public override IDbConnection GetConnection()
        {
            return new SqlConnection(base.ConnectionString);
        }

        public override IDbCommand GetCommand( string text , System.Data.CommandType type )
        {
            _command = new SqlCommand();
            return base.GetCommand(text , type);
        }

        #endregion GetCommand

        #region AddParameter

        public override void AddParameter( string name , object value )
        {
            _parameter = new SqlParameter(string.Format("@{0}" , name) , value);
            _command.Parameters.Add(_parameter);
        }

        #endregion AddParameter
    }
}