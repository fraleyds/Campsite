using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Campsite.Web.Startup))]
namespace Campsite.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
