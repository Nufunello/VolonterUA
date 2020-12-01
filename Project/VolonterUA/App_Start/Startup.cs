using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using VolonterUA.Models.Database;

[assembly: OwinStartup(typeof(VolonterUA.App_Start.Startup))]

namespace VolonterUA.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            using (var context = new VolonterUAContext())
            {
                context.Database.Initialize(false);
            }

            var authOptions = new CookieAuthenticationOptions
            {
                AuthenticationType = Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/personal/volonter/signin"),
                LogoutPath = new PathString("/personal/volonter/signout"),
                ExpireTimeSpan = TimeSpan.FromMinutes(5),
            };
            app.UseCookieAuthentication(authOptions);
        }
    }
}
