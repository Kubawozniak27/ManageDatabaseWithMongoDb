using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElectronicShops.Startup))]
namespace ElectronicShops
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
