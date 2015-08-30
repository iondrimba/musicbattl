using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewTopUsers : IViewTopUsers
    {
        #region Properties

        private int _profileId;

        public int ProfileId
        {
            get { return _profileId; }
            set { _profileId = value; }
        }

        private int _usuarioId;

        public int UsuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        private int? _totalVotes;

        public int? TotalVotes
        {
            get { return _totalVotes; }
            set { _totalVotes = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _picture;

        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        #endregion Properties

        #region Constructor

        public ViewTopUsers()
        {
        }

        #endregion Constructor
    }
}