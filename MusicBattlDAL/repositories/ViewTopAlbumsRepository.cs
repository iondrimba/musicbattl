using Microsoft.Practices.EnterpriseLibrary.Data;
using MusicBattlDAL;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace MusicBattlBLL
{
    public partial class ViewTopAlbumsRepository : IRepository<IViewTopAlbums>
    {
        private Database _dataBase;
        private IList<IViewTopAlbums> _collection;

        #region Constructor

        public ViewTopAlbumsRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewTopAlbums>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewTopAlbums GetById(int id)
        {
            IViewTopAlbums viewTopAlbums = new ViewTopAlbums();
            string sqlCommand = "viewTopAlbumsFind";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" viewTopAlbumsId = {0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewTopAlbums.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewTopAlbums.TotalVotes = Convert.ToInt32(reader["totalVotes"].ToString());
                        viewTopAlbums.AlbumName = reader["albumName"].ToString();
                        viewTopAlbums.ArtistName = reader["artistName"].ToString();
                        viewTopAlbums.AlbumCover = reader["albumCover"].ToString();
                        viewTopAlbums.BattlDate = (DateTime)reader["battlDate"];
                    }
                }
            }

            return viewTopAlbums;
        }

        #endregion GetById( int id )

        #region GetTop<IViewTopAlbumsQueryParams>(int top,IViewTopAlbumsQueryParams query )

        public IList<IViewTopAlbums> GetTop<IViewTopAlbumsQueryParams>(int top, IViewTopAlbumsQueryParams query)
        {
            _collection = new List<IViewTopAlbums>();
            string sqlCommand = "viewTopAlbumsGetTop";
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
                        IViewTopAlbums viewTopAlbums = new ViewTopAlbums();

                        viewTopAlbums.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewTopAlbums.TotalVotes = Convert.ToInt32(reader["totalVotes"].ToString());
                        viewTopAlbums.AlbumName = reader["albumName"].ToString();
                        viewTopAlbums.ArtistName = reader["artistName"].ToString();
                        viewTopAlbums.AlbumCover = reader["albumCover"].ToString();
                        viewTopAlbums.BattlDate = (DateTime)reader["battlDate"];
                        _collection.Add(viewTopAlbums);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewTopAlbumsQueryParams>(int top,IViewTopAlbumsQueryParams query )

        #region Find<IViewTopAlbumsQueryParams>( IViewTopAlbumsQueryParams query )

        public IList<IViewTopAlbums> Find<IViewTopAlbumsQueryParams>(IViewTopAlbumsQueryParams query)
        {
            _collection = new List<IViewTopAlbums>();
            string sqlCommand = "viewTopAlbumsFind";

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
                        IViewTopAlbums viewTopAlbums = new ViewTopAlbums();

                        viewTopAlbums.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewTopAlbums.TotalVotes = Convert.ToInt32(reader["totalVotes"].ToString());
                        viewTopAlbums.AlbumName = reader["albumName"].ToString();
                        viewTopAlbums.ArtistName = reader["artistName"].ToString();
                        viewTopAlbums.AlbumCover = reader["albumCover"].ToString();
                        viewTopAlbums.BattlDate = (DateTime)reader["battlDate"];
                        _collection.Add(viewTopAlbums);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewTopAlbumsQueryParams>( IViewTopAlbumsQueryParams query )

        #region Count<IViewTopAlbumsQueryParams>( IViewTopAlbumsQueryParams query )

        public int Count<IViewTopAlbumsQueryParams>(IViewTopAlbumsQueryParams query)
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

        #endregion Count<IViewTopAlbumsQueryParams>( IViewTopAlbumsQueryParams query )

        #region Sum<IViewTopAlbumsQueryParams>( IViewTopAlbumsQueryParams query )

        public decimal Sum<IViewTopAlbumsQueryParams>(IViewTopAlbumsQueryParams query)
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

        #endregion Sum<IViewTopAlbumsQueryParams>( IViewTopAlbumsQueryParams query )

        #region Add( IViewTopAlbums )

        public IViewTopAlbums Add(IViewTopAlbums viewTopAlbums)
        {
            string message = "IViewTopAlbums Add not supported";
            throw new NotSupportedException(message);
        }

        #endregion Add( IViewTopAlbums )

        #region Update( IViewTopAlbums )

        public IViewTopAlbums Update(IViewTopAlbums viewTopAlbums)
        {
            string message = "IViewTopAlbums Update not supported";
            throw new NotSupportedException(message);
        }

        #endregion Update( IViewTopAlbums )

        #region Remove( id)

        public bool Remove(int id)
        {
            string message = "IViewTopAlbums Remove not supported";
            throw new NotSupportedException(message);
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewTopAlbums> Collection
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