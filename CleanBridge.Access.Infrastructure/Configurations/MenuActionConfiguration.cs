using CleanBridge.Access.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanBridge.Access.Infrastructure.Configurations
{
    internal class MenuActionConfiguration : IEntityTypeConfiguration<MenuAction>
    {
        public void Configure(EntityTypeBuilder<MenuAction> builder)
        {
            builder.ToTable("MenuAction", "Access");
            builder.HasKey(x => new { x.MenuId, x.ActionCode });
        }
    }
}
