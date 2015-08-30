using MusicBattlBLL.interfaces;
using MusicBattlDAL;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MusicBattlBLL.models
{
    public class VoteBLL : IVoteBLL
    {
        private IRepositoryBLL<IVote> _voteRepository;
        private IDataBaseAccess _dataBaseAccess;

        public VoteBLL(IRepositoryBLL<IVote> voteRepository)
        {
            _voteRepository = voteRepository;
            _dataBaseAccess = _voteRepository.repositorieDAL.DataBaseAccess;
        }

        #region IRepositoryBLL<IVote> CanGetVotesBySong( int songId )

        public IList<IVote> CanGetVotesBySong(int songId)
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format("songId={0}", songId);

            IList<IVote> retorno = CanGetVotesByWhere(query.Where);

            return retorno;
        }

        private IList<IVote> CanGetVotesByWhere(string pWhere)
        {
            IDataQuery query = new DataQuery();
            query.Where = pWhere;

            IList<IVote> retorno = _voteRepository.Find(query);

            return retorno;
        }

        #endregion IRepositoryBLL<IVote> CanGetVotesBySong( int songId )

        #region IRepositoryBLL<IVote> GetVotesByUserprofile( int profileId )

        public IList<IVote> GetVotesByUserprofile(int profileId)
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format("profileId={0}", profileId);

            IList<IVote> retorno = _voteRepository.Find(query);

            return retorno;
        }

        #endregion IRepositoryBLL<IVote> GetVotesByUserprofile( int profileId )

        #region bool VoteOnArtist( IVote vote )

        public IVote VoteOnArtist(IVote vote)
        {
            IVote voteAdded = new Vote();

            IDataQuery query = new DataQuery();
            query.Where = string.Format("profileId={0} and songId={1} and battlId={2}", vote.ProfileId, vote.SongId, vote.BattlId);
            IVote result = _voteRepository.Find(query).FirstOrDefault();
            if (result != null)
            {
                vote.VoteId = result.VoteId;
                vote.Votes = result.Votes + 1;
                voteAdded = _voteRepository.Update(vote);
            }
            else
            {
                voteAdded = _voteRepository.Add(vote);
            }

            query.Where = string.Format("songId={0} and battlId={1}", vote.SongId, vote.BattlId);
            int resultTotal = CanGetVotesByWhere(query.Where).Sum(m => m.Votes);
            vote.Votes = resultTotal;

            return voteAdded;
        }

        #endregion bool VoteOnArtist( IVote vote )
    }
}