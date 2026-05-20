using Microsoft.EntityFrameworkCore;
using MS.Identidad.DataAccess.Entities;
using MS.Identidad.DataAccess.Configurations;

namespace MS.Identidad.DataAccess.Context
{
    public class IdentidadDbContext : DbContext
    {
        public IdentidadDbContext(DbContextOptions<IdentidadDbContext> options) : base(options)
        {
        }

        public DbSet<RolEntity> Roles { get; set; }
        public DbSet<UsuarioAppEntity> UsuariosApp { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<LicenciaConducirEntity> LicenciasConducir { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RolConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioAppConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new LicenciaConducirConfiguration());

            modelBuilder.HasDefaultSchema("public");
        }
    }
}