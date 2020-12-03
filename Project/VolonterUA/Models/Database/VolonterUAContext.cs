using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;

namespace VolonterUA.Models.Database
{
    public class VolonterUAContext : IdentityDbContext<IdentityUser>
    {
        #region DbSets

        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<UserLoginData> UserLoginDatas { get; set; }
        public virtual DbSet<Volonter> Volonters { get; set; }
        public virtual DbSet<VolonterOrganization> VolonterOrganizations { get; set; }

        public virtual DbSet<VolonterEvent> VolonterEvents { get; set; }
        public virtual DbSet<UpcomingVolonterEvent>  UpcomingVolonterEvents { get; set; }
        public virtual DbSet<InProgressVolonterEvent> InProgressVolonterEvents { get; set; }
        public virtual DbSet<FinishedVolonterEvent> FinishedVolonterEvents { get; set; }

        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<Location> Addresses { get; set; }

        public virtual DbSet<EventFeedback> EventFeedbacks { get; set; }
        public virtual DbSet<VolonterOrganizationFeedback> VolonterOrganizationFeedbacks { get; set; }

        #endregion

        #region UserMethods
        
        public Volonter AddVolonter(UserLoginData userLoginData)
        {
            UserManager.Create(new IdentityUser
            {
                UserName = userLoginData.Login,
                PasswordHash = userLoginData.Password
            });
            UserLoginDatas.Add(userLoginData); ;
            var volonter = new Volonter { UserInfo = userLoginData.UserInfo };
            Volonters.Add(volonter);
            SaveChanges();
            return volonter;
        }

        #endregion

        #region EventsMethods

        public UpcomingVolonterEvent PostEvent(VolonterEvent volonterEvent)
        {
            var upcomingVolonterEvent = new UpcomingVolonterEvent
            {
                VolonterEvent = volonterEvent
            };
            UpcomingVolonterEvents.Add(upcomingVolonterEvent);
            SaveChanges();
            return upcomingVolonterEvent;
        }

        public InProgressVolonterEvent StartEvent(UpcomingVolonterEvent upcomingVolonterEvent)
        {
            var inProgressVolonterEvent = new InProgressVolonterEvent
            {
                VolonterEvent = upcomingVolonterEvent.VolonterEvent,
                Volonters = upcomingVolonterEvent.Volonters == null ? new List<Volonter>() : upcomingVolonterEvent.Volonters.ToList()
            };
            InProgressVolonterEvents.Add(inProgressVolonterEvent);
            UpcomingVolonterEvents.Remove(upcomingVolonterEvent);
            SaveChanges();
            return inProgressVolonterEvent;
        }

        public FinishedVolonterEvent FinishEvent(InProgressVolonterEvent inProgressVolonterEvent)
        {
            var finishedVolonterEvent = new FinishedVolonterEvent
            {
                VolonterEvent = inProgressVolonterEvent.VolonterEvent,
                Volonters = inProgressVolonterEvent.Volonters == null ? new List<Volonter> { } : inProgressVolonterEvent.Volonters.ToList()
            };
            InProgressVolonterEvents.Remove(inProgressVolonterEvent);

            foreach (var volonter in finishedVolonterEvent.Volonters)
            {
                volonter.Karma += 5;//5 - is default karma up from event
            }

            FinishedVolonterEvents.Add(finishedVolonterEvent);
            SaveChanges();
            return finishedVolonterEvent;
        }

        #endregion

        public string RegisterUser(UserLoginData loginData, HttpRequestBase Request, HttpContextBase HttpContext)
        {
            var userManager = UserManager;
            var user = new IdentityUser
            {
                UserName = loginData.Login,
                PasswordHash = loginData.Password
            };
            var result = userManager.Create(user);
            if (result.Succeeded)
            {
                var signInManager = new SignInManager<IdentityUser, string>(userManager, HttpContext.GetOwinContext().Authentication);
                signInManager.SignIn(user, false, false);
                UserLoginDatas.Add(loginData);
                Volonters.Add(new Volonter { UserInfo = loginData.UserInfo });
                SaveChanges();

                var prevUrl = Request.UrlReferrer;
                if (prevUrl != null && prevUrl.LocalPath.ToLower() == "/personal/volonterorganization/register")
                {
                    return "/personal/volonterorganization/register";
                }
                else
                {
                    return "/VolonterEvent/Search";
                }
            }
            return "";
        }

        private UserStore<IdentityUser> UserStore => new UserStore<IdentityUser>(this);
        public UserManager<IdentityUser> UserManager => new UserManager<IdentityUser>(UserStore);
        static VolonterUAContext()
        {
            System.Data.Entity.Database.SetInitializer(new VolonterUAContextInitializer());
        }

        public VolonterUAContext()
            : base("name=VolonterUAContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
