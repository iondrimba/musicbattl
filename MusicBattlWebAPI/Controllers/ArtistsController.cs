using System.Web.Http;
using MusicBattlBLL.interfaces;

namespace MusicBattlWebAPI.Controllers
{
    public class ArtistsController : ApiController
    {
        private IViewArtistsBLL model;

        #region ArtistsController( IViewArtistsBLL model )

        public ArtistsController( IViewArtistsBLL model )
        {
            this.model = model;
        }

        #endregion ArtistsController( IViewArtistsBLL model )

        #region IEnumerable<IViewArtists> Get()

        public IViewArtistsBLL Get( int page = 0 , int rowCount = 100 )
        {
            model.GetArtists(page , rowCount);

            return model;
        }

        #endregion IEnumerable<IViewArtists> Get()

        #region IEnumerable<IViewArtists> Get()

        [HttpGet]
        public IViewArtistsBLL Contact( int id )
        {
            model.GetArtists(id);

            return model;
        }

        #endregion IEnumerable<IViewArtists> Get()
    }
}