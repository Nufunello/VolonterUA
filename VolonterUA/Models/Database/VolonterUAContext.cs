using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VolonterUA.Models.Database
{
    public class VolonterUAContext : IdentityDbContext<IdentityUser>
    {
        private UserStore<IdentityUser> UserStore => new UserStore<IdentityUser>(this);
        public UserManager<IdentityUser> UserManager => new UserManager<IdentityUser>(UserStore);
        public virtual DbSet<UserInfoModel> UserInfos { get; set; }
        public virtual DbSet<UserLoginDataModel> UserLoginDatas { get; set; }
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
