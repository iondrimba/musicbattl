using MusicBattlBLL.interfaces;
using MusicBattlDAL;
using MusicBattlDAL.concrete;
using MusicBattlDAL.models.interfaces;
using MusicBattlDAL.repositories.interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MusicBattlWebAPI.Controllers
{
    public class BattlController : ApiController
    {
        private IBattlBLL model;
        private IVoteBLL voteModel;

        private IViewAlbumArtistSongTotalVotesByArtistBLL alltimeWinners;
        private IViewPastBattlsBLL pastbattls;
        private IViewUserTotalVotesBLL topUsers;
        private IViewAlbumArtistSongTotalVotesBLL mostVoted;

        public BattlController(
            IBattlBLL model, 
            IVoteBLL voteModel, 
            IViewAlbumArtistSongTotalVotesByArtistBLL alltimeWinners,
            IViewPastBattlsBLL pastbattls,
            IViewUserTotalVotesBLL topUsers,
            IViewAlbumArtistSongTotalVotesBLL mostVoted)
        {
            this.model = model;
            this.voteModel = voteModel;

            this.alltimeWinners = alltimeWinners;
            this.pastbattls = pastbattls;
            this.topUsers = topUsers;
            this.mostVoted = mostVoted;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> LoadData()
        {
            int page = 0;
            int rowCount = 5;

            return await Task<HttpResponseMessage>.Factory.StartNew(() =>
            {
                alltimeWinners.GetTopMostVotedArtist(page, rowCount);
                pastbattls.GetPastBattls(page, rowCount);
                topUsers.GetTopMostVotesByUser(page, rowCount);
                mostVoted.GetMostVotedThisMonth(page, rowCount);

                var retorno = new
                {
                    alltimeresult = this.alltimeWinners,
                    pastbattleresut = this.pastbattls,
                    topusersresult = this.topUsers,
                    mosteVotedresult = this.mostVoted
                };

                return Request.CreateResponse<object>(HttpStatusCode.OK, retorno);
            });
        }

        // GET api/<controller>
        [HttpGet]
        public async Task<HttpResponseMessage> Current()
        {
            return await Task<HttpResponseMessage>.Factory.StartNew(() =>
            {
                IViewBattlQueryParams query = new ViewBattlQueryParams();
                var result = model.GetActiveBattl(query);
                return Request.CreateResponse<IViewBattl>(HttpStatusCode.OK, result);
            });
        }

        [HttpPost]
        public Vote VoteSong(Vote vote)
        {
            Vote retorno = (Vote)this.voteModel.VoteOnArtist(vote);

            return retorno;
        }
    }
}