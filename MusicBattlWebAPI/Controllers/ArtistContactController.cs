using System.Web.Http;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlWebAPI.Controllers
{
    public class ArtistContactController : ApiController
    {
        private IViewArtistContactBLL model;

        #region ArtistContactController( IViewArtistContactBLL model )

        public ArtistContactController( IViewArtistContactBLL model )
        {
            this.model = model;
        }

        #endregion ArtistContactController( IViewArtistContactBLL model )

        #region IViewArtistContact Get( int id )

        public IViewArtistContact Get( int id )
        {
            IViewArtistContact retorno = model.ArtistContactGet(id);

            return retorno;
        }

        #endregion IViewArtistContact Get( int id )
    }
}