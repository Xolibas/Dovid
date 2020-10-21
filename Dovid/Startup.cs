using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dovid.Startup))]
namespace Dovid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
