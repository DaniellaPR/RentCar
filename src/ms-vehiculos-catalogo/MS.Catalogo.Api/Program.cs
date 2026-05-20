// MS.Catalogo.Api/Program.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.Catalogo.Api.Extensions;
using MS.Catalogo.Api.Middleware;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCustomCors();
builder.Services.AddCustomVersioning();         // ← debe ir ANTES de AddCustomSwagger
builder.Services.AddCustomSwagger();            // ← usa IApiVersionDescriptionProvider registrado por AddCustomVersioning
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddCatalogoDependencies(builder.Configuration);
builder.Services.AddGrpc();

var app = builder.Build();

// ─── Swagger: siempre activo (en prod también sirve para el Booking) ──────────
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    // Genera un endpoint por cada versión registrada
    var provider = app.Services.GetRequiredService<Asp.Versioning.ApiExplorer.IApiVersionDescriptionProvider>();
    foreach (var description in provider.ApiVersionDescriptions)
    {
        c.SwaggerEndpoint(
            $"/swagger/{description.GroupName}/swagger.json",
            $"RentCar Ec — Catálogo {description.GroupName.ToUpperInvariant()}");
    }
    c.RoutePrefix = "swagger";   // accesible en /swagger
});

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGrpcService<MS.Catalogo.Api.GrpcServices.VehiculosGrpcService>();

app.Run();
