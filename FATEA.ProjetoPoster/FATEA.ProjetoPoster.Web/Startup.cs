using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FATEA.ProjetoPoster.Web.Startup))]
namespace FATEA.ProjetoPoster.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
