using System.Web.Http;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.models.interfaces;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Net;

namespace MusicBattlWebAPI.Controllers
{
    
  //  [WebApi.OutputCache.V2.AutoInvalidateCacheOutput]
    public class PastBattlsController : ApiController
    {
        private IViewPastBattlsBLL model;

        public PastBattlsController( IViewPastBattlsBLL model )
        {
            this.model = model;
        }

        // GET api/<controller>        
//        [WebApi.OutputCache.V2.CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        public async Task<HttpResponseMessage> Get(int page = 0, int rowCount = 5)
        {
            return await Task<HttpResponseMessage>.Factory.StartNew(() =>
            {
                var resultCollection = model.GetPastBattls(page, rowCount);
                return Request.CreateResponse<IViewPastBattlsBLL>(HttpStatusCode.OK, model);
            });

        }

        // GetById api/<controller>
        [HttpGet]
        public async Task<HttpResponseMessage> ById( int id )
        {
            return await Task<HttpResponseMessage>.Factory.StartNew(() =>
            {
                var result = model.GetPastBattlsById(id);
                return Request.CreateResponse<IViewPastBattls>(HttpStatusCode.OK, result);
            });

        }
    }
}