using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VolonterUA.Models.Database
{
    public class VolonterUAContext : IdentityDbContext<IdentityUser>
    {
        #region DbSets

        public virtual DbSet<UserInfoModel> UserInfos { get; set; }
        public virtual DbSet<UserLoginDataModel> UserLoginDatas { get; set; }
        public virtual DbSet<VolonterOrganization> VolonterOrganizations { get; set; }

        public virtual DbSet<VolonterEvent> VolonterEvents { get; set; }
        public virtual DbSet<UpcomingVolonterEvent>  UpcomingVolonterEvents { get; set; }
        public virtual DbSet<InProgressVolonterEvent> InProgressVolonterEvents { get; set; }
        public virtual DbSet<FinishedVolonterEvent> FinishedVolonterEvents { get; set; }

        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<EventFeedback> EventFeedbacks { get; set; }
        public virtual DbSet<VolonterOrganizationFeedback> VolonterOrganizationFeedbacks { get; set; }

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
                VolonterEvent = upcomingVolonterEvent.VolonterEvent
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
                VolontersAtEvent = inProgressVolonterEvent.VolontersAtEvent
            };
            FinishedVolonterEvents.Add(finishedVolonterEvent);
            InProgressVolonterEvents.Remove(inProgressVolonterEvent);
            SaveChanges();
            return finishedVolonterEvent;
        }

        #endregion

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
