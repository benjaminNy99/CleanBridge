using CleanBridge.Access.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanBridge.Access.Infrastructure.Configurations
{
    internal class ApiConfiguration : IEntityTypeConfiguration<Api>
    {
        public void Configure(EntityTypeBuilder<Api> builder)
        {
            builder.ToTable("Api", "Access");
            builder.HasKey(x => x.ApiId);
            builder.Property(x => x.Url)
                .IsRequired();
            builder.Property(x => x.Active)
                .IsRequired();
        }
    }
}
