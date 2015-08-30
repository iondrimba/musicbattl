using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IVoteBLL
    {
        IList<IVote> CanGetVotesBySong( int artistId );

        IList<IVote> GetVotesByUserprofile( int profileId );

        IVote VoteOnArtist( IVote vote );
    }
}