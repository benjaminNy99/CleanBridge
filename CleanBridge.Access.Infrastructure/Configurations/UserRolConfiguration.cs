using CleanBridge.Access.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanBridge.Access.Infrastructure.Configurations
{
    internal class UserRolConfiguration : IEntityTypeConfiguration<UserRol>
    {
        public void Configure(EntityTypeBuilder<UserRol> builder)
        {
            builder.ToTable("UserRol", "Access");
            builder.HasKey(x => new { x.UserId, x.RolId });
        }
    }
}
