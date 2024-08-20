using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace CardsAPI
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionMiddleware> _logger;


        public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }

        //HttpContext : Specifies information about your http request
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandeExceptionAsync(httpContext, ex);
            }
        }
        public class NotFoundException : Exception
        {
            public NotFoundException(string message) : base(message) { }
        }

        public Task HandeExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, "Unexpected error in your code");

            int httpStatusCode;
            string httpMessage;

            switch (ex) { 
                case BadHttpRequestException _:
                    httpStatusCode = (int)HttpStatusCode.BadRequest;
                    httpMessage = "Bad Request: Client side Error";
                    break;
                case NotFoundException _:
                    httpStatusCode = (int)HttpStatusCode.NotFound;
                    httpMessage = "Resource Not Found";
                    break;
                default:
                    httpStatusCode = (int)HttpStatusCode.InternalServerError;
                    httpMessage = "InternalServer Error";
                    break;
            }

            var response = new
            {
                statuscode = httpStatusCode,
                Message = httpMessage
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = httpStatusCode;

            return context.Response.WriteAsJsonAsync(response);
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
