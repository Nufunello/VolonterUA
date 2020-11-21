using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VolonterUA.Models.Database
{
    public partial class VolonterUAContext : DbContext
    {
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
        }
    }
}
