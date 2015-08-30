using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class Vote : IVote
    {
        #region Properties

        private int _voteId;

        public int VoteId
        {
            get { return _voteId; }
            set { _voteId = value; }
        }

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

        private int _votes;

        public int Votes
        {
            get { return _votes; }
            set { _votes = value; }
        }

        #endregion Properties

        #region Constructor

        public Vote()
        {
        }

        #endregion Constructor
    }
}