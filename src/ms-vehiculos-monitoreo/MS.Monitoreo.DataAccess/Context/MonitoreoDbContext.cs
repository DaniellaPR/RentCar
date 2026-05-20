using Microsoft.EntityFrameworkCore;
using MS.Monitoreo.DataAccess.Entities;
using MS.Monitoreo.DataAccess.Configurations;

namespace MS.Monitoreo.DataAccess.Context
{
    public class MonitoreoDbContext : DbContext
    {
        public MonitoreoDbContext(DbContextOptions<MonitoreoDbContext> options) : base(options)
        {
        }

        public DbSet<AuditoriaEntity> Auditorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AuditoriaConfiguration());
            modelBuilder.HasDefaultSchema("public");
        }
    }
}