using Owin;

namespace MusicBattlSignalR
{
    public static class Startup
    {
        public static void ConfigureSignalR( IAppBuilder app )
        {
            app.MapSignalR();
        }
    }
}