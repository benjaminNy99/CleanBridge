using CleanBridge.Access.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanBridge.Access.Infrastructure.Configurations
{
    internal class RolMenuActionConfiguration : IEntityTypeConfiguration<RolMenuAction>
    {
        public void Configure(EntityTypeBuilder<RolMenuAction> builder)
        {
            builder.ToTable("RolMenuAction", "Access");
            builder.HasKey(x => new { x.RolId, x.MenuId, x.ActionCode });
        }
    }
}
