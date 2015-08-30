using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Microsoft.Ajax.Utilities;

namespace MusicBattlWebAPI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Microsoft.AspNet.SignalR.GlobalHost.DependencyResolver.Register(typeof(Microsoft.AspNet.SignalR.Hubs.IJavaScriptMinifier), () => new HubMin());

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

                       
        }

        public class HubMin : Microsoft.AspNet.SignalR.Hubs.IJavaScriptMinifier
        {
            public string Minify(string source)
            {
                CodeSettings settings = new CodeSettings
                {
                    PreserveImportantComments = false,
                    PreserveFunctionNames = true
                };
                Minifier doMin = new Minifier();
                string mind = doMin.MinifyJavaScript(source, settings);
                return mind;
            }
        }
    }
}