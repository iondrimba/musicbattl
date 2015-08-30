using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ViewUserTotalVotes : IViewUserTotalVotes
    {
        #region Properties

        private int? _battlId;

        public int? BattlId
        {
            get { return _battlId; }
            set { _battlId = value; }
        }

        private int _songId;

        public int SongId
        {
            get { return _songId; }
            set { _songId = value; }
        }

        private int _profileId;

        public int ProfileId
        {
            get { return _profileId; }
            set { _profileId = value; }
        }

        private int? _total;

        public int? Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _usuarioId;

        public int UsuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        private string _picture;

        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        private string _songName;

        public string SongName
        {
            get { return _songName; }
            set { _songName = value; }
        }

        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        #endregion Properties

        #region Constructor

        public ViewUserTotalVotes()
        {
        }

        #endregion Constructor
    }
}