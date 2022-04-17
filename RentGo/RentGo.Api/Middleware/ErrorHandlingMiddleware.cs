using System.Net;
using Newtonsoft.Json;
using RentGo.Application.Exception;

namespace RentGo.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this._next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                _logger.LogError(ex, "Error");
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            if (ex is DomainException domEx)
            {
                code = (HttpStatusCode)domEx.ToHttpStatusCode();
            }

            var result = JsonConvert.SerializeObject(new { message = code != HttpStatusCode.InternalServerError ? ex.Message : string.Empty });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}