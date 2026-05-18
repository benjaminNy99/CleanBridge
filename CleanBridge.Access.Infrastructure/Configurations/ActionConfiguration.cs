using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanBridge.Access.Infrastructure.Configurations
{
    internal class ActionConfiguration : IEntityTypeConfiguration<CleanBridge.Access.Domain.Entities.Action>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Action> builder)
        {
            builder.ToTable("Action", "Access");
            builder.HasKey(x => x.Code);
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
