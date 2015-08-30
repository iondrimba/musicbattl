using System;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class AccountUser : IUsuario , IProfile
    {
        private int _usuarioId;
        private string _customId;
        private string _name = string.Empty;
        private DateTime? _birthdate = null;
        private string _password;
        private DateTime _created = DateTime.Now;
        private DateTime? _udated = null;
        private string _gender = "U";
        private int _profileId;
        private string _city;
        private string _country;
        private string _email;
        private string _picture;
        private bool _removed;

        #region IUsuario Members

        public int UsuarioId
        {
            get
            {
                return _usuarioId;
            }
            set
            {
                _usuarioId = value;
            }
        }

        public string CustomId
        {
            get { return _customId; }
            set { _customId = value; }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public DateTime? Birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                _birthdate = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public DateTime Created
        {
            get
            {
                return _created;
            }
            set
            {
                _created = value;
            }
        }

        public DateTime? Udated
        {
            get
            {
                return _udated;
            }
            set
            {
                _udated = value;
            }
        }

        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        #endregion IUsuario Members

        #region IProfile Members

        public int ProfileId
        {
            get
            {
                return _profileId;
            }
            set
            {
                _profileId = value;
            }
        }

        public int UserId
        {
            get
            {
                return _usuarioId;
            }
            set
            {
                _usuarioId = value;
            }
        }

        public string Picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _picture = value;
            }
        }

        public DateTime Upadted
        {
            get
            {
                return _udated.GetValueOrDefault();
            }
            set
            {
                _udated = value;
            }
        }

        public bool Removed
        {
            get
            {
                return _removed;
            }
            set
            {
                _removed = value;
            }
        }

        #endregion IProfile Members
    }
}