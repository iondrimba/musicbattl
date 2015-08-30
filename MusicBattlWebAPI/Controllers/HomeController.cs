using System;
using System.Web;
using System.Web.Mvc;
using WebMarkupMin.Mvc.ActionFilters;

namespace MusicBattlWebAPI.Controllers
{
    public class HomeController : Controller
    {
        [CompressContent]
        [MinifyHtml]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CallBack()
        {
            string oauth_verifier = string.Empty;

            if (this.Request.QueryString["oauth_verifier"] != null)
            {
                oauth_verifier = this.Request.QueryString["oauth_verifier"].ToString();
                HttpCookie myCookie = new HttpCookie("oauth_verifier");
                myCookie["oauth_verifier"] = oauth_verifier;
                myCookie.Expires = DateTime.Now.AddMinutes(1);
                Response.Cookies.Add(myCookie);
            }

            return new RedirectResult("/#/site/home");
        }
    }
}