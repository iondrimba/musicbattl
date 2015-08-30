using MusicBattlBLL.interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MusicBattlWebAPI.Controllers
{
    //[CacheClient(Duration = 120)]
    public class MostVotedController : ApiController
    {
        private IViewAlbumArtistSongTotalVotesBLL model;
        private IViewTopAlbumsBLL modelTopAlbums;

        #region MostVotedController( IViewUserTotalVotesBLL model )

        public MostVotedController(IViewAlbumArtistSongTotalVotesBLL model, IViewTopAlbumsBLL modelTopAlbums)
        {
            this.model = model;
            this.modelTopAlbums = modelTopAlbums;
        }

        #endregion MostVotedController( IViewUserTotalVotesBLL model )

        //SONGS

        #region IEnumerable<IViewUserTotalVotes> SongsDay()

        [HttpGet]
        public async Task<HttpResponseMessage> SongsDay(int page = 0, int rowCount = 0)
        {
            return await Task<HttpResponseMessage>.Factory.StartNew(() =>
            {
                model.GetMostVotesToday(page, rowCount);
                return Request.CreateResponse<IViewAlbumArtistSongTotalVotesBLL>(HttpStatusCode.OK, model);
            });
        }

        #endregion IEnumerable<IViewUserTotalVotes> SongsDay()

        #region IEnumerable<IViewUserTotalVotes> SongsDay()

        [HttpGet]
        public IViewAlbumArtistSongTotalVotesBLL SongsDayArtistNameDesc(int page = 0, int rowCount = 0)
        {
            model.OrderBy = "ArtistName";
            model.GetMostVotesToday(page, rowCount);

            return model;
        }

        #endregion IEnumerable<IViewUserTotalVotes> ThisSongsDayGet()

        #region IEnumerable<IViewAlbumArtistSongTotalVotes> SongsWeek()

        [HttpGet]
        public IViewAlbumArtistSongTotalVotesBLL SongsWeek(int page = 0, int rowCount = 0)
        {
            model.GetMostVotedThisWeek(page, rowCount);

            return model;
        }

        #endregion IEnumerable<IViewAlbumArtistSongTotalVotes> SongsWeek()

        #region IEnumerable<IViewAlbumArtistSongTotalVotes> SongsWeek()

        [HttpGet]
        public IViewAlbumArtistSongTotalVotesBLL SongsWeekArtistNameDesc(int page = 0, int rowCount = 0)
        {
            model.OrderBy = "ArtistName";
            model.GetMostVotedThisWeek(page, rowCount);

            return model;
        }

        #endregion IEnumerable<IViewAlbumArtistSongTotalVotes> SongsWeek()

        #region IEnumerable<IViewAlbumArtistSongTotalVotes> SongsMonth()

        [HttpGet]
        public IViewAlbumArtistSongTotalVotesBLL SongsMonth(int page = 0, int rowCount = 0)
        {
            model.GetMostVotedThisMonth(page, rowCount);

            return model;
        }

        #endregion IEnumerable<IViewAlbumArtistSongTotalVotes> SongsMonth()

        #region IEnumerable<IViewAlbumArtistSongTotalVotes> SongsMonth()

        [HttpGet]
        public IViewAlbumArtistSongTotalVotesBLL SongsMonthArtistNameDesc(int page = 0, int rowCount = 0)
        {
            model.OrderBy = "ArtistName";
            model.GetMostVotedThisMonth(page, rowCount);

            return model;
        }

        #endregion IEnumerable<IViewAlbumArtistSongTotalVotes> SongsMonth()

        //ABUMS

        #region IEnumerable<IViewUserTotalVotes> AlbumsDay()

        [HttpGet]
        public IViewTopAlbumsBLL AlbumsDay(int page = 0, int rowCount = 0)
        {
            modelTopAlbums.GetMostVotedAlbumToday(page, rowCount);

            return modelTopAlbums;
        }

        #endregion IEnumerable<IViewUserTotalVotes> AlbumsDay()

        #region IEnumerable<IViewUserTotalVotes> AlbumsDay()

        [HttpGet]
        public IViewTopAlbumsBLL AlbumsDayArtistNameDesc(int page = 0, int rowCount = 0)
        {
            modelTopAlbums.OrderBy = "ArtistName";
            modelTopAlbums.GetMostVotedAlbumToday(page, rowCount);

            return modelTopAlbums;
        }

        #endregion IEnumerable<IViewUserTotalVotes> AlbumsDay()

        #region IEnumerable<IViewUserTotalVotes> AlbumsWeek()

        [HttpGet]
        public IViewTopAlbumsBLL AlbumsWeek(int page = 0, int rowCount = 0)
        {
            modelTopAlbums.GetMostVotedAlbumThisWeek(page, rowCount);

            return modelTopAlbums;
        }

        #endregion IEnumerable<IViewUserTotalVotes> AlbumsWeek()

        #region IEnumerable<IViewUserTotalVotes> AlbumsWeek()

        [HttpGet]
        public IViewTopAlbumsBLL AlbumsWeekArtistNameDesc(int page = 0, int rowCount = 0)
        {
            modelTopAlbums.OrderBy = "ArtistName";
            modelTopAlbums.GetMostVotedAlbumThisWeek(page, rowCount);

            return modelTopAlbums;
        }

        #endregion IEnumerable<IViewUserTotalVotes> AlbumsWeek()

        #region IEnumerable<IViewUserTotalVotes> AlbumsMonth()

        [HttpGet]
        public IViewTopAlbumsBLL AlbumsMonth(int page = 0, int rowCount = 0)
        {
            modelTopAlbums.GetMostVotedAlbumThisMonth(page, rowCount);

            return modelTopAlbums;
        }

        #endregion IEnumerable<IViewUserTotalVotes> AlbumsMonth()

        #region IEnumerable<IViewUserTotalVotes> AlbumsMonth()

        [HttpGet]
        public IViewTopAlbumsBLL AlbumsMonthArtistNameDesc(int page = 0, int rowCount = 0)
        {
            modelTopAlbums.OrderBy = "ArtistName";
            modelTopAlbums.GetMostVotedAlbumThisMonth(page, rowCount);

            return modelTopAlbums;
        }

        #endregion IEnumerable<IViewUserTotalVotes> AlbumsMonth()
    }
}