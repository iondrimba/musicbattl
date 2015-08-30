using System.Web.Mvc;
using WebMarkupMin.Mvc.ActionFilters;

namespace MusicBattlWebAPI.Controllers
{
    public class TemplatesController : Controller
    {
        [CompressContent]
        [Charset]
        public ActionResult Html(string page)
        {
            return new FilePathResult("~/templates/html/" + page, "text/html;charset=utf-8");
        }
    }
}