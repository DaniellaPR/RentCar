using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MS.Identidad.Api.Models.Common;
using MS.Identidad.Business.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MS.Identidad.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error no controlado en el Microservicio de Identidad: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = new ApiErrorResponse
            {
                TraceId = context.TraceIdentifier
            };

            switch (exception)
            {
                case NotFoundException notFoundEx:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = notFoundEx.Message;
                    break;

                case MS.Identidad.Business.Exceptions.ValidationException e:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = "Se presentaron errores de validación.";
                    response.Errors.Add(e.Message);
                    break;

                case UnauthorizedException unauthorizedEx:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response.Message = unauthorizedEx.Message;
                    break;

                case BusinessException businessEx:
                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    response.Message = businessEx.Message;
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = "Ocurrió un error interno e inesperado en el servidor de Identidad.";
#if DEBUG
                    response.Errors.Add(exception.Message);
                    response.Errors.Add(exception.StackTrace);
#endif
                    break;
            }

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var result = JsonSerializer.Serialize(response, options);
            return context.Response.WriteAsync(result);
        }
    }
}
