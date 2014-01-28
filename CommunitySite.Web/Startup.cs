using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommunitySite.Web.Startup))]
namespace CommunitySite.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
