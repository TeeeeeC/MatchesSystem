using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MatchesSystem.Web.Server.Startup))]

namespace MatchesSystem.Web.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
