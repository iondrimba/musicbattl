using System.Collections.Generic;

namespace MusicBattlDAL.interfaces
{
    public interface IRepository<T> where T : class
    {
        IDataBaseAccess DataBaseAccess { get; }

        T GetById( int id );

        IList<T> Find<Q>( Q query );

        IList<T> GetTop<Q>( int top , Q query );

        int Count<Q>( Q query );

        decimal Sum<Q>( Q query );

        T Add( T entity );

        T Update( T entity );

        IEnumerable<T> Collection { get; }

        bool Remove( int id );
    }
}