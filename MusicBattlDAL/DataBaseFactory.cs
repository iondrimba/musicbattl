using System.Data;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;

namespace MusicBattlDAL
{
    public class DataBaseFactory : IDataBaseFactory
    {
        private static DataBaseFactory _instance;
        private IDataBaseAccess _dataBase;

        public static DataBaseFactory Instance
        {
            get
            {
                if( _instance == null )
                {
                    _instance = new DataBaseFactory();
                }

                return _instance;
            }
        }

        #region Constructor

        protected DataBaseFactory()
        {
        }

        #endregion Constructor

        #region IDataBaseFactory Members

        #region Connect

        /// <summary>
        /// Create connection to database, by default
        /// </summary>
        /// <param name="pDataBaseFactoryType"></param>
        /// <param name="connectionString"></param>
        /// <returns>IDataBaseAccess</returns>
        public IDataBaseAccess GetDataBaseAccess( DataBaseFactoryType pDataBaseFactoryType , string connectionString )
        {
            switch( pDataBaseFactoryType )
            {
                case DataBaseFactoryType.SQLServer:
                    _dataBase = new SQLServerDataBaseAccess();
                    break;

                default:
                    _dataBase = new SQLServerDataBaseAccess();
                    break;
            }

            _dataBase.ConnectionString = connectionString;

            return _dataBase;
        }

        #endregion Connect

        #region Close

        public void Close()
        {
            if( _dataBase.GetConnection().State == ConnectionState.Open )
            {
                _dataBase.Close();
            }
        }

        #endregion Close

        #endregion IDataBaseFactory Members
    }

    #region DataBaseFactoryType

    public enum DataBaseFactoryType
    {
        SQLServer = 0 ,
        MySQL = 1
    }

    #endregion DataBaseFactoryType
}