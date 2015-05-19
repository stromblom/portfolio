using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stromblom.Portfolio.Startup))]
namespace Stromblom.Portfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
