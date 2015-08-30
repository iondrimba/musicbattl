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
    public class ViewTopUsersRepository : IRepository<IViewTopUsers>
    {
        private IList<IViewTopUsers> _collection;
        private Database _dataBase;

        #region Constructor

        public ViewTopUsersRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewTopUsers>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewTopUsers GetById(int id)
        {
            IViewTopUsers viewTopUsers = new ViewTopUsers();
            string sqlCommand = "viewTopUsersFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" viewTopUsersId= {0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewTopUsers.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        viewTopUsers.UsuarioId = Convert.ToInt32(reader["usuarioId"].ToString());
                        viewTopUsers.TotalVotes = Convert.ToInt32(reader["totalVotes"].ToString());
                        viewTopUsers.Name = reader["name"].ToString();
                        viewTopUsers.Picture = reader["picture"].ToString();
                        viewTopUsers.Gender = reader["gender"].ToString();
                    }
                }
            }

            return viewTopUsers;
        }

        #endregion GetById( int id )

        #region GetTop<IViewTopUsersQueryParams>(int top,IViewTopUsersQueryParams query )

        public IList<IViewTopUsers> GetTop<IViewTopUsersQueryParams>(int top, IViewTopUsersQueryParams query)
        {
            _collection = new List<IViewTopUsers>();
            string sqlCommand = "viewTopUsersGetTop";

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
                        IViewTopUsers viewTopUsers = new ViewTopUsers();

                        viewTopUsers.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        viewTopUsers.UsuarioId = Convert.ToInt32(reader["usuarioId"].ToString());
                        viewTopUsers.TotalVotes = Convert.ToInt32(reader["totalVotes"].ToString());
                        viewTopUsers.Name = reader["name"].ToString();
                        viewTopUsers.Picture = reader["picture"].ToString();
                        viewTopUsers.Gender = reader["gender"].ToString();
                        _collection.Add(viewTopUsers);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewTopUsersQueryParams>(int top,IViewTopUsersQueryParams query )

        #region Find<IViewTopUsersQueryParams>( IViewTopUsersQueryParams query )

        public IList<IViewTopUsers> Find<IViewTopUsersQueryParams>(IViewTopUsersQueryParams query)
        {
            _collection = new List<IViewTopUsers>();
            string sqlCommand = "viewTopUsersFind";

            // Create a suitable command type and add the required parameter.
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, ((IDataQuery)query).From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, ((IDataQuery)query).Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, ((IDataQuery)query).OrderBy);
                _dataBase.AddInParameter(dbCmd, "@pageNumber", DbType.String, ((IDataQuery)query).Page);
                _dataBase.AddInParameter(dbCmd, "@rowCount", DbType.String, ((IDataQuery)query).RowCount);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        IViewTopUsers viewTopUsers = new ViewTopUsers();

                        viewTopUsers.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        viewTopUsers.TotalVotes = Convert.ToInt32(reader["totalVotes"].ToString());
                        viewTopUsers.Name = reader["name"].ToString();
                        viewTopUsers.Picture = reader["picture"].ToString();
                        _collection.Add(viewTopUsers);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewTopUsersQueryParams>( IViewTopUsersQueryParams query )

        #region Count<IViewTopUsersQueryParams>( IViewTopUsersQueryParams query )

        public int Count<IViewTopUsersQueryParams>(IViewTopUsersQueryParams query)
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

        #endregion Count<IViewTopUsersQueryParams>( IViewTopUsersQueryParams query )

        #region Sum<IViewTopUsersQueryParams>( IViewTopUsersQueryParams query )

        public decimal Sum<IViewTopUsersQueryParams>(IViewTopUsersQueryParams query)
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

        #endregion Sum<IViewTopUsersQueryParams>( IViewTopUsersQueryParams query )

        #region Add( IViewTopUsers )

        public IViewTopUsers Add(IViewTopUsers viewTopUsers)
        {
            string message = "IViewTopUsers Add not supported";
            throw new NotSupportedException(message);
        }

        #endregion Add( IViewTopUsers )

        #region Update( IViewTopUsers )

        public IViewTopUsers Update(IViewTopUsers viewTopUsers)
        {
            string message = "IViewTopUsers Update not supported";
            throw new NotSupportedException(message);
        }

        #endregion Update( IViewTopUsers )

        #region Remove( id)

        public bool Remove(int id)
        {
            string message = "IViewTopUsers Remove not supported";
            throw new NotSupportedException(message);
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewTopUsers> Collection
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