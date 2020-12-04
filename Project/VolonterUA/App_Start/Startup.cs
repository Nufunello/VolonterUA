using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Linq;
using System.Threading;
using VolonterUA.Models.Database;

[assembly: OwinStartup(typeof(VolonterUA.App_Start.Startup))]

namespace VolonterUA.App_Start
{
    public class Startup
    {
        private void RefreshEvents(object d)
        {
            using (var context = new VolonterUAContext())
            {
                var startedEvents = context.UpcomingVolonterEvents.Where(x => x.VolonterEvent.Description.Date < DateTime.Now).ToList();
                foreach (var volonterEvent in startedEvents)
                {
                    context.StartEvent(volonterEvent);
                }
            }
        }

        private Timer _timer;
        public void Configuration(IAppBuilder app)
        {
            using (var context = new VolonterUAContext())
            {
                context.Database.Initialize(false);
            }

            TimerCallback tm = new TimerCallback(RefreshEvents);
            // создаем таймер
            _timer = new Timer(tm, 0, 0, 30000);

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
