using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartGarden.Startup))]
namespace SmartGarden
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
