using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MS.Identidad.DataAccess.Context;
using MS.Identidad.DataAccess.Repositories;
using MS.Identidad.DataManagement.Interfaces;
using MS.Identidad.DataManagement.Services;
using MS.Identidad.Business.Interfaces;
using MS.Identidad.Business.Services;

namespace MS.Identidad.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentidadDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Contexto de Base de Datos exclusivo de Identidad
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<IdentidadDbContext>(options =>
                options.UseNpgsql(connectionString));

            // 2. Registro de Unidad de Trabajo (UnitOfWork)
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // 3. Registro de Servicios de la Capa de Datos (DataManagement)

            services.AddScoped<IRolDataService, RolDataService>();
            services.AddScoped<IUsuarioAppDataService, UsuarioAppDataService>();
            services.AddScoped<IClienteDataService, ClienteDataService>();
            services.AddScoped<ILicenciaConducirDataService, LicenciaConducirDataService>();

            // 4. Registro de Servicios de la Capa de Negocio (Business)
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ILicenciaConducirService, LicenciaConducirService>();

            return services;
        }
    }
}
