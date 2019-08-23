using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DNMOFT.Web.Startup))]
namespace DNMOFT.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
