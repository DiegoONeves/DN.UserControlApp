using DN.UserControlApp.Domain.Account.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace DN.UserControlApp.Infra.Data.ORM.Mapping.Account
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            Property(x => x.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.FirstName)
                .HasMaxLength(10)
                .IsRequired();

            Property(x => x.UserRole)
                .IsRequired();

            Property(x => x.Email)
                .HasMaxLength(80)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_USER_EMAIL", 1)
                    {
                        IsUnique = true
                    }))
                .IsRequired();

            Property(x => x.Password)
                .HasMaxLength(32)
                .IsFixedLength();

            Property(x => x.IsActive)
                .IsRequired();

            Property(x => x.CreateDate)
                .IsRequired();
    }
    }
}
