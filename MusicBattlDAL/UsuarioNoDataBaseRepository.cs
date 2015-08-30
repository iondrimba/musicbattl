using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class UsuarioNoDataBaseRepository : IRepository<IUsuario>
    {
        private IDataBaseAccess _dataBaseAccess;
        private IList<IUsuario> _collection;

        #region Constructor

        public UsuarioNoDataBaseRepository( IDataBaseAccess pDataBaseAccess )
        {
            _dataBaseAccess = pDataBaseAccess;
            _collection = new List<IUsuario>();

            Assembly assembly = Assembly.LoadFile(@"E:\projetos\musicmatch\MusicBattl\MusicBattlDAL\bin\Debug\MusicBattlDAL.dll");
            Type T = assembly.GetType(string.Format("MusicBattlDAL.Usuario"));
            PropertyInfo[] propertiesList = T.GetProperties();

            List<string> properties = new List<string>();

            foreach( PropertyInfo item in propertiesList )
            {
                properties.Add(item.Name);
            }
        }

        #endregion Constructor

        #region GetById( int id )

        public IUsuario GetById( int id )
        {
            IUsuario retorno = new Usuario();

            var result = _dataBaseAccess.GetMockData<IUsuario>().Where(m => m.UsuarioId == id).SingleOrDefault();

            retorno = (IUsuario)result;

            return retorno;
        }

        #endregion GetById( int id )

        #region Find<IUsuarioQueryParams>( IUsuarioQueryParams query )

        public IList<IUsuario> Find<IUsuarioQueryParams>( IUsuarioQueryParams query )
        {
            IList<IUsuario> retorno = new List<IUsuario>();

            var result = _dataBaseAccess.GetMockData<IUsuario>().AsQueryable()
                                         .Where(((IDataQuery)query).Where).ToList();
            retorno = result.ToList();

            return retorno;
        }

        #endregion Find<IUsuarioQueryParams>( IUsuarioQueryParams query )

        #region Count<IUsuarioQueryParams>( IUsuarioQueryParams query )

        public int Count<IUsuarioQueryParams>( IUsuarioQueryParams query )
        {
            int retorno = 0;

            string strCommand = "countByParams";

            IDbCommand command = _dataBaseAccess.GetCommand(strCommand , CommandType.StoredProcedure);

            command.Parameters.Clear();
            _dataBaseAccess.AddParameter("fromParam" , ((IDataQuery)query).From);
            _dataBaseAccess.AddParameter("whereParam" , ((IDataQuery)query).Where);

            retorno = (int)command.ExecuteScalar();

            return retorno;
        }

        #endregion Count<IUsuarioQueryParams>( IUsuarioQueryParams query )

        #region Sum<IUsuarioQueryParams>( IUsuarioQueryParams query )

        public decimal Sum<IUsuarioQueryParams>( IUsuarioQueryParams query )
        {
            decimal retorno = 0;

            string strCommand = "sumByParams";

            IDbCommand command = _dataBaseAccess.GetCommand(strCommand , CommandType.StoredProcedure);
            _dataBaseAccess.AddParameter("fromParam" , ((IDataQuery)query).From);
            _dataBaseAccess.AddParameter("whereParam" , ((IDataQuery)query).Where);
            _dataBaseAccess.AddParameter("columnParam" , ((IDataQuery)query).Column);

            retorno = Convert.ToDecimal(command.ExecuteScalar());

            return retorno;
        }

        #endregion Sum<IUsuarioQueryParams>( IUsuarioQueryParams query )

        #region Add( IUsuario )

        public IUsuario Add( IUsuario usuario )
        {
            IUsuario retorno = new Usuario();
            int id = 0;

            string strCommand = "usuarioAdd";

            IDbCommand command = _dataBaseAccess.GetCommand(strCommand , CommandType.StoredProcedure);

            _dataBaseAccess.AddParameter("name" , usuario.Name);
            _dataBaseAccess.AddParameter("birthdate" , usuario.Birthdate);
            _dataBaseAccess.AddParameter("password" , usuario.Password);
            _dataBaseAccess.AddParameter("updated" , usuario.Udated);
            _dataBaseAccess.AddParameter("gender" , usuario.Gender);

            id = Convert.ToInt32(command.ExecuteScalar());

            retorno = this.GetById(id);

            return retorno;
        }

        #endregion Add( IUsuario )

        #region Update( IUsuario )

        public IUsuario Update( IUsuario usuario )
        {
            IUsuario retorno = new Usuario();

            string strCommand = "usuarioUpdate";

            IDbCommand command = _dataBaseAccess.GetCommand(strCommand , CommandType.StoredProcedure);

            _dataBaseAccess.AddParameter("usuarioid" , usuario.UsuarioId);
            _dataBaseAccess.AddParameter("name" , usuario.Name);
            _dataBaseAccess.AddParameter("birthdate" , usuario.Birthdate);
            _dataBaseAccess.AddParameter("password" , usuario.Password);
            _dataBaseAccess.AddParameter("gender" , usuario.Gender);

            command.ExecuteScalar();

            retorno = this.GetById(usuario.UsuarioId);

            return retorno;
        }

        #endregion Update( IUsuario )

        #region Remove( id)

        public bool Remove( int id )
        {
            bool retorno = false;

            string strCommand = "usuarioRemove";

            IDbCommand command = _dataBaseAccess.GetCommand(strCommand , CommandType.StoredProcedure);
            _dataBaseAccess.AddParameter("usuarioId" , id);
            int rowsAffected = command.ExecuteNonQuery();

            retorno = (rowsAffected > 0);

            return retorno;
        }

        #endregion Remove( id)

        #region IRepository<IUsuario> Members

        public IEnumerable<IUsuario> Collection
        {
            get { return _collection; }
        }

        #endregion IRepository<IUsuario> Members

        #region IRepository<IUsuario> Members

        public IList<IUsuario> GetTop<Q>( int top , Q query )
        {
            throw new NotImplementedException();
        }

        #endregion IRepository<IUsuario> Members

        #region IRepository<IUsuario> Members

        public IDataBaseAccess DataBaseAccess
        {
            get { return _dataBaseAccess; }
        }

        #endregion IRepository<IUsuario> Members
    }
}