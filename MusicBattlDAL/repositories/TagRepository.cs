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
    public class TagRepository : IRepository<ITag>
    {
        private Database _dataBase;
        private IList<ITag> _collection;

        #region Constructor

        public TagRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<ITag>();
        }

        #endregion Constructor

        #region GetById( int id )

        public ITag GetById(int id)
        {
            ITag tag = new Tag();
            string sqlCommand = "tagFind";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" tagId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        tag.TagId = Convert.ToInt32(reader["tagId"].ToString());
                        tag.OwnerTableId = Convert.ToInt32(reader["ownerTableId"].ToString());
                        tag.OwnerId = Convert.ToInt32(reader["ownerId"].ToString());
                        tag.Name = reader["name"].ToString();
                    }
                }
            }

            return tag;
        }

        #endregion GetById( int id )

        #region GetTop<ITagQueryParams>(int top,ITagQueryParams query )

        public IList<ITag> GetTop<ITagQueryParams>(int top, ITagQueryParams query)
        {
            _collection = new List<ITag>();
            string sqlCommand = "tagGetTop";
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
                        ITag tag = new Tag();

                        tag.TagId = Convert.ToInt32(reader["tagId"].ToString());
                        tag.OwnerTableId = Convert.ToInt32(reader["ownerTableId"].ToString());
                        tag.OwnerId = Convert.ToInt32(reader["ownerId"].ToString());
                        tag.Name = reader["name"].ToString();
                        _collection.Add(tag);
                    }
                }
            }

            return _collection;
        }

        #endregion GetTop<ITagQueryParams>(int top,ITagQueryParams query )

        #region Find<ITagQueryParams>( ITagQueryParams query )

        public IList<ITag> Find<ITagQueryParams>(ITagQueryParams query)
        {
            _collection = new List<ITag>();
            string sqlCommand = "tagFind";
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
                        ITag tag = new Tag();

                        tag.TagId = Convert.ToInt32(reader["tagId"].ToString());
                        tag.OwnerTableId = Convert.ToInt32(reader["ownerTableId"].ToString());
                        tag.OwnerId = Convert.ToInt32(reader["ownerId"].ToString());
                        tag.Name = reader["name"].ToString();
                        _collection.Add(tag);
                    }
                }
            }

            return _collection;
        }

        #endregion Find<ITagQueryParams>( ITagQueryParams query )

        #region Count<ITagQueryParams>( ITagQueryParams query )

        public int Count<ITagQueryParams>(ITagQueryParams query)
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

        #endregion Count<ITagQueryParams>( ITagQueryParams query )

        #region Sum<ITagQueryParams>( ITagQueryParams query )

        public decimal Sum<ITagQueryParams>(ITagQueryParams query)
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

        #endregion Sum<ITagQueryParams>( ITagQueryParams query )

        #region Add( ITag )

        public ITag Add(ITag tag)
        {
            ITag retorno = new Tag();
            int id = 0;

            ITag tagAdded = new Tag();
            string sqlCommand = "tagAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@ownerTableId", DbType.Int32, tag.OwnerTableId);
                _dataBase.AddInParameter(dbCmd, "@ownerId", DbType.Int32, tag.OwnerId);
                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, tag.Name);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));

                retorno = this.GetById(id);
            }

            return tagAdded;
        }

        #endregion Add( ITag )

        #region Update( ITag )

        public ITag Update(ITag tag)
        {
            ITag tagUpdated = new Tag();
            string sqlCommand = "tagUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@tagId", DbType.Int32, tag.TagId);
                _dataBase.AddInParameter(dbCmd, "@ownerTableId", DbType.Int32, tag.OwnerTableId);
                _dataBase.AddInParameter(dbCmd, "@ownerId", DbType.Int32, tag.OwnerId);
                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, tag.Name);

                _dataBase.ExecuteScalar(dbCmd);

                tagUpdated = this.GetById(tag.TagId);
            }

            return tagUpdated;
        }

        #endregion Update( ITag )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;

            string sqlCommand = "tagRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@tagId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<ITag> Collection
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