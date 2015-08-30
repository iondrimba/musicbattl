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
    public class ViewBattlRepository : IRepository<IViewBattl>
    {
        private IList<IViewBattl> _collection;
        private Database _dataBase;

        #region Constructor

        public ViewBattlRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewBattl>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewBattl GetById(int id)
        {
            IViewBattl viewBattl = new ViewBattl();
            string sqlCommand = "viewBattlFind";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" viewBattlId = {0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewBattl.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewBattl.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        viewBattl.StartTime = (DateTime)reader["startTime"];
                        viewBattl.EndTime = (DateTime)reader["endTime"];
                        viewBattl.BattlDate = (DateTime)reader["battlDate"];
                        viewBattl.FirstSongUrl = reader["firstSoundCloudUrl"].ToString();
                        viewBattl.FirstAlbumCover = reader["firstAlbumCover"].ToString();
                        viewBattl.FirstSongName = reader["firstSongName"].ToString();
                        viewBattl.FirstAlbumName = reader["firstAlbumName"].ToString();
                        viewBattl.SecondSongUrl = reader["secondSoundCloudUrl"].ToString();
                        viewBattl.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        viewBattl.SecondSongName = reader["secondSongName"].ToString();
                        viewBattl.SecondAlbumCover = reader["secondAlbumCover"].ToString();
                        viewBattl.SecondAlbumName = reader["secondAlbumName"].ToString();
                        viewBattl.Active = Convert.ToInt32(reader["active"].ToString()) > 0;
                    }
                }
            }

            return viewBattl;
        }

        #endregion GetById( int id )

        #region GetTop<IViewBattlQueryParams>(int top,IViewBattlQueryParams query )

        public IList<IViewBattl> GetTop<IViewBattlQueryParams>(int top, IViewBattlQueryParams query)
        {
            _collection = new List<IViewBattl>();
            string sqlCommand = "viewBattlGetTop";
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
                        IViewBattl viewBattl = new ViewBattl();

                        viewBattl.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewBattl.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        viewBattl.FirstArtistId = Convert.ToInt32(reader["firstArtistId"].ToString());
                        viewBattl.StartTime = (DateTime)reader["startTime"];
                        viewBattl.EndTime = (DateTime)reader["endTime"];
                        viewBattl.BattlDate = (DateTime)reader["battlDate"];
                        viewBattl.FirstSongUrl = reader["firstSoundCloudUrl"].ToString();
                        viewBattl.FirstAlbumCover = reader["firstAlbumCover"].ToString();
                        viewBattl.FirstSongName = reader["firstSongName"].ToString();
                        viewBattl.FirstArtistName = reader["firstArtistName"].ToString();
                        viewBattl.FirstAlbumName = reader["firstAlbumName"].ToString();
                        viewBattl.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        viewBattl.SecondSongUrl = reader["secondSoundCloudUrl"].ToString();
                        viewBattl.SecondArtistId = Convert.ToInt32(reader["secondArtistId"].ToString());
                        viewBattl.SecondSongName = reader["secondSongName"].ToString();
                        viewBattl.SecondArtistName = reader["secondArtistName"].ToString();
                        viewBattl.SecondAlbumCover = reader["secondAlbumCover"].ToString();
                        viewBattl.SecondAlbumName = reader["secondAlbumName"].ToString();
                        viewBattl.FirstSongVotes = Convert.ToInt32(reader["firstSongVotes"].ToString());
                        viewBattl.SecondSongVotes = Convert.ToInt32(reader["secondSongVotes"].ToString());
                        viewBattl.Active = Convert.ToBoolean(reader["active"].ToString());
                        _collection.Add(viewBattl);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewBattlQueryParams>(int top,IViewBattlQueryParams query )

        #region Find<IViewBattlQueryParams>( IViewBattlQueryParams query )

        public IList<IViewBattl> Find<IViewBattlQueryParams>(IViewBattlQueryParams query)
        {
            _collection = new List<IViewBattl>();
            string sqlCommand = "viewBattlFind";
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
                        IViewBattl viewBattl = new ViewBattl();

                        viewBattl.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewBattl.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        viewBattl.FirstArtistId = Convert.ToInt32(reader["firstArtistId"].ToString());
                        viewBattl.StartTime = (DateTime)reader["startTime"];
                        viewBattl.EndTime = (DateTime)reader["endTime"];
                        viewBattl.BattlDate = (DateTime)reader["battlDate"];
                        viewBattl.FirstSongUrl = reader["firstSoundCloudUrl"].ToString();
                        viewBattl.FirstAlbumCover = reader["firstAlbumCover"].ToString();
                        viewBattl.FirstSongName = reader["firstSongName"].ToString();
                        viewBattl.FirstArtistName = reader["firstArtistName"].ToString();
                        viewBattl.FirstAlbumName = reader["firstAlbumName"].ToString();
                        viewBattl.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        viewBattl.SecondSongUrl = reader["secondSoundCloudUrl"].ToString();
                        viewBattl.SecondArtistId = Convert.ToInt32(reader["secondArtistId"].ToString());
                        viewBattl.SecondSongName = reader["secondSongName"].ToString();
                        viewBattl.SecondArtistName = reader["secondArtistName"].ToString();
                        viewBattl.SecondAlbumCover = reader["secondAlbumCover"].ToString();
                        viewBattl.SecondAlbumName = reader["secondAlbumName"].ToString();
                        viewBattl.FirstSongVotes = Convert.ToInt32(reader["firstSongVotes"].ToString());
                        viewBattl.SecondSongVotes = Convert.ToInt32(reader["secondSongVotes"].ToString());
                        viewBattl.Active = Convert.ToBoolean(reader["active"].ToString());
                        _collection.Add(viewBattl);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewBattlQueryParams>( IViewBattlQueryParams query )

        #region Count<IViewBattlQueryParams>( IViewBattlQueryParams query )

        public int Count<IViewBattlQueryParams>(IViewBattlQueryParams query)
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

        #endregion Count<IViewBattlQueryParams>( IViewBattlQueryParams query )

        #region Sum<IViewBattlQueryParams>( IViewBattlQueryParams query )

        public decimal Sum<IViewBattlQueryParams>(IViewBattlQueryParams query)
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

        #endregion Sum<IViewBattlQueryParams>( IViewBattlQueryParams query )

        #region Add( IViewBattl )

        public IViewBattl Add(IViewBattl viewBattl)
        {
            string message = "IViewBattl Add not supported";
            throw new NotSupportedException(message);
        }

        #endregion Add( IViewBattl )

        #region Update( IViewBattl )

        public IViewBattl Update(IViewBattl viewBattl)
        {
            string message = "IViewBattl Update not supported";
            throw new NotSupportedException(message);
        }

        #endregion Update( IViewBattl )

        #region Remove( id)

        public bool Remove(int id)
        {
            string message = "IViewBattl Remove not supported";
            throw new NotSupportedException(message);
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewBattl> Collection
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