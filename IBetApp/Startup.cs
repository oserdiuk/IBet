using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IBetApp.Startup))]
namespace IBetApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
