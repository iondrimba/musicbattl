using System.Web.Http;
using MusicBattlBLL.interfaces;

namespace MusicBattlWebAPI.Controllers
{
    public class TopUsersController : ApiController
    {
        private IViewUserTotalVotesBLL model;

        #region TopUsersController( IViewUserTotalVotesBLL model )

        public TopUsersController( IViewUserTotalVotesBLL model )
        {
            this.model = model;
        }

        #endregion TopUsersController( IViewUserTotalVotesBLL model )

        //[CacheClient(Duration = 120)]
        #region IEnumerable<IViewUserTotalVotes> Get()

        public IViewUserTotalVotesBLL Get( int page = 0 , int rowCount = 0 )
        {
            model.GetTopMostVotesByUser(page , rowCount);

            return model;
        }

        #endregion IEnumerable<IViewUserTotalVotes> Get()
    }
}