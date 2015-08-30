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
    public partial class ViewAlbumArtistSongTotalVotesRepository : IRepository<IViewAlbumArtistSongTotalVotes>
    {
        private IList<IViewAlbumArtistSongTotalVotes> _collection;
        private Database _dataBase;

        #region Constructor

        public ViewAlbumArtistSongTotalVotesRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewAlbumArtistSongTotalVotes>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewAlbumArtistSongTotalVotes GetById(int id)
        {
            IViewAlbumArtistSongTotalVotes viewAlbumArtistSongTotalVotes = new ViewAlbumArtistSongTotalVotes();
            string sqlCommand = "viewAlbumArtistSongTotalVotesFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" songId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewAlbumArtistSongTotalVotes.SongId = Convert.ToInt32(reader["songId"].ToString());
                        viewAlbumArtistSongTotalVotes.Total = Convert.ToInt32(reader["total"].ToString());
                        viewAlbumArtistSongTotalVotes.SongName = reader["songName"].ToString();
                        viewAlbumArtistSongTotalVotes.AlbumName = reader["albumName"].ToString();
                        viewAlbumArtistSongTotalVotes.ArtistName = reader["artistName"].ToString();
                        viewAlbumArtistSongTotalVotes.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewAlbumArtistSongTotalVotes.AlbumCover = reader["albumCover"].ToString();
                        viewAlbumArtistSongTotalVotes.BattlDate = (DateTime)reader["battlDate"];
                    }
                }
            }

            return viewAlbumArtistSongTotalVotes;
        }

        #endregion GetById( int id )

        #region GetTop<IViewAlbumArtistSongTotalVotesQueryParams>(int top,IViewAlbumArtistSongTotalVotesQueryParams query )

        public IList<IViewAlbumArtistSongTotalVotes> GetTop<IViewAlbumArtistSongTotalVotesQueryParams>(int top, IViewAlbumArtistSongTotalVotesQueryParams query)
        {
            _collection = new List<IViewAlbumArtistSongTotalVotes>();
            string sqlCommand = "viewAlbumArtistSongTotalVotesGetTop";

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
                        IViewAlbumArtistSongTotalVotes viewAlbumArtistSongTotalVotes = new ViewAlbumArtistSongTotalVotes();

                        viewAlbumArtistSongTotalVotes.SongId = Convert.ToInt32(reader["songId"].ToString());
                        viewAlbumArtistSongTotalVotes.Total = Convert.ToInt32(reader["total"].ToString());
                        viewAlbumArtistSongTotalVotes.SongName = reader["songName"].ToString();
                        viewAlbumArtistSongTotalVotes.AlbumName = reader["albumName"].ToString();
                        viewAlbumArtistSongTotalVotes.ArtistName = reader["artistName"].ToString();
                        viewAlbumArtistSongTotalVotes.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewAlbumArtistSongTotalVotes.AlbumCover = reader["albumCover"].ToString();
                        viewAlbumArtistSongTotalVotes.BattlDate = (DateTime)reader["battlDate"];
                        _collection.Add(viewAlbumArtistSongTotalVotes);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewAlbumArtistSongTotalVotesQueryParams>(int top,IViewAlbumArtistSongTotalVotesQueryParams query )

        #region Find<IViewAlbumArtistSongTotalVotesQueryParams>( IViewAlbumArtistSongTotalVotesQueryParams query )

        public IList<IViewAlbumArtistSongTotalVotes> Find<IViewAlbumArtistSongTotalVotesQueryParams>(IViewAlbumArtistSongTotalVotesQueryParams query)
        {
            _collection = new List<IViewAlbumArtistSongTotalVotes>();
            string sqlCommand = "viewAlbumArtistSongTotalVotesGroupedBySong";

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
                        IViewAlbumArtistSongTotalVotes viewAlbumArtistSongTotalVotes = new ViewAlbumArtistSongTotalVotes();

                        viewAlbumArtistSongTotalVotes.SongId = Convert.ToInt32(reader["songId"].ToString());
                        viewAlbumArtistSongTotalVotes.SongName = reader["songName"].ToString();
                        viewAlbumArtistSongTotalVotes.Total = Convert.ToInt32(reader["total"].ToString());
                        viewAlbumArtistSongTotalVotes.AlbumName = reader["albumName"].ToString();
                        viewAlbumArtistSongTotalVotes.ArtistName = reader["artistName"].ToString();
                        viewAlbumArtistSongTotalVotes.ArtistId = Convert.ToInt32(reader["total"].ToString());
                        viewAlbumArtistSongTotalVotes.AlbumCover = reader["albumCover"].ToString();
                        _collection.Add(viewAlbumArtistSongTotalVotes);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewAlbumArtistSongTotalVotesQueryParams>( IViewAlbumArtistSongTotalVotesQueryParams query )

        #region Count<IViewAlbumArtistSongTotalVotesQueryParams>( IViewAlbumArtistSongTotalVotesQueryParams query )

        public int Count<IViewAlbumArtistSongTotalVotesQueryParams>(IViewAlbumArtistSongTotalVotesQueryParams query)
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

        #endregion Count<IViewAlbumArtistSongTotalVotesQueryParams>( IViewAlbumArtistSongTotalVotesQueryParams query )

        #region Sum<IViewAlbumArtistSongTotalVotesQueryParams>( IViewAlbumArtistSongTotalVotesQueryParams query )

        public decimal Sum<IViewAlbumArtistSongTotalVotesQueryParams>(IViewAlbumArtistSongTotalVotesQueryParams query)
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

        #endregion Sum<IViewAlbumArtistSongTotalVotesQueryParams>( IViewAlbumArtistSongTotalVotesQueryParams query )

        #region Add( IViewAlbumArtistSongTotalVotes )

        public IViewAlbumArtistSongTotalVotes Add(IViewAlbumArtistSongTotalVotes viewAlbumArtistSongTotalVotes)
        {
            string message = "IViewAlbumArtistSongTotalVotes Add not supported";
            throw new NotSupportedException(message);
        }

        #endregion Add( IViewAlbumArtistSongTotalVotes )

        #region Update( IViewAlbumArtistSongTotalVotes )

        public IViewAlbumArtistSongTotalVotes Update(IViewAlbumArtistSongTotalVotes viewAlbumArtistSongTotalVotes)
        {
            string message = "IViewAlbumArtistSongTotalVotes Update not supported";
            throw new NotSupportedException(message);
        }

        #endregion Update( IViewAlbumArtistSongTotalVotes )

        #region Remove( id)

        public bool Remove(int id)
        {
            string message = "IViewAlbumArtistSongTotalVotes Remove not supported";
            throw new NotSupportedException(message);
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewAlbumArtistSongTotalVotes> Collection
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