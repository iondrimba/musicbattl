using System.Web.Mvc;

namespace MusicBattlWebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters( GlobalFilterCollection filters )
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CharsetAttribute());
        }
    }
}