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
    public class VoteRepository : IRepository<IVote>
    {
        private IList<IVote> _collection;
        private Database _dataBase;

        #region Constructor

        public VoteRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IVote>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IVote GetById(int id)
        {
            IVote vote = new Vote();
            string sqlCommand = "voteFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" voteId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        vote.VoteId = Convert.ToInt32(reader["voteId"].ToString());
                        vote.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        vote.SongId = Convert.ToInt32(reader["songId"].ToString());
                        vote.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        vote.Votes = Convert.ToInt32(reader["votes"].ToString());
                    }
                }
            }

            return vote;
        }

        #endregion GetById( int id )

        #region GetTop<IVoteQueryParams>(int top,IVoteQueryParams query )

        public IList<IVote> GetTop<IVoteQueryParams>(int top, IVoteQueryParams query)
        {
            _collection = new List<IVote>();
            string sqlCommand = "voteGetTop";

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
                        IVote vote = new Vote();

                        vote.VoteId = Convert.ToInt32(reader["voteId"].ToString());
                        vote.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        vote.SongId = Convert.ToInt32(reader["songId"].ToString());
                        vote.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        vote.Votes = Convert.ToInt32(reader["votes"].ToString());
                        _collection.Add(vote);
                    }
                }
            }
            return _collection;
        }

        #endregion GetTop<IVoteQueryParams>(int top,IVoteQueryParams query )

        #region Find<IVoteQueryParams>( IVoteQueryParams query )

        public IList<IVote> Find<IVoteQueryParams>(IVoteQueryParams query)
        {
            _collection = new List<IVote>();
            string sqlCommand = "voteFind";

            // Create a suitable command type and add the required parameter.
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, ((IDataQuery)query).From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, ((IDataQuery)query).Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, ((IDataQuery)query).OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        IVote vote = new Vote();

                        vote.VoteId = Convert.ToInt32(reader["voteId"].ToString());
                        vote.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        vote.SongId = Convert.ToInt32(reader["songId"].ToString());
                        vote.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        vote.Votes = Convert.ToInt32(reader["votes"].ToString());
                        _collection.Add(vote);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IVoteQueryParams>( IVoteQueryParams query )

        #region Count<IVoteQueryParams>( IVoteQueryParams query )

        public int Count<IVoteQueryParams>(IVoteQueryParams query)
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

        #endregion Count<IVoteQueryParams>( IVoteQueryParams query )

        #region Sum<IVoteQueryParams>( IVoteQueryParams query )

        public decimal Sum<IVoteQueryParams>(IVoteQueryParams query)
        {
            decimal retorno = 0;
            string sqlCommand = "sumByParams";
            // Create a suitable command type and add the required parameter.
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, ((IDataQuery)query).From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, ((IDataQuery)query).Where);
                _dataBase.AddInParameter(dbCmd, "@columnParam", DbType.String, ((IDataQuery)query).Column);

                retorno = Convert.ToDecimal(_dataBase.ExecuteScalar(dbCmd));
            }

            return retorno;
        }

        #endregion Sum<IVoteQueryParams>( IVoteQueryParams query )

        #region Add( IVote )

        public IVote Add(IVote vote)
        {
            IVote voteAdded = new Vote();
            int id = 0;
            string sqlCommand = "voteAdd";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@battlId", DbType.Int32, vote.BattlId);
                _dataBase.AddInParameter(dbCmd, "@songId", DbType.Int32, vote.SongId);
                _dataBase.AddInParameter(dbCmd, "@profileId", DbType.Int32, vote.ProfileId);
                _dataBase.AddInParameter(dbCmd, "@votes", DbType.Int32, vote.Votes);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));

                voteAdded = this.GetById(id);
            }

            return voteAdded;
        }

        #endregion Add( IVote )

        #region Update( IVote )

        public IVote Update(IVote vote)
        {
            IVote voteUpdated = new Vote();
            string sqlCommand = "voteUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@voteId", DbType.Int32, vote.VoteId);
                _dataBase.AddInParameter(dbCmd, "@battlId", DbType.Int32, vote.BattlId);
                _dataBase.AddInParameter(dbCmd, "@songId", DbType.Int32, vote.SongId);
                _dataBase.AddInParameter(dbCmd, "@profileId", DbType.Int32, vote.ProfileId);
                _dataBase.AddInParameter(dbCmd, "@votes", DbType.Int32, vote.Votes);

                _dataBase.ExecuteScalar(dbCmd);

                voteUpdated = this.GetById(vote.VoteId);
            };

            return voteUpdated;
        }

        #endregion Update( IVote )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;
            string sqlCommand = "voteRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@voteId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IVote> Collection
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