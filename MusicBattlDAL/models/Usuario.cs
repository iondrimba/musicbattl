using System;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class Usuario : IUsuario
    {
        #region Properties

        private int _usuarioId;

        public int UsuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        private string _customId;

        public string CustomId
        {
            get { return _customId; }
            set { _customId = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private DateTime? _birthdate;

        public DateTime? Birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private DateTime _created;

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        private DateTime? _udated;

        public DateTime? Udated
        {
            get { return _udated; }
            set { _udated = value; }
        }

        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        #endregion Properties

        #region Constructor

        public Usuario()
        {
        }

        #endregion Constructor
    }
}