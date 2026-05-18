using CleanBridge.Access.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanBridge.Access.Infrastructure.Configurations
{
    internal class RolApiActionConfiguration : IEntityTypeConfiguration<RolApiAction>
    {
        public void Configure(EntityTypeBuilder<RolApiAction> builder)
        {
            builder.ToTable("RolApiAction", "Access");
            builder.HasKey(x => new { x.RolId, x.ApiId, x.ActionCode });
        }
    }
}
