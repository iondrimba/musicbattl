namespace MusicBattlDAL.interfaces
{
    public interface IDataBaseFactory
    {
        IDataBaseAccess GetDataBaseAccess( DataBaseFactoryType pDataBaseFactoryType , string connection );

        void Close();
    }
}