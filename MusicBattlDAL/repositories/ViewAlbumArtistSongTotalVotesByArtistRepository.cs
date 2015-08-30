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
    public class ViewAlbumArtistSongTotalVotesByArtistRepository : IRepository<IViewAlbumArtistSongTotalVotesByArtist>
    {
        private IList<IViewAlbumArtistSongTotalVotesByArtist> _collection;
        private Database _dataBase;

        #region Constructor

        public ViewAlbumArtistSongTotalVotesByArtistRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewAlbumArtistSongTotalVotesByArtist>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewAlbumArtistSongTotalVotesByArtist GetById(int id)
        {
            IViewAlbumArtistSongTotalVotesByArtist viewAlbumArtistSongTotalVotesByArtist = new ViewAlbumArtistSongTotalVotesByArtist();
            string sqlCommand = "viewAlbumArtistSongTotalVotesByArtistFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" viewAlbumArtistSongTotalVotesByArtistId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewAlbumArtistSongTotalVotesByArtist.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewAlbumArtistSongTotalVotesByArtist.Total = Convert.ToInt32(reader["total"].ToString());
                        viewAlbumArtistSongTotalVotesByArtist.AlbumName = reader["albumName"].ToString();
                        viewAlbumArtistSongTotalVotesByArtist.ArtistName = reader["artistName"].ToString();
                        viewAlbumArtistSongTotalVotesByArtist.AlbumCover = reader["albumCover"].ToString();
                        viewAlbumArtistSongTotalVotesByArtist.Picture = reader["picture"].ToString();
                    }
                }
            }

            return viewAlbumArtistSongTotalVotesByArtist;
        }

        #endregion GetById( int id )

        #region GetTop<IViewAlbumArtistSongTotalVotesByArtistQueryParams>(int top,IViewAlbumArtistSongTotalVotesByArtistQueryParams query )

        public IList<IViewAlbumArtistSongTotalVotesByArtist> GetTop<IViewAlbumArtistSongTotalVotesByArtistQueryParams>(int top, IViewAlbumArtistSongTotalVotesByArtistQueryParams query)
        {
            _collection = new List<IViewAlbumArtistSongTotalVotesByArtist>();
            string sqlCommand = "viewAlbumArtistSongTotalVotesByArtistGetTop";

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
                        IViewAlbumArtistSongTotalVotesByArtist viewAlbumArtistSongTotalVotesByArtist = new ViewAlbumArtistSongTotalVotesByArtist();

                        viewAlbumArtistSongTotalVotesByArtist.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewAlbumArtistSongTotalVotesByArtist.Total = Convert.ToInt32(reader["total"].ToString());
                        viewAlbumArtistSongTotalVotesByArtist.AlbumName = reader["albumName"].ToString();
                        viewAlbumArtistSongTotalVotesByArtist.ArtistName = reader["artistName"].ToString();
                        viewAlbumArtistSongTotalVotesByArtist.AlbumCover = reader["albumCover"].ToString();
                        viewAlbumArtistSongTotalVotesByArtist.Picture = reader["picture"].ToString();
                        _collection.Add(viewAlbumArtistSongTotalVotesByArtist);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewAlbumArtistSongTotalVotesByArtistQueryParams>(int top,IViewAlbumArtistSongTotalVotesByArtistQueryParams query )

        #region Find<IViewAlbumArtistSongTotalVotesByArtistQueryParams>( IViewAlbumArtistSongTotalVotesByArtistQueryParams query )

        public IList<IViewAlbumArtistSongTotalVotesByArtist> Find<IViewAlbumArtistSongTotalVotesByArtistQueryParams>(IViewAlbumArtistSongTotalVotesByArtistQueryParams query)
        {
            _collection = new List<IViewAlbumArtistSongTotalVotesByArtist>();
            string sqlCommand = "viewAlbumArtistSongTotalVotesByArtistFind";

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
                        IViewAlbumArtistSongTotalVotesByArtist model = new ViewAlbumArtistSongTotalVotesByArtist();

                        model.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        model.Total = Convert.ToInt32(reader["total"].ToString());
                        model.AlbumName = reader["albumName"].ToString();
                        model.ArtistName = reader["artistName"].ToString();
                        model.AlbumCover = reader["albumCover"].ToString();
                        model.Picture = reader["picture"].ToString();
                        _collection.Add(model);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewAlbumArtistSongTotalVotesByArtistQueryParams>( IViewAlbumArtistSongTotalVotesByArtistQueryParams query )

        #region Count<IViewAlbumArtistSongTotalVotesByArtistQueryParams>( IViewAlbumArtistSongTotalVotesByArtistQueryParams query )

        public int Count<IViewAlbumArtistSongTotalVotesByArtistQueryParams>(IViewAlbumArtistSongTotalVotesByArtistQueryParams query)
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

        #endregion Count<IViewAlbumArtistSongTotalVotesByArtistQueryParams>( IViewAlbumArtistSongTotalVotesByArtistQueryParams query )

        #region Sum<IViewAlbumArtistSongTotalVotesByArtistQueryParams>( IViewAlbumArtistSongTotalVotesByArtistQueryParams query )

        public decimal Sum<IViewAlbumArtistSongTotalVotesByArtistQueryParams>(IViewAlbumArtistSongTotalVotesByArtistQueryParams query)
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

        #endregion Sum<IViewAlbumArtistSongTotalVotesByArtistQueryParams>( IViewAlbumArtistSongTotalVotesByArtistQueryParams query )

        #region Add( IViewAlbumArtistSongTotalVotesByArtist )

        public IViewAlbumArtistSongTotalVotesByArtist Add(IViewAlbumArtistSongTotalVotesByArtist viewAlbumArtistSongTotalVotesByArtist)
        {
            string message = "IViewAlbumArtistSongTotalVotesByArtist Add not supported";
            throw new NotSupportedException(message);
        }

        #endregion Add( IViewAlbumArtistSongTotalVotesByArtist )

        #region Update( IViewAlbumArtistSongTotalVotesByArtist )

        public IViewAlbumArtistSongTotalVotesByArtist Update(IViewAlbumArtistSongTotalVotesByArtist viewAlbumArtistSongTotalVotesByArtist)
        {
            string message = "IViewAlbumArtistSongTotalVotesByArtist Update not supported";
            throw new NotSupportedException(message);
        }

        #endregion Update( IViewAlbumArtistSongTotalVotesByArtist )

        #region Remove( id)

        public bool Remove(int id)
        {
            string message = "IViewAlbumArtistSongTotalVotesByArtist Remove not supported";
            throw new NotSupportedException(message);
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewAlbumArtistSongTotalVotesByArtist> Collection
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