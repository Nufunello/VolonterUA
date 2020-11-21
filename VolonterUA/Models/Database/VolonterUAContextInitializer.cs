using System.Data.Entity;

namespace VolonterUA.Models.Database
{
    public class VolonterUAContextInitializer : CreateDatabaseIfNotExists<VolonterUAContext>
    {
        protected override void Seed(VolonterUAContext context)
        {
            base.Seed(context);
        }
    }
}