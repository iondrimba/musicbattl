using System.Web.Http;
using MusicBattlBLL.interfaces;

namespace MusicBattlWebAPI.Controllers
{
    public class UserProfileController : ApiController
    {
        private IViewUserBattlResultBLL model;

        public UserProfileController( IViewUserBattlResultBLL model )
        {
            this.model = model;
        }

        // GET api/<UserProfile>/GetBattlsWon
        public IViewUserBattlResultBLL GetBattlsWon( int id , int page = 0 , int rowCount = 0 )
        {
            model.GetBattlsWonByProfileId(id , page , rowCount);

            return model;
        }

        // GET api/<UserProfile>/GetBattlsWon
        public IViewUserBattlResultBLL GetBattlsLost( int id , int page = 0 , int rowCount = 0 )
        {
            model.GetBattlsLostByProfileId(id , page , rowCount);

            return model;
        }

        // GET api/<UserProfile>/Favorites
        [HttpGet]
        public IViewUserFavoritesSongsBLL Favorites( int id , int page = 0 , int rowCount = 0 )
        {
            IViewUserFavoritesSongsBLL result = model.GetFavoritesByProfileId(id , page , rowCount);

            return result;
        }
    }
}