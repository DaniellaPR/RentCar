// MS.Alquiler.Api/Extensions/SwaggerExtensions.cs
// FIX Swashbuckle 10.x: IConfigureOptions<SwaggerGenOptions> + IApiVersionDescriptionProvider
// siguen funcionando igual, pero el paquete Microsoft.OpenApi subió a v3 y algunos
// tipos cambiaron. Se mantiene compatible con Asp.Versioning.Mvc 10.x.

using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MS.Alquiler.Api.Extensions
{
    // ─── Configurador dinámico: genera un documento Swagger por cada versión ──────
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
            => _provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, new OpenApiInfo
                {
                    Title = "RentCar Ec — MS Alquiler (paula-pozo)",
                    Version = description.ApiVersion.ToString(),
                    Description = description.IsDeprecated
                        ? "[DEPRECADA] Microservicio de Alquiler — Paula Pozo."
                        : "Microservicio de Alquiler de Vehículos — Paula Pozo.\n\n" +
                          "Gestión de reservas, detalles y pagos. " +
                          "Contrato alineado con vehiculos-api.yaml del prototipo Booking."
                });
            }
        }
    }

    // ─── Extension method ──────────────────────────────────────────────────────────
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            // 1. Registrar configurador dinámico ANTES de AddSwaggerGen
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            // 2. SwaggerGen base — solo seguridad JWT; título/versión los pone el configurador




            services.AddSwaggerGen(c =>
            {

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Ingrese: Bearer {token}"
                });


                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });


            return services;
        }
    }

   
}
