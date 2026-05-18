using CleanBridge.Access.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanBridge.Access.Infrastructure.Configurations
{
    internal class ApiActionConfiguration : IEntityTypeConfiguration<ApiAction>
    {
        public void Configure(EntityTypeBuilder<ApiAction> builder)
        {
            builder.ToTable("ApiAction", "Access");
            builder.HasKey(x => new { x.ApiId, x.ActionCode });
        }
    }
}
