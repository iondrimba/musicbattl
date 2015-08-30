using System.Web.Http;
using MusicBattlBLL.interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicBattlWebAPI.Controllers
{
    public class AllTimerWinnersController : ApiController
    {
        private IViewAlbumArtistSongTotalVotesByArtistBLL model;

        #region AllTimerWinnersController( IViewAlbumArtistSongTotalVotesBLL model )

        public AllTimerWinnersController( IViewAlbumArtistSongTotalVotesByArtistBLL model )
        {
            this.model = model;
        }

        #endregion AllTimerWinnersController( IViewAlbumArtistSongTotalVotesBLL model )

        #region IEnumerable<IViewAlbumArtistSongTotalVotesByArtist> Get()

        //[CacheClient(Duration = 120)]
        public async Task<HttpResponseMessage>  Get( int page = 0 , int rowCount = 0 )
        {
            return await Task<HttpResponseMessage>.Factory.StartNew(() =>
            {
                model.GetTopMostVotedArtist(page, rowCount); ;
                return Request.CreateResponse<IViewAlbumArtistSongTotalVotesByArtistBLL>(HttpStatusCode.OK, model);
            });
        }

        #endregion IEnumerable<IViewAlbumArtistSongTotalVotesByArtist> Get()
    }
}