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
    public class ViewBattlResultsRepository : IRepository<IViewBattlResults>
    {
        private Database _dataBase;
        private IList<IViewBattlResults> _collection;

        #region Constructor

        public ViewBattlResultsRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewBattlResults>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewBattlResults GetById(int id)
        {
            IViewBattlResults viewBattlResults = new ViewBattlResults();
            string sqlCommand = "viewBattlResultsFind";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" viewBattlResultsId = {0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewBattlResults.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewBattlResults.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        viewBattlResults.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        viewBattlResults.ArtistNameSecond = reader["artistNameSecond"].ToString();
                        viewBattlResults.ArtistNameFirst = reader["artistNameFirst"].ToString();
                        viewBattlResults.TotalSecond = Convert.ToInt32(reader["totalSecond"].ToString());
                        viewBattlResults.TotalFirst = Convert.ToInt32(reader["totalFirst"].ToString());
                        viewBattlResults.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        viewBattlResults.Active = Convert.ToBoolean(reader["active"].ToString());
                    }
                }

            }


            return viewBattlResults;
        }

        #endregion GetById( int id )

        #region GetTop<IViewBattlResultsQueryParams>(int top,IViewBattlResultsQueryParams query )

        public IList<IViewBattlResults> GetTop<IViewBattlResultsQueryParams>(int top, IViewBattlResultsQueryParams query)
        {
            _collection = new List<IViewBattlResults>();
            string sqlCommand = "viewBattlResultsGetTop";
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
                        IViewBattlResults viewBattlResults = new ViewBattlResults();

                        viewBattlResults.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewBattlResults.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        viewBattlResults.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        viewBattlResults.ArtistNameSecond = reader["artistNameSecond"].ToString();
                        viewBattlResults.ArtistNameFirst = reader["artistNameFirst"].ToString();
                        viewBattlResults.TotalSecond = Convert.ToInt32(reader["totalSecond"].ToString());
                        viewBattlResults.TotalFirst = Convert.ToInt32(reader["totalFirst"].ToString());
                        viewBattlResults.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        viewBattlResults.Active = Convert.ToBoolean(reader["active"].ToString());
                        _collection.Add(viewBattlResults);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IViewBattlResultsQueryParams>(int top,IViewBattlResultsQueryParams query )

        #region Find<IViewBattlResultsQueryParams>( IViewBattlResultsQueryParams query )

        public IList<IViewBattlResults> Find<IViewBattlResultsQueryParams>(IViewBattlResultsQueryParams query)
        {
            _collection = new List<IViewBattlResults>();
            string sqlCommand = "viewBattlResultsFind";

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
                        IViewBattlResults viewBattlResults = new ViewBattlResults();

                        viewBattlResults.BattlId = Convert.ToInt32(reader["battlId"].ToString());
                        viewBattlResults.FirstSongId = Convert.ToInt32(reader["firstSongId"].ToString());
                        viewBattlResults.SecondSongId = Convert.ToInt32(reader["secondSongId"].ToString());
                        viewBattlResults.ArtistNameSecond = reader["artistNameSecond"].ToString();
                        viewBattlResults.ArtistNameFirst = reader["artistNameFirst"].ToString();
                        viewBattlResults.TotalSecond = Convert.ToInt32(reader["totalSecond"].ToString());
                        viewBattlResults.TotalFirst = Convert.ToInt32(reader["totalFirst"].ToString());
                        viewBattlResults.ProfileId = Convert.ToInt32(reader["profileId"].ToString());
                        viewBattlResults.Active = Convert.ToBoolean(reader["active"].ToString());
                        _collection.Add(viewBattlResults);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IViewBattlResultsQueryParams>( IViewBattlResultsQueryParams query )

        #region Count<IViewBattlResultsQueryParams>( IViewBattlResultsQueryParams query )

        public int Count<IViewBattlResultsQueryParams>(IViewBattlResultsQueryParams query)
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

        #endregion Count<IViewBattlResultsQueryParams>( IViewBattlResultsQueryParams query )

        #region Sum<IViewBattlResultsQueryParams>( IViewBattlResultsQueryParams query )

        public decimal Sum<IViewBattlResultsQueryParams>(IViewBattlResultsQueryParams query)
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

        #endregion Sum<IViewBattlResultsQueryParams>( IViewBattlResultsQueryParams query )

        #region Add( IViewBattlResults )

        public IViewBattlResults Add(IViewBattlResults viewBattlResults)
        {
            string message = "IViewBattlResults Add not supported";
            throw new NotSupportedException(message);
        }

        #endregion Add( IViewBattlResults )

        #region Update( IViewBattlResults )

        public IViewBattlResults Update(IViewBattlResults viewBattlResults)
        {
            string message = "IViewBattlResults Update not supported";
            throw new NotSupportedException(message);
        }

        #endregion Update( IViewBattlResults )

        #region Remove( id)

        public bool Remove(int id)
        {
            string message = "IViewBattlResults Remove not supported";
            throw new NotSupportedException(message);
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewBattlResults> Collection
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