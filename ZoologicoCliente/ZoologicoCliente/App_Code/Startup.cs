using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZoologicoCliente.Startup))]
namespace ZoologicoCliente
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
