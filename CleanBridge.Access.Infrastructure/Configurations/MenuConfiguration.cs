using CleanBridge.Access.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanBridge.Access.Infrastructure.Configurations
{
    internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu", "Access");
            builder.HasKey(x => x.MenuId);
            builder.Property(x => x.ParentMenuId);
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Url);
            builder.Property(x => x.Order)
                .IsRequired();
            builder.Property(x => x.Active)
                .IsRequired();
        }
    }
}
