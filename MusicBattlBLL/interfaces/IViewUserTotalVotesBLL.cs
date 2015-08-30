using System.Collections.Generic;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IViewUserTotalVotesBLL
    {
        IList<IViewUserTotalVotes> GetTopMostVotesByUser( int page = 0 , int rowCount = 0 );

        IList<IViewUserTotalVotes> GetTopMostVotesSongsByUser( int page = 0 , int rowCount = 0 );
    }
}