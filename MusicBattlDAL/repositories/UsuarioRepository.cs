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
    public class UsuarioRepository : IRepository<IUsuario>
    {
        private Database _dataBase;
        private IList<IUsuario> _collection;

        public Database DataBase
        {
            get { return _dataBase; }
            set { _dataBase = value; }
        }

        #region Constructor

        public UsuarioRepository(Database pDataBaseAccess)
        {
            _dataBase = pDataBaseAccess;
            _collection = new List<IUsuario>();
        }

        #endregion Constructor

        #region GetById( int id )

        public IUsuario GetById(int id)
        {
            IUsuario usuario = new Usuario();

            string sqlCommand = "usuarioFind";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format(" usuarioId={0} ", id);

                _dataBase.AddInParameter(dbCmd, "@fromParam", DbType.String, query.From);
                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, query.Where);
                _dataBase.AddInParameter(dbCmd, "@orderByParam", DbType.String, query.OrderBy);

                // Call the ExecuteReader method with the command.
                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        usuario.UsuarioId = Convert.ToInt32(reader["usuarioId"].ToString());
                        usuario.Name = reader["name"].ToString();
                        usuario.Password = reader["password"].ToString();
                        usuario.Created = (DateTime)reader["created"];
                        usuario.CustomId = reader["customId"] == null ? default(string) : reader["customId"].ToString();
                        usuario.Gender = reader["gender"].ToString();
                        usuario.Birthdate = null;
                        usuario.Udated = null;
                        usuario.City = null;
                        usuario.Country = null;

                        if (reader["city"] != DBNull.Value)
                        {
                            usuario.City = reader["city"].ToString();
                        }
                        if (reader["country"] != DBNull.Value)
                        {
                            usuario.Country = reader["country"].ToString();
                        }

                        if (reader["email"] != DBNull.Value)
                        {
                            usuario.Email = reader["email"].ToString();
                        }

                        if (reader["birthdate"] != DBNull.Value)
                        {
                            usuario.Birthdate = Convert.ToDateTime(reader["birthdate"]);
                        }
                        if (reader["udated"] != DBNull.Value)
                        {
                            usuario.Udated = Convert.ToDateTime(reader["udated"]);
                        }
                    }
                }
            }

            return usuario;
        }

        #endregion GetById( int id )

        #region GetTop<IUsuarioQueryParams>(int top,IUsuarioQueryParams query )

        public IList<IUsuario> GetTop<IUsuarioQueryParams>(int top, IUsuarioQueryParams query)
        {
            _collection = new List<IUsuario>();
            string sqlCommand = "usuarioGetTop";

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
                        IUsuario usuario = new Usuario();

                        usuario.UsuarioId = Convert.ToInt32(reader["usuarioId"].ToString());
                        usuario.Name = reader["name"].ToString();
                        usuario.Password = reader["password"].ToString();
                        usuario.Created = (DateTime)reader["created"];
                        usuario.Birthdate = null;
                        usuario.Udated = null;
                        usuario.City = null;
                        usuario.Country = null;

                        if (reader["city"] != DBNull.Value)
                        {
                            usuario.City = reader["city"].ToString();
                        }
                        if (reader["country"] != DBNull.Value)
                        {
                            usuario.Country = reader["country"].ToString();
                        }

                        if (reader["birthdate"] != DBNull.Value)
                        {
                            usuario.Birthdate = Convert.ToDateTime(reader["birthdate"]);
                        }
                        if (reader["udated"] != DBNull.Value)
                        {
                            usuario.Udated = Convert.ToDateTime(reader["udated"]);
                        }

                        usuario.Gender = reader["gender"].ToString();
                        usuario.Email = reader["email"].ToString();
                        _collection.Add(usuario);
                    }
                }
            }
            return _collection;
        }

        #endregion GetTop<IUsuarioQueryParams>(int top,IUsuarioQueryParams query )

        #region Find<IUsuarioQueryParams>( IUsuarioQueryParams query )

        public IList<IUsuario> Find<IUsuarioQueryParams>(IUsuarioQueryParams query)
        {
            _collection = new List<IUsuario>();
            string sqlCommand = "usuarioFind";

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
                        IUsuario usuario = new Usuario();

                        usuario.UsuarioId = Convert.ToInt32(reader["usuarioId"].ToString());
                        usuario.Name = reader["name"].ToString();
                        usuario.CustomId = reader["customId"] == null ? default(string) : reader["customId"].ToString();

                        usuario.Birthdate = null;
                        usuario.Udated = null;

                        usuario.City = null;
                        usuario.Country = null;

                        if (reader["city"] != DBNull.Value)
                        {
                            usuario.City = reader["city"].ToString();
                        }
                        if (reader["country"] != DBNull.Value)
                        {
                            usuario.Country = reader["country"].ToString();
                        }

                        if (reader["birthdate"] != DBNull.Value)
                        {
                            usuario.Birthdate = Convert.ToDateTime(reader["birthdate"]);
                        }

                        if (reader["udated"] != DBNull.Value)
                        {
                            usuario.Udated = Convert.ToDateTime(reader["udated"]);
                        }

                        usuario.Password = reader["password"].ToString();
                        usuario.Created = (DateTime)reader["created"];
                        usuario.Gender = reader["gender"].ToString();
                        usuario.Email = reader["email"].ToString();
                        _collection.Add(usuario);
                    }
                }
            }
            return _collection;
        }

        #endregion Find<IUsuarioQueryParams>( IUsuarioQueryParams query )

        #region Count<IUsuarioQueryParams>( IUsuarioQueryParams query )

        public int Count<IUsuarioQueryParams>(IUsuarioQueryParams query)
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

        #endregion Count<IUsuarioQueryParams>( IUsuarioQueryParams query )

        #region Sum<IUsuarioQueryParams>( IUsuarioQueryParams query )

        public decimal Sum<IUsuarioQueryParams>(IUsuarioQueryParams query)
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

        #endregion Sum<IUsuarioQueryParams>( IUsuarioQueryParams query )

        #region Add( IUsuario )

        public IUsuario Add(IUsuario usuario)
        {
            IUsuario usuarioAdded = new Usuario();
            int id = 0;
            string sqlCommand = "usuarioAdd";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                DateTime? birthDate = null;

                if (usuario.Birthdate.GetValueOrDefault() != new DateTime())
                {
                    birthDate = usuario.Birthdate.Value;
                }

                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, usuario.Name);
                _dataBase.AddInParameter(dbCmd, "@birthdate", DbType.DateTime, birthDate);
                _dataBase.AddInParameter(dbCmd, "@password", DbType.String, usuario.Password);
                _dataBase.AddInParameter(dbCmd, "@created", DbType.DateTime, usuario.Created);
                _dataBase.AddInParameter(dbCmd, "@udated", DbType.DateTime, usuario.Udated);
                _dataBase.AddInParameter(dbCmd, "@gender", DbType.String, usuario.Gender);
                _dataBase.AddInParameter(dbCmd, "@customId", DbType.String, usuario.CustomId);
                _dataBase.AddInParameter(dbCmd, "@email", DbType.String, usuario.Email);
                _dataBase.AddInParameter(dbCmd, "@city", DbType.String, usuario.City);
                _dataBase.AddInParameter(dbCmd, "@country", DbType.String, usuario.Country);

                id = Convert.ToInt32(_dataBase.ExecuteScalar(dbCmd));

                usuarioAdded = this.GetById(id);
            }

            return usuarioAdded;
        }

        #endregion Add( IUsuario )

        #region Update( IUsuario )

        public IUsuario Update(IUsuario usuario)
        {
            IUsuario usuarioUpdated = new Usuario();
            string sqlCommand = "usuarioUpdate";
            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@usuarioId", DbType.Int32, usuario.UsuarioId);
                _dataBase.AddInParameter(dbCmd, "@customId", DbType.String, usuario.CustomId);
                _dataBase.AddInParameter(dbCmd, "@name", DbType.String, usuario.Name);
                _dataBase.AddInParameter(dbCmd, "@birthdate", DbType.DateTime, usuario.Birthdate);
                _dataBase.AddInParameter(dbCmd, "@password", DbType.String, usuario.Password);
                _dataBase.AddInParameter(dbCmd, "@created", DbType.DateTime, usuario.Created);
                _dataBase.AddInParameter(dbCmd, "@udated", DbType.DateTime, DateTime.Now);
                _dataBase.AddInParameter(dbCmd, "@gender", DbType.String, usuario.Gender);
                _dataBase.AddInParameter(dbCmd, "@email", DbType.String, usuario.Email);
                _dataBase.AddInParameter(dbCmd, "@city", DbType.String, usuario.City);
                _dataBase.AddInParameter(dbCmd, "@country", DbType.String, usuario.Country);

                _dataBase.ExecuteScalar(dbCmd);

                usuarioUpdated = this.GetById(usuario.UsuarioId);
            }

            return usuarioUpdated;
        }

        #endregion Update( IUsuario )

        #region Remove( id)

        public bool Remove(int id)
        {
            bool success = false;
            string sqlCommand = "usuarioRemove";

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(sqlCommand))
            {
                _dataBase.AddInParameter(dbCmd, "@usuarioId", DbType.Int32, id);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                success = (rowsAffected > 0);
            }
            return success;
        }

        #endregion Remove( id)

        #region Collection

        public IEnumerable<IUsuario> Collection
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