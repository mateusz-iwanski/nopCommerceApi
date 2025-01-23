using Newtonsoft.Json;
using nopCommerceApi.Exceptions;
using System;
using System.Diagnostics;
using System.Text;

namespace nopCommerceApi.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger, IHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestException exception)
            {
                await HandleExceptionAsync(context, exception, 400);
            }
            catch (NotFoundExceptions exception)
            {
                await HandleExceptionAsync(context, exception, 404);
            }
            catch (UnauthorizedAccessException exception)
            {
                await HandleExceptionAsync(context, exception, 401);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception, 400);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode)
        {
            var correlationId = Guid.NewGuid().ToString();

            var errorResponse = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = exception.Message,
                Detail = _env.IsDevelopment() ? exception.StackTrace : null,
                HelpLink = exception.HelpLink ?? null,
                Source = exception.Source ?? null,
                InnerMessage = exception.InnerException?.Message ?? null
            };

            context.Items["ErrorResponse"] = errorResponse;

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = statusCode;

            var logErrorBuild = new StringBuilder()
                .Append($"Error {correlationId}|")
                .Append($"Processing request for {context.Request.Path}|")
                .Append($"Response: {JsonConvert.SerializeObject(errorResponse)}");

            _logger.LogError(exception, logErrorBuild.ToString());
        }
    }

    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Detail { get; set; }
        public string? HelpLink { get; set; }
        public string? Source { get; set; }
        public string? InnerMessage { get; set; }
    }
}
