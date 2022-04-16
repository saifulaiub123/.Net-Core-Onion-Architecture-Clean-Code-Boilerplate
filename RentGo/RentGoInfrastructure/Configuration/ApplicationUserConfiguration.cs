using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentGo.Domain.DBModel;

namespace RentGo.Infrastructure.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(x => x.UserStatus)
                .WithOne(x => x.User)
                .HasForeignKey<ApplicationUser>(x => x.Status);

        }
    }
}
