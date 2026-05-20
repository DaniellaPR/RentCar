// MS.Identidad.Api/Program.cs  (Monitoreo es idéntico, solo cambia el namespace de Extensions)
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.Identidad.Api.Extensions;       // ← MS.Monitoreo.Api.Extensions para Monitoreo
using MS.Identidad.Api.Middleware;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCustomCors();
builder.Services.AddCustomVersioning();
builder.Services.AddCustomSwagger();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddIdentidadDependencies(builder.Configuration);   // ← AddMonitoreoDependencies para Monitoreo

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    var provider = app.Services.GetRequiredService<Asp.Versioning.ApiExplorer.IApiVersionDescriptionProvider>();
    foreach (var description in provider.ApiVersionDescriptions)
    {
        c.SwaggerEndpoint(
            $"/swagger/{description.GroupName}/swagger.json",
            $"RentCar Ec — Identidad {description.GroupName.ToUpperInvariant()}"); // ← "Monitoreo" para Monitoreo
    }
    c.RoutePrefix = "swagger";
});

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
