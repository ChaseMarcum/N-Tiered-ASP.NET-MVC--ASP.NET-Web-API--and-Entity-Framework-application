using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AIM.Web.ClientApp.Startup))]
namespace AIM.Web.ClientApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
