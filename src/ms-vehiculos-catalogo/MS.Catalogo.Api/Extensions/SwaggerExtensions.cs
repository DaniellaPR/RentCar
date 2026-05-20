using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MS.Catalogo.Api.Extensions
{
    // ─── Configurador dinámico de documentos Swagger por versión ────────────────
    // Este es el fix principal: sin él, Swashbuckle no detecta los grupos de versión
    // generados por Asp.Versioning y el UI queda vacío o lanza excepción.
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
                    Title       = "RentCar Ec — MS.Catalogo.Api",
                    Version     = description.ApiVersion.ToString(),
                    Description = description.IsDeprecated
                        ? "Microservicio de Catálogo de Vehículos para Paula Pozo. [DEPRECADA]"
                        : "Microservicio de Catálogo de Vehículos para Paula Pozo. " +
                          "Gestión de vehículos, categorías, tarifas, seguros y extras " +
                          "con contrato alineado al Booking Prototipo."
                });
            }
        }
    }

    // ─── Extension method ────────────────────────────────────────────────────────
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            // 1. Registrar el configurador dinámico
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            // 2. Configurar SwaggerGen base (seguridad JWT)
            services.AddSwaggerGen(c =>
            {
                // El título/versión lo pone ConfigureSwaggerOptions arriba —
                // no hace falta repetirlo aquí.

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT en cabecera Authorization. Ejemplo: 'Bearer {token}'",
                    Name        = "Authorization",
                    In          = ParameterLocation.Header,
                    Type        = SecuritySchemeType.ApiKey,
                    Scheme      = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id   = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }
    }
}
