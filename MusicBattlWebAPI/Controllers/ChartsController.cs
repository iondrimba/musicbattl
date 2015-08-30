using MusicBattlBLL.interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MusicBattlWebAPI.Controllers
{
    public class ChartsController : ApiController
    {
        private IViewTopSongsBLL topSongsModel;
        private IViewTopUsersBLL topUsersModel;
        private IViewGenderTotalBLL gendersTotalModel;
        private IViewUserAgesTotalBLL userAgesTotalModel;
        private IViewActivityByHourBLL activityByHourModel;
        private IViewAlbumArtistSongTotalVotesBLL songsTotalModel;
        private IViewTopAlbumsBLL albumsTotalModel;

        public ChartsController(IViewTopSongsBLL topSongsModel,
         IViewTopUsersBLL topUsersModel,
          IViewGenderTotalBLL gendersTotalModel,
          IViewUserAgesTotalBLL userAgesTotalModel,
          IViewActivityByHourBLL activityByHourModel,
          IViewAlbumArtistSongTotalVotesBLL songsTotalModel,
          IViewTopAlbumsBLL albumsTotalModel)
        {
            this.topSongsModel = topSongsModel;
            this.topUsersModel = topUsersModel;
            this.gendersTotalModel = gendersTotalModel;
            this.userAgesTotalModel = userAgesTotalModel;
            this.activityByHourModel = activityByHourModel;
            this.songsTotalModel = songsTotalModel;
            this.albumsTotalModel = albumsTotalModel;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> LoadData()
        {
            return await Task<HttpResponseMessage>.Factory.StartNew(() =>
            {
                songsTotalModel.OrderBy = "ArtistName";
                songsTotalModel.GetMostVotedThisMonth(0, 5);

                albumsTotalModel.OrderBy = "ArtistName";
                albumsTotalModel.GetMostVotedAlbumThisMonth(0, 5);

                var retorno = new
                {
                    gendersTotalModel = this.gendersTotalModel.GetTotals(),
                    userAgesTotalModel = this.userAgesTotalModel.GetTotals(),
                    activityByHourModel = this.activityByHourModel.GetTotals(),
                    songsTotalModel = this.songsTotalModel,
                    albumsTotalModel = this.albumsTotalModel
                };

                return Request.CreateResponse<object>(HttpStatusCode.OK, retorno);
            });
        }

        // GET api/<Charts>/GetTopSongsBronze
        [HttpGet]
        public IViewTopSongsBLL TopSongsBronze(int page = 0, int rowCount = 0)
        {
            topSongsModel.GetTopSongsBronze(page, rowCount);

            return topSongsModel;
        }

        // GET api/<Charts>/GetTopSongsSilver
        [HttpGet]
        public IViewTopSongsBLL TopSongsSilver(int page = 0, int rowCount = 0)
        {
            topSongsModel.GetTopSongsSilver(page, rowCount);

            return topSongsModel;
        }

        // GET api/<Charts>/GetTopSongsGold
        [HttpGet]
        public IViewTopSongsBLL TopSongsGold(int page = 0, int rowCount = 0)
        {
            topSongsModel.GetTopSongsGold(page, rowCount);

            return topSongsModel;
        }

        // GET api/<Charts>/GetTopUsersBronze
        [HttpGet]
        public IViewTopUsersBLL TopUsersBronze(int page = 0, int rowCount = 0)
        {
            topUsersModel.GetTopUsersBronze(page, rowCount);

            return topUsersModel;
        }

        // GET api/<Charts>/GetTopUsersSilver
        [HttpGet]
        public IViewTopUsersBLL TopUsersSilver(int page = 0, int rowCount = 0)
        {
            topUsersModel.GetTopUsersSilver(page, rowCount);

            return topUsersModel;
        }

        // GET api/<Charts>/GetTopUsersGold
        [HttpGet]
        public IViewTopUsersBLL TopUsersGold(int page = 0, int rowCount = 0)
        {
            topUsersModel.GetTopUsersGold(page, rowCount);

            return topUsersModel;
        }

        // GET api/<Charts>/GetPieChartGender
        [HttpGet]
        public async Task<HttpResponseMessage> PieChartGender()
        {
            //IEnumerable<object>
            //IList<IPieChartItem> data = gendersTotalModel.GetTotals();

            return await Task<HttpResponseMessage>.Factory.StartNew(() =>
            {
                var result = gendersTotalModel.GetTotals();
                return Request.CreateResponse<IList<IPieChartItem>>(HttpStatusCode.OK, result);
            });
        }

        // GET api/<Charts>/GetPieChartAge
        [HttpGet]
        public async Task<HttpResponseMessage> PieChartAge()
        {
            //IEnumerable<object>
            //IList<IPieChartItem> data = userAgesTotalModel.GetTotals();
            return await Task<HttpResponseMessage>.Factory.StartNew(() =>
            {
                var result = userAgesTotalModel.GetTotals();
                return Request.CreateResponse<IList<IPieChartItem>>(HttpStatusCode.OK, result);
            });
        }

        // GET api/<Charts>/GetPieChartActivity
        [HttpGet]
        public async Task<HttpResponseMessage> PieChartActivity()
        {
            //IEnumerable<object>
            //IList<IPieChartItem> data = activityByHourModel.GetTotals();

            return await Task<HttpResponseMessage>.Factory.StartNew(() =>
            {
                var result = activityByHourModel.GetTotals();
                return Request.CreateResponse<IList<IPieChartItem>>(HttpStatusCode.OK, result);
            });
        }
    }
}