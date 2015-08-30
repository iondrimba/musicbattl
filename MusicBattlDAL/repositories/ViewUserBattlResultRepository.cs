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
    public class ViewUserBattlResultRepository : IRepository<IViewUserBattlResult>
    {
        private IList<IViewUserBattlResult> _collection;
        private Database _dataBase;

        #region Constructor

        public ViewUserBattlResultRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewUserBattlResult>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewUserBattlResult GetById(int id)
        {
            IViewUserBattlResult viewUserBattlResult = new ViewUserBattlResult();
            string sqlCommand = "viewUserBattlResultFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" viewUserBattlResultId = {0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewUserBattlResult.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewUserBattlResult.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        viewUserBattlResult.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        viewUserBattlResult.ArtistNameFirst = reader["firstArtistName"].ToString();
                        viewUserBattlResult.ArtistNameSecond = reader["secondArtistName"].ToString();

                        if (reader["totalFirst"] != DBNull.Value)
                        {
                            viewUserBattlResult.TotalFirst = Convert.ToInt32(reader["totalFirst"].ToString());
                        }

                        if (reader["totalSecond"] != DBNull.Value)
                        {
                            viewUserBattlResult.TotalSecond = Convert.ToInt32(reader["totalSecond"].ToString());
                        }

                        if (reader["profileIdFirst"] != DBNull.Value)
                        {
                            viewUserBattlResult.ProfileIdFirst = Convert.ToInt32(reader["profileIdFirst"].ToString());
                        }

                        if (reader["profileIdSecond"] != DBNull.Value)
                        {
                            viewUserBattlResult.ProfileIdSecond = Convert.ToInt32(reader["profileIdSecond"].ToString());
                        }
                        viewUserBattlResult.ArtistIdFirst = Convert.ToInt32(reader["firstArtistId"].ToString());
                        viewUserBattlResult.ArtistIdSecond = Convert.ToInt32(reader["secondArtistId"].ToString());
                        viewUserBattlResult.FirstAlbumCover = reader["firstAlbumCover"].ToString();
                        viewUserBattlResult.SecondAlbumCover = reader["secondAlbumCover"].ToString();
                    }
                }
            }

            return viewUserBattlResult;
        }

        #endregion GetById( int id )

        #region GetTop<IViewUserBattlResultQueryParams>(int top,IViewUserBattlResultQueryParams query )

        public IList<IViewUserBattlResult> GetTop<IViewUserBattlResultQueryParams>(int top, IViewUserBattlResultQueryParams query)
        {
            _collection = new List<IViewUserBattlResult>();
            string sqlCommand = "viewUserBattlResultGetTop";
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
                        IViewUserBattlResult viewUserBattlResult = new ViewUserBattlResult();

                        viewUserBattlResult.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewUserBattlResult.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        viewUserBattlResult.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        viewUserBattlResult.ArtistNameFirst = reader["firstArtistName"].ToString();
                        viewUserBattlResult.ArtistNameSecond = reader["secondArtistName"].ToString();
                        if (reader["totalFirst"] != DBNull.Value)
                        {
                            viewUserBattlResult.TotalFirst = Convert.ToInt32(reader["totalFirst"].ToString());
                        }

                        if (reader["totalSecond"] != DBNull.Value)
                        {
                            viewUserBattlResult.TotalSecond = Convert.ToInt32(reader["totalSecond"].ToString());
                        }
                        if (reader["profileIdFirst"] != DBNull.Value)
                        {
                            viewUserBattlResult.ProfileIdFirst = Convert.ToInt32(reader["profileIdFirst"].ToString());
                        }

                        if (reader["profileIdSecond"] != DBNull.Value)
                        {
                            viewUserBattlResult.ProfileIdSecond = Convert.ToInt32(reader["profileIdSecond"].ToString());
                        }
                        viewUserBattlResult.ArtistIdFirst = Convert.ToInt32(reader["firstArtistId"].ToString());
                        viewUserBattlResult.ArtistIdSecond = Convert.ToInt32(reader["secondArtistId"].ToString());
                        viewUserBattlResult.FirstAlbumCover = reader["firstAlbumCover"].ToString();
                        viewUserBattlResult.SecondAlbumCover = reader["secondAlbumCover"].ToString();
                        _collection.Add(viewUserBattlResult);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewUserBattlResultQueryParams>(int top,IViewUserBattlResultQueryParams query )

        #region Find<IViewUserBattlResultQueryParams>( IViewUserBattlResultQueryParams query )

        public IList<IViewUserBattlResult> Find<IViewUserBattlResultQueryParams>(IViewUserBattlResultQueryParams query)
        {
            _collection = new List<IViewUserBattlResult>();
            string sqlCommand = "viewUserBattlResultFind";

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
                        IViewUserBattlResult viewUserBattlResult = new ViewUserBattlResult();

                        viewUserBattlResult.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewUserBattlResult.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        viewUserBattlResult.FirstAlbumCover = reader["firstAlbumCover"].ToString();

                        viewUserBattlResult.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        viewUserBattlResult.SecondAlbumCover = reader["secondAlbumCover"].ToString();

                        viewUserBattlResult.ArtistNameFirst = reader["firstArtistName"].ToString();
                        viewUserBattlResult.ArtistNameSecond = reader["secondArtistName"].ToString();
                        viewUserBattlResult.ArtistIdFirst = Convert.ToInt32(reader["firstArtistId"].ToString());
                        viewUserBattlResult.ArtistIdSecond = Convert.ToInt32(reader["secondArtistId"].ToString());

                        viewUserBattlResult.SongNameFirst = reader["firstSongName"].ToString();
                        viewUserBattlResult.SongNameSecond = reader["secondSongName"].ToString();

                        viewUserBattlResult.AlbumNameFirst = reader["firstAlbumName"].ToString();
                        viewUserBattlResult.AlbumNameSecond = reader["secondAlbumName"].ToString();

                        if (reader["totalFirst"] != DBNull.Value)
                        {
                            viewUserBattlResult.TotalFirst = Convert.ToInt32(reader["totalFirst"].ToString());
                        }

                        if (reader["totalSecond"] != DBNull.Value)
                        {
                            viewUserBattlResult.TotalSecond = Convert.ToInt32(reader["totalSecond"].ToString());
                        }

                        if (reader["profileIdFirst"] != DBNull.Value)
                        {
                            viewUserBattlResult.ProfileIdFirst = Convert.ToInt32(reader["profileIdFirst"].ToString());
                        }

                        if (reader["profileIdSecond"] != DBNull.Value)
                        {
                            viewUserBattlResult.ProfileIdSecond = Convert.ToInt32(reader["profileIdSecond"].ToString());
                        }

                        _collection.Add(viewUserBattlResult);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewUserBattlResultQueryParams>( IViewUserBattlResultQueryParams query )

        #region Count<IViewUserBattlResultQueryParams>( IViewUserBattlResultQueryParams query )

        public int Count<IViewUserBattlResultQueryParams>(IViewUserBattlResultQueryParams query)
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

        #endregion Count<IViewUserBattlResultQueryParams>( IViewUserBattlResultQueryParams query )

        #region Sum<IViewUserBattlResultQueryParams>( IViewUserBattlResultQueryParams query )

        public decimal Sum<IViewUserBattlResultQueryParams>(IViewUserBattlResultQueryParams query)
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

        #endregion Sum<IViewUserBattlResultQueryParams>( IViewUserBattlResultQueryParams query )

        #region Add( IViewUserBattlResult )

        public IViewUserBattlResult Add(IViewUserBattlResult viewUserBattlResult)
        {
            IViewUserBattlResult viewUserBattlResultAdded = new ViewUserBattlResult();
            int id = 0;
            string sqlCommand = "viewUserBattlResultAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@battlId", DbType.Int32, viewUserBattlResult.BattlId);
                _dataBase.AddInParameter(dbCmd, "@firstSongId", DbType.Int32, viewUserBattlResult.FirstSongId);
                _dataBase.AddInParameter(dbCmd, "@secondSongId", DbType.Int32, viewUserBattlResult.SecondSongId);
                _dataBase.AddInParameter(dbCmd, "@firstArtistName", DbType.String, viewUserBattlResult.ArtistNameFirst);
                _dataBase.AddInParameter(dbCmd, "@secondArtistName", DbType.String, viewUserBattlResult.ArtistNameSecond);
                _dataBase.AddInParameter(dbCmd, "@totalFirst", DbType.Int32, viewUserBattlResult.TotalFirst);
                _dataBase.AddInParameter(dbCmd, "@totalSecond", DbType.Int32, viewUserBattlResult.TotalSecond);
                _dataBase.AddInParameter(dbCmd, "@profileIdFirst", DbType.Int32, viewUserBattlResult.ProfileIdFirst);
                _dataBase.AddInParameter(dbCmd, "@profileIdSecond", DbType.Int32, viewUserBattlResult.ProfileIdSecond);
                _dataBase.AddInParameter(dbCmd, "@firstArtistId", DbType.Int32, viewUserBattlResult.ArtistIdFirst);
                _dataBase.AddInParameter(dbCmd, "@secondArtistId", DbType.Int32, viewUserBattlResult.ArtistIdSecond);
                _dataBase.AddInParameter(dbCmd, "@firstAlbumCover", DbType.String, viewUserBattlResult.FirstAlbumCover);
                _dataBase.AddInParameter(dbCmd, "@secondAlbumCover", DbType.String, viewUserBattlResult.SecondAlbumCover);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));

                viewUserBattlResultAdded = this.GetById(id);
            }

            return viewUserBattlResultAdded;
        }

        #endregion Add( IViewUserBattlResult )

        #region Update( IViewUserBattlResult )

        public IViewUserBattlResult Update(IViewUserBattlResult viewUserBattlResult)
        {
            IViewUserBattlResult viewUserBattlResultUpdated = new ViewUserBattlResult();
            string sqlCommand = "viewUserBattlResultUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@battlId", DbType.Int32, viewUserBattlResult.BattlId);
                _dataBase.AddInParameter(dbCmd, "@firstSongId", DbType.Int32, viewUserBattlResult.FirstSongId);
                _dataBase.AddInParameter(dbCmd, "@secondSongId", DbType.Int32, viewUserBattlResult.SecondSongId);
                _dataBase.AddInParameter(dbCmd, "@firstArtistName", DbType.String, viewUserBattlResult.ArtistNameFirst);
                _dataBase.AddInParameter(dbCmd, "@secondArtistName", DbType.String, viewUserBattlResult.ArtistNameSecond);
                _dataBase.AddInParameter(dbCmd, "@totalFirst", DbType.Int32, viewUserBattlResult.TotalFirst);
                _dataBase.AddInParameter(dbCmd, "@totalSecond", DbType.Int32, viewUserBattlResult.TotalSecond);
                _dataBase.AddInParameter(dbCmd, "@profileIdFirst", DbType.Int32, viewUserBattlResult.ProfileIdFirst);
                _dataBase.AddInParameter(dbCmd, "@profileIdSecond", DbType.Int32, viewUserBattlResult.ProfileIdSecond);
                _dataBase.AddInParameter(dbCmd, "@firstArtistId", DbType.Int32, viewUserBattlResult.ArtistIdFirst);
                _dataBase.AddInParameter(dbCmd, "@secondArtistId", DbType.Int32, viewUserBattlResult.ArtistIdSecond);
                _dataBase.AddInParameter(dbCmd, "@firstAlbumCover", DbType.String, viewUserBattlResult.FirstAlbumCover);
                _dataBase.AddInParameter(dbCmd, "@secondAlbumCover", DbType.String, viewUserBattlResult.SecondAlbumCover);

                _dataBase.ExecuteScalar(dbCmd);

                viewUserBattlResultUpdated = this.GetById(viewUserBattlResult.BattlId);
            }
            return viewUserBattlResultUpdated;
        }

        #endregion Update( IViewUserBattlResult )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;
            string sqlCommand = "viewUserBattlResultRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@viewUserBattlResultId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewUserBattlResult> Collection
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