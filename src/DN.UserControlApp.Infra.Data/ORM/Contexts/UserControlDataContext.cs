using DN.UserControlApp.Domain.Account.Entities;
using DN.UserControlApp.Infra.Data.ORM.Mapping.Account;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DN.UserControlApp.Infra.Data.ORM.Contexts
{
    public class UserControlDataContext: DbContext
    {
        public UserControlDataContext()
            :base("UserControlDataContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(50));

            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
