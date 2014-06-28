using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AIM.Web.Admin.Startup))]
namespace AIM.Web.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
