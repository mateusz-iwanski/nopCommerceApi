using Newtonsoft.Json;
using nopCommerceApi.Exceptions;
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
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = 500;  // internal server error
                await context.Response.WriteAsync("Something went wrong");
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode)
        {
            var correlationId = Guid.NewGuid().ToString();            

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = statusCode;

            var errorResponse = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = exception.Message,
                Detail = _env.IsDevelopment() ? exception.StackTrace : null
            };

            var logErrorBuild = new StringBuilder()
                .Append($"Error {correlationId}|")
                .Append($"Processing request for {context.Request.Path}|")
                .Append($"Response: {JsonConvert.SerializeObject(errorResponse)}");

            _logger.LogError(exception, logErrorBuild.ToString());

            await response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }

    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
    }
}
