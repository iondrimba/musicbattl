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
    public class ViewTopSongsRepository : IRepository<IViewTopSongs>
    {
        private IList<IViewTopSongs> _collection;
        private Database _dataBase;

        #region Constructor

        public ViewTopSongsRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewTopSongs>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewTopSongs GetById(int id)
        {
            IViewTopSongs viewTopSongs = new ViewTopSongs();
            string sqlCommand = "viewTopSongsFind";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" viewTopSongsId = {0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewTopSongs.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewTopSongs.SongId = Convert.ToInt32(reader["songId"].ToString());
                        viewTopSongs.SongName = reader["songName"].ToString();
                        viewTopSongs.ArtistName = reader["artistName"].ToString();
                        viewTopSongs.AlbumName = reader["albumName"].ToString();
                        viewTopSongs.AlbumCover = reader["albumCover"].ToString();
                        viewTopSongs.TotalVotes = Convert.ToInt32(reader["totalVotes"].ToString());
                    }
                }
            }

            return viewTopSongs;
        }

        #endregion GetById( int id )

        #region GetTop<IViewTopSongsQueryParams>(int top,IViewTopSongsQueryParams query )

        public IList<IViewTopSongs> GetTop<IViewTopSongsQueryParams>(int top, IViewTopSongsQueryParams query)
        {
            _collection = new List<IViewTopSongs>();
            string sqlCommand = "viewTopSongsGetTop";
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
                        IViewTopSongs viewTopSongs = new ViewTopSongs();

                        viewTopSongs.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewTopSongs.SongId = Convert.ToInt32(reader["songId"].ToString());
                        viewTopSongs.SongName = reader["songName"].ToString();
                        viewTopSongs.ArtistName = reader["artistName"].ToString();
                        viewTopSongs.AlbumName = reader["albumName"].ToString();
                        viewTopSongs.AlbumCover = reader["albumCover"].ToString();
                        viewTopSongs.TotalVotes = Convert.ToInt32(reader["totalVotes"].ToString());
                        _collection.Add(viewTopSongs);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewTopSongsQueryParams>(int top,IViewTopSongsQueryParams query )

        #region Find<IViewTopSongsQueryParams>( IViewTopSongsQueryParams query )

        public IList<IViewTopSongs> Find<IViewTopSongsQueryParams>(IViewTopSongsQueryParams query)
        {
            _collection = new List<IViewTopSongs>();
            string sqlCommand = "viewTopSongsFind";

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
                        IViewTopSongs viewTopSongs = new ViewTopSongs();

                        viewTopSongs.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewTopSongs.SongId = Convert.ToInt32(reader["songId"].ToString());
                        viewTopSongs.SongName = reader["songName"].ToString();
                        viewTopSongs.ArtistName = reader["artistName"].ToString();
                        viewTopSongs.AlbumName = reader["albumName"].ToString();
                        viewTopSongs.AlbumCover = reader["albumCover"].ToString();
                        viewTopSongs.TotalVotes = Convert.ToInt32(reader["totalVotes"].ToString());
                        _collection.Add(viewTopSongs);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewTopSongsQueryParams>( IViewTopSongsQueryParams query )

        #region Count<IViewTopSongsQueryParams>( IViewTopSongsQueryParams query )

        public int Count<IViewTopSongsQueryParams>(IViewTopSongsQueryParams query)
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

        #endregion Count<IViewTopSongsQueryParams>( IViewTopSongsQueryParams query )

        #region Sum<IViewTopSongsQueryParams>( IViewTopSongsQueryParams query )

        public decimal Sum<IViewTopSongsQueryParams>(IViewTopSongsQueryParams query)
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

        #endregion Sum<IViewTopSongsQueryParams>( IViewTopSongsQueryParams query )

        #region Add( IViewTopSongs )

        public IViewTopSongs Add(IViewTopSongs viewTopSongs)
        {
            string message = "IViewTopSongs Add not supported";
            throw new NotSupportedException(message);
        }

        #endregion Add( IViewTopSongs )

        #region Update( IViewTopSongs )

        public IViewTopSongs Update(IViewTopSongs viewTopSongs)
        {
            string message = "IViewTopSongs Update not supported";
            throw new NotSupportedException(message);
        }

        #endregion Update( IViewTopSongs )

        #region Remove( id)

        public bool Remove(int id)
        {
            string message = "IViewTopSongs Remove not supported";
            throw new NotSupportedException(message);
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewTopSongs> Collection
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