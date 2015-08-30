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
    public class ViewArtistContactRepository : IRepository<IViewArtistContact>
    {
        private Database _dataBase;
        private IList<IViewArtistContact> _collection;

        #region Constructor

        public ViewArtistContactRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IViewArtistContact>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IViewArtistContact GetById(int id)
        {
            IViewArtistContact viewArtistContact = new ViewArtistContact();
            string sqlCommand = "viewArtistContactFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" artistId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        viewArtistContact.Name = reader["name"].ToString();
                        viewArtistContact.Description = reader["description"].ToString();
                        viewArtistContact.Picture = reader["picture"].ToString();
                        viewArtistContact.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewArtistContact.IdArtistContact = Convert.ToInt32(reader["idArtistContact"].ToString());
                        viewArtistContact.Bandcamp = reader["bandcamp"].ToString();
                        viewArtistContact.Soundcloud = reader["soundcloud"].ToString();
                        viewArtistContact.Website = reader["website"].ToString();
                        viewArtistContact.Tumblr = reader["tumblr"].ToString();
                        viewArtistContact.Facebook = reader["facebook"].ToString();
                        viewArtistContact.Twitter = reader["twitter"].ToString();
                        viewArtistContact.Email = reader["email"].ToString();
                    }
                }
            }

            return viewArtistContact;
        }

        #endregion GetById( int id )

        #region GetTop<IViewArtistContactQueryParams>(int top,IViewArtistContactQueryParams query )

        public IList<IViewArtistContact> GetTop<IViewArtistContactQueryParams>(int top, IViewArtistContactQueryParams query)
        {
            _collection = new List<IViewArtistContact>();
            string sqlCommand = "viewArtistContactGetTop";

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
                        IViewArtistContact viewArtistContact = new ViewArtistContact();

                        viewArtistContact.Name = reader["name"].ToString();
                        viewArtistContact.Description = reader["description"].ToString();
                        viewArtistContact.Picture = reader["picture"].ToString();
                        viewArtistContact.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewArtistContact.IdArtistContact = Convert.ToInt32(reader["idArtistContact"].ToString());
                        viewArtistContact.Bandcamp = reader["bandcamp"].ToString();
                        viewArtistContact.Soundcloud = reader["soundcloud"].ToString();
                        viewArtistContact.Website = reader["website"].ToString();
                        viewArtistContact.Tumblr = reader["tumblr"].ToString();
                        viewArtistContact.Facebook = reader["facebook"].ToString();
                        viewArtistContact.Twitter = reader["twitter"].ToString();
                        viewArtistContact.Email = reader["email"].ToString();
                        _collection.Add(viewArtistContact);
                    }
                }
            }
            return _collection;
        }

        #endregion GetTop<IViewArtistContactQueryParams>(int top,IViewArtistContactQueryParams query )

        #region Find<IViewArtistContactQueryParams>( IViewArtistContactQueryParams query )

        public IList<IViewArtistContact> Find<IViewArtistContactQueryParams>(IViewArtistContactQueryParams query)
        {
            _collection = new List<IViewArtistContact>();
            string sqlCommand = "viewArtistContactFind";

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
                        IViewArtistContact viewArtistContact = new ViewArtistContact();

                        viewArtistContact.Name = reader["name"].ToString();
                        viewArtistContact.Description = reader["description"].ToString();
                        viewArtistContact.Picture = reader["picture"].ToString();
                        viewArtistContact.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewArtistContact.IdArtistContact = Convert.ToInt32(reader["idArtistContact"].ToString());
                        viewArtistContact.Bandcamp = reader["bandcamp"].ToString();
                        viewArtistContact.Soundcloud = reader["soundcloud"].ToString();
                        viewArtistContact.Website = reader["website"].ToString();
                        viewArtistContact.Tumblr = reader["tumblr"].ToString();
                        viewArtistContact.Facebook = reader["facebook"].ToString();
                        viewArtistContact.Twitter = reader["twitter"].ToString();
                        viewArtistContact.Email = reader["email"].ToString();
                        _collection.Add(viewArtistContact);
                    }
                }
            }
            return _collection;
        }

        #endregion Find<IViewArtistContactQueryParams>( IViewArtistContactQueryParams query )

        #region Count<IViewArtistContactQueryParams>( IViewArtistContactQueryParams query )

        public int Count<IViewArtistContactQueryParams>(IViewArtistContactQueryParams query)
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

        #endregion Count<IViewArtistContactQueryParams>( IViewArtistContactQueryParams query )

        #region Sum<IViewArtistContactQueryParams>( IViewArtistContactQueryParams query )

        public decimal Sum<IViewArtistContactQueryParams>(IViewArtistContactQueryParams query)
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

        #endregion Sum<IViewArtistContactQueryParams>( IViewArtistContactQueryParams query )

        #region Add( IViewArtistContact )

        public IViewArtistContact Add(IViewArtistContact viewArtistContact)
        {
            string message = "IViewArtistContact Add not supported";
            throw new NotSupportedException(message);
        }

        #endregion Add( IViewArtistContact )

        #region Update( IViewArtistContact )

        public IViewArtistContact Update(IViewArtistContact viewArtistContact)
        {
            string message = "IViewArtistContact Update not supported";
            throw new NotSupportedException(message);
        }

        #endregion Update( IViewArtistContact )

        #region Remove( id)

        public bool Remove(int id)
        {
            string message = "IViewArtistContact Remove not supported";
            throw new NotSupportedException(message);
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IViewArtistContact> Collection
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