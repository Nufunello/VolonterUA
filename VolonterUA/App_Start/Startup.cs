using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
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
        }
    }
}
