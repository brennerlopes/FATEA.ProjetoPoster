using FATEA.ProjetoPoster.DataAccess.Entity.Context;
using FATEA.ProjetoPoster.Web.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartupAttribute(typeof(FATEA.ProjetoPoster.Web.Startup))]
namespace FATEA.ProjetoPoster.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
         //   app.Use<IdentityDbContext>(new ProjetoPosterDbContext());
           app.CreatePerOwinContext<ProjetoPosterIdentityDbContext>(() => new ProjetoPosterIdentityDbContext());
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
           LoginPath = new PathString("/Conta/Login"),
           LogoutPath = new PathString("/Conta/Logout"),
           AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie

            });

        }
    }
}
