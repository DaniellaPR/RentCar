using Microsoft.EntityFrameworkCore;
using MS.Alquiler.DataAccess.Entities;
using MS.Alquiler.DataAccess.Configurations;

namespace MS.Alquiler.DataAccess.Context
{
    public class AlquilerDbContext : DbContext
    {
        public AlquilerDbContext(DbContextOptions<AlquilerDbContext> options) : base(options)
        {
        }

        public DbSet<ReservaEntity> Reservas { get; set; }
        public DbSet<ReservaDetalleEntity> ReservaDetalles { get; set; }
        public DbSet<PagoEntity> Pagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ReservaConfiguration());
            modelBuilder.ApplyConfiguration(new ReservaDetalleConfiguration());
            modelBuilder.ApplyConfiguration(new PagoConfiguration());

            modelBuilder.HasDefaultSchema("public");
        }
    }
}