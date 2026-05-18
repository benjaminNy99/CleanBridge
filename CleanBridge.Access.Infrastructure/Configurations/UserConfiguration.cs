using CleanBridge.Access.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanBridge.Access.Infrastructure.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "Access");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.IsAdmin)
                .IsRequired();
            builder.Property(x => x.Blocked)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(254);
            builder.Property(x => x.Password)
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.LastConnection);
            builder.Property(x => x.CreationDate)
                .IsRequired();
        }
    }
}
