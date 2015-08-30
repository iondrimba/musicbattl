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
    public class DiscographyRepository : IRepository<IDiscography>
    {
        private Database _dataBase;
        private IList<IDiscography> _collection;

        #region Constructor

        public DiscographyRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IDiscography>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IDiscography GetById(int id)
        {
            IDiscography retorno = new Discography();
            string sqlCommand = "discographyFind";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" discographyId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        retorno.DiscographyId = Convert.ToInt32(reader["discographyId"].ToString());
                        retorno.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                    }
                }
            }

            return retorno;
        }

        #endregion GetById( int id )

        #region GetTop<IDiscographyQueryParams>(int top,IDiscographyQueryParams query )

        public IList<IDiscography> GetTop<IDiscographyQueryParams>(int top, IDiscographyQueryParams query)
        {
            _collection = new List<IDiscography>();
            string sqlCommand = "discographyGetTop";
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
                        IDiscography discography = new Discography();

                        discography.DiscographyId = Convert.ToInt32(reader["discographyId"].ToString());
                        discography.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        _collection.Add(discography);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<IDiscographyQueryParams>(int top,IDiscographyQueryParams query )

        #region Find<IDiscographyQueryParams>( IDiscographyQueryParams query )

        public IList<IDiscography> Find<IDiscographyQueryParams>(IDiscographyQueryParams query)
        {
            _collection = new List<IDiscography>();
            string sqlCommand = "discographyFind";
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
                        IDiscography discography = new Discography();

                        discography.DiscographyId = Convert.ToInt32(reader["discographyId"].ToString());
                        discography.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        _collection.Add(discography);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<IDiscographyQueryParams>( IDiscographyQueryParams query )

        #region Count<IDiscographyQueryParams>( IDiscographyQueryParams query )

        public int Count<IDiscographyQueryParams>(IDiscographyQueryParams query)
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

        #endregion Count<IDiscographyQueryParams>( IDiscographyQueryParams query )

        #region Sum<IDiscographyQueryParams>( IDiscographyQueryParams query )

        public decimal Sum<IDiscographyQueryParams>(IDiscographyQueryParams query)
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

        #endregion Sum<IDiscographyQueryParams>( IDiscographyQueryParams query )

        #region Add( IDiscography )

        public IDiscography Add(IDiscography discography)
        {
            IDiscography retorno = new Discography();
            int id = 0;

            IDiscography discographyAdded = new Discography();
            string sqlCommand = "discographyAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@artistId", DbType.Int32, discography.ArtistId);
                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));
                discographyAdded = this.GetById(id);
            }

            return discographyAdded;
        }

        #endregion Add( IDiscography )

        #region Update( IDiscography )

        public IDiscography Update(IDiscography discography)
        {
            IDiscography discographyUpdated = new Discography();
            string sqlCommand = "discographyUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@discographyId", DbType.Int32, discography.DiscographyId);
                _dataBase.AddInParameter(dbCmd, "@artistId", DbType.Int32, discography.ArtistId);

                _dataBase.ExecuteScalar(dbCmd);
                discographyUpdated = this.GetById(discography.DiscographyId);
            }

            return discographyUpdated;
        }

        #endregion Update( IDiscography )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;

            string sqlCommand = "discographyRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@discographyId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IDiscography> Collection
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