using Microsoft.AspNet.WebApi.MessageHandlers.Compression;
using Microsoft.AspNet.WebApi.MessageHandlers.Compression.Compressors;
using System.Web.Http;

namespace MusicBattlWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

           
            config.Routes.MapHttpRoute(
                name: "DefaultWebApi",
                routeTemplate: "api/{controller}/{action}/{id}/{page}/{rowCount}",
                defaults: new { action = "Get", id = RouteParameter.Optional, page = RouteParameter.Optional, rowCount = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));
        }
    }
}