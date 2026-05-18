using CleanBridge.Access.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanBridge.Access.Infrastructure.Configurations
{
    internal class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol", "Access");
            builder.HasKey(x => x.RolId);
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
