using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataAccess.Repositories;
using MS.Catalogo.DataManagement.Interfaces;
using MS.Catalogo.DataManagement.Services;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.Services;

namespace MS.Catalogo.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCatalogoDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Contexto de Base de Datos exclusivo del Catálogo (Supabase Postgres)
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CatalogoDbContext>(options =>
                options.UseNpgsql(connectionString));

            // 2. Registro de Unidad de Trabajo (UnitOfWork)
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // 3. Registro de Servicios de la Capa de Datos (DataManagement)
            services.AddScoped<ICategoriaVehiculoDataService, CategoriaVehiculoDataService>();
            services.AddScoped<ISucursalDataService, SucursalDataService>();
            services.AddScoped<IVehiculoDataService, VehiculoDataService>();
            services.AddScoped<IMantenimientoDataService, MantenimientoDataService>();
            services.AddScoped<ITarifaDataService, TarifaDataService>();
            services.AddScoped<ISeguroDataService, SeguroDataService>();
            services.AddScoped<IExtraAdicionalDataService, ExtraAdicionalDataService>();
            services.AddScoped<IHorarioAtencionDataService, HorarioAtencionDataService>();

            // 4. Registro de Servicios de la Capa de Negocio (Business)
            services.AddScoped<ICategoriaVehiculoService, CategoriaVehiculoService>();
            services.AddScoped<ISucursalService, SucursalService>();
            services.AddScoped<IVehiculoService, VehiculoService>();
            services.AddScoped<IMantenimientoService, MantenimientoService>();
            services.AddScoped<ITarifaService, TarifaService>();
            services.AddScoped<ISeguroService, SeguroService>();
            services.AddScoped<IExtraAdicionalService, ExtraAdicionalService>();
            services.AddScoped<IHorarioAtencionService, HorarioAtencionService>();

            return services;
        }
    }
}
