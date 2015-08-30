using System.Collections.Generic;
using MusicBattlDAL.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IRepositoryBLL<T> where T : class
    {
        T GetById( int id );

        IList<T> Find( IDataQuery query );

        IList<T> Collection { get; }

        IRepository<T> repositorieDAL { get; set; }

        IList<T> GetTop( int top , IDataQuery query );

        int Count<Q>( Q query );

        decimal Sum<Q>( Q query );

        T Add( T entity );

        T Update( T entity );

        bool Remove( int id );

        void Validate( T entity );
    }
}