using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.Monitoreo.Api.Extensions;
using MS.Monitoreo.Api.Middleware;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Agregar Controladores nativos
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuración de Infraestructura
builder.Services.AddCustomCors();
builder.Services.AddCustomSwagger();
builder.Services.AddCustomVersioning();
builder.Services.AddJwtAuthentication(builder.Configuration);

// Inyección de dependencias exclusiva de MS.Monitoreo
builder.Services.AddMonitoreoDependencies(builder.Configuration);

var app = builder.Build();

// Configuración del Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MS.Monitoreo.Api v1");
    });
}

// Middleware global de excepciones
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
