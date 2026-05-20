// MS.Alquiler.Api/Program.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.Alquiler.Api.Extensions;
using MS.Alquiler.Api.Middleware;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCustomCors();
builder.Services.AddCustomVersioning();
builder.Services.AddCustomSwagger();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAlquilerDependencies(builder.Configuration);
builder.Services.AddGrpc();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    var provider = app.Services.GetRequiredService<Asp.Versioning.ApiExplorer.IApiVersionDescriptionProvider>();
    foreach (var description in provider.ApiVersionDescriptions)
    {
        c.SwaggerEndpoint(
            $"/swagger/{description.GroupName}/swagger.json",
            $"RentCar Ec — Alquiler {description.GroupName.ToUpperInvariant()}");
    }
    c.RoutePrefix = "swagger";
});

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGrpcService<MS.Alquiler.Api.GrpcServices.ReservasGrpcService>();

app.Run();
