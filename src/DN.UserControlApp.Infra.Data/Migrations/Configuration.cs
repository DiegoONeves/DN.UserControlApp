using DN.UserControlApp.Infra.Data.ORM.Contexts;
using System.Data.Entity.Migrations;

namespace DN.UserControlApp.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<UserControlDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UserControlDataContext context)
        {
            context.Database.CreateIfNotExists();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
