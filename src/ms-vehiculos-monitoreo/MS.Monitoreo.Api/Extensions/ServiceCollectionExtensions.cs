using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MS.Monitoreo.DataAccess.Context;
using MS.Monitoreo.DataAccess.Repositories;
using MS.Monitoreo.DataManagement.Interfaces;
using MS.Monitoreo.DataManagement.Services;
using MS.Monitoreo.Business.Interfaces;
using MS.Monitoreo.Business.Services;

namespace MS.Monitoreo.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMonitoreoDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Contexto de Base de Datos exclusivo de Monitoreo
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MonitoreoDbContext>(options =>
                options.UseNpgsql(connectionString));

            // 2. Registro de Unidad de Trabajo (UnitOfWork)
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // 3. Registro de Servicios de la Capa de Datos (DataManagement)
            services.AddScoped<IAuditoriaDataService, AuditoriaDataService>();

            // 4. Registro de Servicios de la Capa de Negocio (Business)
            services.AddScoped<IAuditoriaService, AuditoriaService>();

            return services;
        }
    }
}
