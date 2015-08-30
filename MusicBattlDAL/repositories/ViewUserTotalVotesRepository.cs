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
    public class ViewUserTotalVotesRepository : IRepository<IViewUserTotalVotes>
    {
        private IList<IViewUserTotalVotes> _collection;
        private Database _dataBase;

        #region Constructor

        public ViewUserTotalVotesRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewUserTotalVotes>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewUserTotalVotes GetById(int id)
        {
            IViewUserTotalVotes viewUserTotalVotes = new ViewUserTotalVotes();
            string sqlCommand = "viewUserTotalVotesFind";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" profielId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewUserTotalVotes.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewUserTotalVotes.SongId = Convert.ToInt32(reader["songId"].ToString());
                        viewUserTotalVotes.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        viewUserTotalVotes.Total = Convert.ToInt32(reader["total"].ToString());
                        viewUserTotalVotes.Name = reader["name"].ToString();
                        viewUserTotalVotes.UsuarioId = Convert.ToInt32(reader["usuarioId"].ToString());
                        viewUserTotalVotes.Picture = reader["picture"].ToString();
                        viewUserTotalVotes.SongName = reader["songName"].ToString();
                        viewUserTotalVotes.Gender = reader["gender"].ToString();
                    }
                }
            }
            return viewUserTotalVotes;
        }

        #endregion GetById( int id )

        #region GetTop<IViewUserTotalVotesQueryParams>(int top,IViewUserTotalVotesQueryParams query )

        public IList<IViewUserTotalVotes> GetTop<IViewUserTotalVotesQueryParams>(int top, IViewUserTotalVotesQueryParams query)
        {
            _collection = new List<IViewUserTotalVotes>();
            string sqlCommand = "viewUserTotalVotesGetTop";
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
                        IViewUserTotalVotes viewUserTotalVotes = new ViewUserTotalVotes();

                        viewUserTotalVotes.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewUserTotalVotes.SongId = Convert.ToInt32(reader["songId"].ToString());
                        viewUserTotalVotes.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        viewUserTotalVotes.Total = Convert.ToInt32(reader["total"].ToString());
                        viewUserTotalVotes.Name = reader["name"].ToString();
                        viewUserTotalVotes.UsuarioId = Convert.ToInt32(reader["usuarioId"].ToString());
                        viewUserTotalVotes.Picture = reader["picture"].ToString();
                        viewUserTotalVotes.SongName = reader["songName"].ToString();
                        viewUserTotalVotes.Gender = reader["gender"].ToString();
                        _collection.Add(viewUserTotalVotes);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewUserTotalVotesQueryParams>(int top,IViewUserTotalVotesQueryParams query )

        #region Find<IViewUserTotalVotesQueryParams>( IViewUserTotalVotesQueryParams query )

        public IList<IViewUserTotalVotes> Find<IViewUserTotalVotesQueryParams>(IViewUserTotalVotesQueryParams query)
        {
            _collection = new List<IViewUserTotalVotes>();
            string sqlCommand = "viewUserTotalVotesFind";

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
                        IViewUserTotalVotes viewUserTotalVotes = new ViewUserTotalVotes();

                        viewUserTotalVotes.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        viewUserTotalVotes.Total = Convert.ToInt32(reader["total"].ToString());
                        viewUserTotalVotes.Name = reader["name"].ToString();
                        viewUserTotalVotes.Picture = reader["picture"].ToString();
                        _collection.Add(viewUserTotalVotes);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewUserTotalVotesQueryParams>( IViewUserTotalVotesQueryParams query )

        #region Count<IViewUserTotalVotesQueryParams>( IViewUserTotalVotesQueryParams query )

        public int Count<IViewUserTotalVotesQueryParams>(IViewUserTotalVotesQueryParams query)
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

        #endregion Count<IViewUserTotalVotesQueryParams>( IViewUserTotalVotesQueryParams query )

        #region Sum<IViewUserTotalVotesQueryParams>( IViewUserTotalVotesQueryParams query )

        public decimal Sum<IViewUserTotalVotesQueryParams>(IViewUserTotalVotesQueryParams query)
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

        #endregion Sum<IViewUserTotalVotesQueryParams>( IViewUserTotalVotesQueryParams query )

        #region Add( IViewUserTotalVotes )

        public IViewUserTotalVotes Add(IViewUserTotalVotes viewUserTotalVotes)
        {
            IViewUserTotalVotes retorno = new ViewUserTotalVotes();
            int id = 0;
            string sqlCommand = "viewUserTotalVotesAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@battlId", DbType.Int32, viewUserTotalVotes.BattlId);
                _dataBase.AddInParameter(dbCmd, "@songId", DbType.Int32, viewUserTotalVotes.SongId);
                _dataBase.AddInParameter(dbCmd, "@profileId", DbType.Int32, viewUserTotalVotes.ProfileId);
                _dataBase.AddInParameter(dbCmd, "@total", DbType.Int32, viewUserTotalVotes.Total);
                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, viewUserTotalVotes.Name);
                _dataBase.AddInParameter(dbCmd, "@usuarioId", DbType.Int32, viewUserTotalVotes.UsuarioId);
                _dataBase.AddInParameter(dbCmd, "@picture", DbType.String, viewUserTotalVotes.Picture);
                _dataBase.AddInParameter(dbCmd, "@songName", DbType.String, viewUserTotalVotes.SongName);
                _dataBase.AddInParameter(dbCmd, "@gender", DbType.String, viewUserTotalVotes.Gender);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));

                retorno = this.GetById(id);
            }

            return retorno;
        }

        #endregion Add( IViewUserTotalVotes )

        #region Update( IViewUserTotalVotes )

        public IViewUserTotalVotes Update(IViewUserTotalVotes viewUserTotalVotes)
        {
            IViewUserTotalVotes viewUserTotalVotesUpdated = new ViewUserTotalVotes();
            string sqlCommand = "viewUserTotalVotesUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@battlId", DbType.Int32, viewUserTotalVotes.BattlId);
                _dataBase.AddInParameter(dbCmd, "@songId", DbType.Int32, viewUserTotalVotes.SongId);
                _dataBase.AddInParameter(dbCmd, "@profileId", DbType.Int32, viewUserTotalVotes.ProfileId);
                _dataBase.AddInParameter(dbCmd, "@total", DbType.Int32, viewUserTotalVotes.Total);
                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, viewUserTotalVotes.Name);
                _dataBase.AddInParameter(dbCmd, "@usuarioId", DbType.Int32, viewUserTotalVotes.UsuarioId);
                _dataBase.AddInParameter(dbCmd, "@picture", DbType.String, viewUserTotalVotes.Picture);
                _dataBase.AddInParameter(dbCmd, "@songName", DbType.String, viewUserTotalVotes.SongName);
                _dataBase.AddInParameter(dbCmd, "@gender", DbType.String, viewUserTotalVotes.Gender);

                _dataBase.ExecuteScalar(dbCmd);

                viewUserTotalVotesUpdated = this.GetById(viewUserTotalVotes.ProfileId);
            }

            return viewUserTotalVotesUpdated;
        }

        #endregion Update( IViewUserTotalVotes )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;
            string sqlCommand = "viewUserTotalVotesRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@viewUserTotalVotesId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewUserTotalVotes> Collection
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