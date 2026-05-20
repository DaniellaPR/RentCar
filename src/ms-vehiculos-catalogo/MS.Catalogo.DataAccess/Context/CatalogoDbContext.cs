using Microsoft.EntityFrameworkCore;
using MS.Catalogo.DataAccess.Entities;
using MS.Catalogo.DataAccess.Configurations;

namespace MS.Catalogo.DataAccess.Context
{
    public class CatalogoDbContext : DbContext
    {
        public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options)
        {
        }

        // DbSets: Representan las tablas de Supabase en este microservicio
        public DbSet<CategoriaVehiculoEntity> CategoriasVehiculo { get; set; }
        public DbSet<SucursalEntity> Sucursales { get; set; }
        public DbSet<HorarioAtencionEntity> HorariosAtencion { get; set; }
        public DbSet<VehiculoEntity> Vehiculos { get; set; }
        public DbSet<MantenimientoEntity> Mantenimientos { get; set; }
        public DbSet<TarifaEntity> Tarifas { get; set; }
        public DbSet<SeguroEntity> Seguros { get; set; }
        public DbSet<ExtraAdicionalEntity> ExtrasAdicionales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplicamos automáticamente todas las configuraciones 
            // que definimos en la carpeta Configurations
            modelBuilder.ApplyConfiguration(new CategoriaVehiculoConfiguration());
            modelBuilder.ApplyConfiguration(new SucursalConfiguration());
            modelBuilder.ApplyConfiguration(new HorarioAtencionConfiguration());
            modelBuilder.ApplyConfiguration(new VehiculoConfiguration());
            modelBuilder.ApplyConfiguration(new MantenimientoConfiguration());
            modelBuilder.ApplyConfiguration(new TarifaConfiguration());
            modelBuilder.ApplyConfiguration(new SeguroConfiguration());
            modelBuilder.ApplyConfiguration(new ExtraAdicionalConfiguration());

            // Nota: PostgreSQL en Supabase suele trabajar mejor si forzamos 
            // que todo el esquema sea 'public' (por defecto ya lo es)
            modelBuilder.HasDefaultSchema("public");
        }
    }
}