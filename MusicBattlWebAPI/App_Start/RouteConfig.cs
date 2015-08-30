using System.Web.Mvc;
using System.Web.Routing;

namespace MusicBattlWebAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Content/{*pathInfo}");
            routes.IgnoreRoute("Files/{*pathInfo}");
            routes.IgnoreRoute("Scripts/{*pathInfo}");
            routes.IgnoreRoute("img/{*pathInfo}");

            routes.RouteExistingFiles = true;
            routes.MapRoute(
               name: "HtmlViews",
               url: "Templates/Html/{page}",
               defaults: new { controller = "Templates",action="Html", page = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{page}/{rowCount}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, page = UrlParameter.Optional, rowCount = UrlParameter.Optional }
            );
        }
    }
}