using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FunWithNinject.Web.Startup))]
namespace FunWithNinject.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
