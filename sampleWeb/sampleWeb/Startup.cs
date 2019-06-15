using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sampleWeb.Startup))]
namespace sampleWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
