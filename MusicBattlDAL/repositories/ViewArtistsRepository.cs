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
    public class ViewArtistsRepository : IRepository<IViewArtists>
    {
        private Database _dataBase;
        private IList<IViewArtists> _collection;

        #region Constructor

        public ViewArtistsRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewArtists>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewArtists GetById(int id)
        {
            IViewArtists viewArtists = new ViewArtists();
            string sqlCommand = "viewArtistsFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" viewArtistsId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewArtists.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewArtists.Name = reader["name"].ToString();
                        viewArtists.Description = reader["description"].ToString();
                        viewArtists.Picture = reader["picture"].ToString();
                    }
                }
            }

            return viewArtists;
        }

        #endregion GetById( int id )

        #region GetTop<IViewArtistsQueryParams>(int top,IViewArtistsQueryParams query )

        public IList<IViewArtists> GetTop<IViewArtistsQueryParams>(int top, IViewArtistsQueryParams query)
        {
            _collection = new List<IViewArtists>();
            string sqlCommand = "viewArtistsGetTop";

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
                        IViewArtists viewArtists = new ViewArtists();

                        viewArtists.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewArtists.Name = reader["name"].ToString();
                        viewArtists.Description = reader["description"].ToString();
                        viewArtists.Picture = reader["picture"].ToString();
                        _collection.Add(viewArtists);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewArtistsQueryParams>(int top,IViewArtistsQueryParams query )

        #region Find<IViewArtistsQueryParams>( IViewArtistsQueryParams query )

        public IList<IViewArtists> Find<IViewArtistsQueryParams>(IViewArtistsQueryParams query)
        {
            _collection = new List<IViewArtists>();
            string sqlCommand = "viewArtistsFind";

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
                        IViewArtists viewArtists = new ViewArtists();

                        viewArtists.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewArtists.Name = reader["name"].ToString();
                        viewArtists.Description = reader["description"].ToString();
                        viewArtists.Picture = reader["picture"].ToString();
                        _collection.Add(viewArtists);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewArtistsQueryParams>( IViewArtistsQueryParams query )

        #region Count<IViewArtistsQueryParams>( IViewArtistsQueryParams query )

        public int Count<IViewArtistsQueryParams>(IViewArtistsQueryParams query)
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

        #endregion Count<IViewArtistsQueryParams>( IViewArtistsQueryParams query )

        #region Sum<IViewArtistsQueryParams>( IViewArtistsQueryParams query )

        public decimal Sum<IViewArtistsQueryParams>(IViewArtistsQueryParams query)
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

        #endregion Sum<IViewArtistsQueryParams>( IViewArtistsQueryParams query )

        #region Add( IViewArtists )

        public IViewArtists Add(IViewArtists viewArtists)
        {
            string message = "IViewArtists Add not supported";
            throw new NotSupportedException(message);
        }

        #endregion Add( IViewArtists )

        #region Update( IViewArtists )

        public IViewArtists Update(IViewArtists viewArtists)
        {
            string message = "IViewArtists Update not supported";
            throw new NotSupportedException(message);
        }

        #endregion Update( IViewArtists )

        #region Remove( id)

        public bool Remove(int id)
        {
            string message = "IViewArtists Remove not supported";
            throw new NotSupportedException(message);
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewArtists> Collection
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