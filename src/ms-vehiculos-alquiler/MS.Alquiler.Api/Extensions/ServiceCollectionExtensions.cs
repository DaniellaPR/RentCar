// MS.Alquiler.Api/Extensions/ServiceCollectionExtensions.cs
// FIX: El using original referenciaba MS.Alquiler.DataAccess.Interfaces y
//      MS.Alquiler.DataAccess.Repositories que NO existen como namespaces.
//      Las implementaciones están en:
//        MS.Alquiler.DataAccess.Repositories.Implementaciones  (repositorios)
//        MS.Alquiler.DataManagement.Services                    (data services)
//        MS.Alquiler.Business.Services                          (business services)

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MS.Alquiler.DataAccess.Context;
// ← Repositorios (no se registran individualmente — los DataServices usan el DbContext directo)
using MS.Alquiler.DataManagement.Interfaces;
using MS.Alquiler.DataManagement.Services;
using MS.Alquiler.Business.Interfaces;
using MS.Alquiler.Business.Services;

namespace MS.Alquiler.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAlquilerDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // 1. DbContext — cadena de conexión desde variable de entorno o appsettings
            var connectionString =
                Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                ?? configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AlquilerDbContext>(options =>
                options.UseNpgsql(connectionString));

            // 2. Capa DataManagement (acceso a datos vía DbContext)
            services.AddScoped<IReservaDataService, ReservaDataService>();
            services.AddScoped<IReservaDetalleDataService, ReservaDetalleDataService>();
            services.AddScoped<IPagoDataService, PagoDataService>();

            // 3. UnitOfWork — agrupa los tres DataServices
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // 4. Capa Business
            services.AddScoped<IReservaService, ReservaService>();
            services.AddScoped<IReservaDetalleService, ReservaDetalleService>();
            services.AddScoped<IPagoService, PagoService>();

            return services;
        }
    }
}
