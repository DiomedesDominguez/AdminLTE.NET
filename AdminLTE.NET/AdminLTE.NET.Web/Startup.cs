using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminLTE.NET.Web.Startup))]
namespace AdminLTE.NET.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
