using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Helezon.FollowMe.WebUI.Startup))]
namespace Helezon.FollowMe.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
