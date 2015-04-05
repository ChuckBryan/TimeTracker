using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeTracker.Web.Startup))]
namespace TimeTracker.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
