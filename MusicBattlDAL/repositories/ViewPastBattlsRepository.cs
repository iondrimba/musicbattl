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
    public class ViewPastBattlsRepository : IRepository<IViewPastBattls>
    {
        private Database _dataBase;
        private IList<IViewPastBattls> _collection;

        #region Constructor

        public ViewPastBattlsRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewPastBattls>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewPastBattls GetById(int id)
        {
            IViewPastBattls retorno = new ViewPastBattls();
            string sqlCommand = "viewPastBattlsFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" BattlId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        IViewPastBattls viewPastBattls = new ViewPastBattls();

                        viewPastBattls.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewPastBattls.FirstArtistId = Convert.ToInt32(reader["firstArtistId"].ToString());
                        viewPastBattls.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        viewPastBattls.FirstSongName = reader["firstSongName"].ToString();
                        viewPastBattls.FirstAlbumName = reader["firstAlbumName"].ToString();
                        viewPastBattls.FirstArtistName = reader["firstArtistName"].ToString();
                        viewPastBattls.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        viewPastBattls.SecondSongName = reader["secondSongName"].ToString();
                        viewPastBattls.SecondAlbumName = reader["secondAlbumName"].ToString();
                        viewPastBattls.SecondArtistName = reader["secondArtistName"].ToString();
                        viewPastBattls.FirstAlbumCover = reader["firstAlbumCover"].ToString();
                        viewPastBattls.SecondAlbumCover = reader["secondAlbumCover"].ToString();
                        viewPastBattls.TotalSecond = Convert.ToInt32(reader["totalSecond"].ToString());
                        viewPastBattls.TotalFirst = Convert.ToInt32(reader["totalFirst"].ToString());
                        viewPastBattls.FirstSoundCloudUrl = reader["firstSoundCloudUrl"].ToString();
                        viewPastBattls.SecondSoundCloudUrl = reader["secondSoundCloudUrl"].ToString();

                        viewPastBattls.Active = Convert.ToBoolean(reader["active"].ToString());
                        _collection.Add(viewPastBattls);

                        retorno = viewPastBattls;
                    }
                }
            }

            return retorno;
        }

        #endregion GetById( int id )

        #region GetTop<IViewPastBattlsQueryParams>(int top,IViewPastBattlsQueryParams query )

        public IList<IViewPastBattls> GetTop<IViewPastBattlsQueryParams>(int top, IViewPastBattlsQueryParams query)
        {
            _collection = new List<IViewPastBattls>();
            string sqlCommand = "viewPastBattlsGetTop";

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
                        IViewPastBattls viewPastBattls = new ViewPastBattls();

                        viewPastBattls.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewPastBattls.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        viewPastBattls.FirstAlbumId = Convert.ToInt32(reader["firstAlbumId"].ToString());
                        viewPastBattls.FirstArtistId = Convert.ToInt32(reader["firstArtistId"].ToString());
                        viewPastBattls.FirstSongName = reader["firstSongName"].ToString();
                        viewPastBattls.FirstAlbumName = reader["firstAlbumName"].ToString();
                        viewPastBattls.FirstArtistName = reader["firstArtistName"].ToString();
                        viewPastBattls.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        viewPastBattls.SecondAlbumId = Convert.ToInt32(reader["secondAlbumId"].ToString());
                        viewPastBattls.SecondArtistId = Convert.ToInt32(reader["secondArtistId"].ToString());
                        viewPastBattls.SecondSongName = reader["secondSongName"].ToString();
                        viewPastBattls.SecondAlbumName = reader["secondAlbumName"].ToString();
                        viewPastBattls.SecondArtistName = reader["secondArtistName"].ToString();
                        viewPastBattls.FirstAlbumCover = reader["firstAlbumCover"].ToString();
                        viewPastBattls.SecondAlbumCover = reader["secondAlbumCover"].ToString();
                        viewPastBattls.FirstSoundCloudUrl = reader["firstSoundCloudUrl"].ToString();
                        viewPastBattls.SecondSoundCloudUrl = reader["secondSoundCloudUrl"].ToString();

                        viewPastBattls.Active = Convert.ToBoolean(reader["active"].ToString());
                        _collection.Add(viewPastBattls);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewPastBattlsQueryParams>(int top,IViewPastBattlsQueryParams query )

        #region Find<IViewPastBattlsQueryParams>( IViewPastBattlsQueryParams query )

        public IList<IViewPastBattls> Find<IViewPastBattlsQueryParams>(IViewPastBattlsQueryParams query)
        {
            _collection = new List<IViewPastBattls>();
            string sqlCommand = "viewPastBattlsFind";

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
                        IViewPastBattls viewPastBattls = new ViewPastBattls();

                        viewPastBattls.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewPastBattls.FirstArtistId = Convert.ToInt32(reader["firstArtistId"].ToString());
                        viewPastBattls.FirstSongName = reader["firstSongName"].ToString();
                        viewPastBattls.FirstAlbumName = reader["firstAlbumName"].ToString();
                        viewPastBattls.FirstArtistName = reader["firstArtistName"].ToString();
                        viewPastBattls.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        viewPastBattls.SecondSongName = reader["secondSongName"].ToString();
                        viewPastBattls.SecondAlbumName = reader["secondAlbumName"].ToString();
                        viewPastBattls.SecondArtistName = reader["secondArtistName"].ToString();
                        viewPastBattls.FirstAlbumCover = reader["firstAlbumCover"].ToString();
                        viewPastBattls.SecondAlbumCover = reader["secondAlbumCover"].ToString();
                        viewPastBattls.TotalSecond = Convert.ToInt32(reader["totalSecond"].ToString());
                        viewPastBattls.TotalFirst = Convert.ToInt32(reader["totalFirst"].ToString());
                        viewPastBattls.FirstSoundCloudUrl = reader["firstSoundCloudUrl"].ToString();
                        viewPastBattls.SecondSoundCloudUrl = reader["secondSoundCloudUrl"].ToString();
                        viewPastBattls.Active = Convert.ToBoolean(reader["active"].ToString());
                        _collection.Add(viewPastBattls);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewPastBattlsQueryParams>( IViewPastBattlsQueryParams query )

        #region Count<IViewPastBattlsQueryParams>( IViewPastBattlsQueryParams query )

        public int Count<IViewPastBattlsQueryParams>(IViewPastBattlsQueryParams query)
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

        #endregion Count<IViewPastBattlsQueryParams>( IViewPastBattlsQueryParams query )

        #region Sum<IViewPastBattlsQueryParams>( IViewPastBattlsQueryParams query )

        public decimal Sum<IViewPastBattlsQueryParams>(IViewPastBattlsQueryParams query)
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

        #endregion Sum<IViewPastBattlsQueryParams>( IViewPastBattlsQueryParams query )

        #region Add( IViewPastBattls )

        public IViewPastBattls Add(IViewPastBattls viewPastBattls)
        {
            string message = "IViewPastBattls Add not supported";
            throw new NotSupportedException(message);
        }

        #endregion Add( IViewPastBattls )

        #region Update( IViewPastBattls )

        public IViewPastBattls Update(IViewPastBattls viewPastBattls)
        {
            string message = "IViewPastBattls Update not supported";
            throw new NotSupportedException(message);
        }

        #endregion Update( IViewPastBattls )

        #region Remove( id)

        public bool Remove(int id)
        {
            string message = "IViewPastBattls Remove not supported";
            throw new NotSupportedException(message);
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewPastBattls> Collection
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