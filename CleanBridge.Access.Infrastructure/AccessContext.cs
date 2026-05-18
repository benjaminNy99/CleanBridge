using CleanBridge.Access.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanBridge.Access.Infrastructure
{
    public partial class AccessContext : DbContext
    {
        public DbSet<CleanBridge.Access.Domain.Entities.Action> Actions { get; set; }
        public DbSet<CleanBridge.Access.Domain.Entities.Api> Apis { get; set; }
        public DbSet<CleanBridge.Access.Domain.Entities.ApiAction> ApiActions { get; set; }
        public DbSet<CleanBridge.Access.Domain.Entities.Menu> Menus { get; set; }
        public DbSet<CleanBridge.Access.Domain.Entities.MenuAction> MenuActions { get; set; }
        public DbSet<CleanBridge.Access.Domain.Entities.Rol> Rols { get; set; }
        public DbSet<CleanBridge.Access.Domain.Entities.RolApiAction> RolApiActions { get; set; }
        public DbSet<CleanBridge.Access.Domain.Entities.RolMenuAction> RolMenuActions { get; set; }
        public DbSet<CleanBridge.Access.Domain.Entities.User> Users { get; set; }
        public DbSet<CleanBridge.Access.Domain.Entities.UserRol> UserRols { get; set; }

        public AccessContext(DbContextOptions<AccessContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccessContext).Assembly);
        }
    }
}
