using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(csx_administration.Startup))]
namespace csx_administration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
