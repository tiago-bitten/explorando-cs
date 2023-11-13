using DemoTypingTest.Exceptions;
using System.Text.Json;

namespace DemoTypingTest.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception.Message);

            context.Response.ContentType = "application/json";
            var response = context.Response;
            ApiError apiError = new ApiError
            {
                Path = context.Request.Path,
            };

            switch (exception)
            {
                case UnauthorizedAccessException e:
                    apiError.StatusCode = 401;
                    apiError.Message = "Unauthorized: Token not provided or invalid.";
                    break;

                case ApplicationException e:
                    apiError.StatusCode = 500;
                    apiError.Message = "Internal Server Error: " + e.Message;
                    break;

                case ValidationException e:
                    apiError.StatusCode = 422;
                    apiError.Message = "Validation Error: " + e.Message;
                    break;

                case NotFoundException e:
                    apiError.StatusCode = 404;
                    apiError.Message = "Resource Not Found: " + e.Message;
                    break;

                default:
                    apiError.StatusCode = 500;
                    apiError.Message = "Internal Server Error";
                    break;
            }

            var result = JsonSerializer.Serialize(apiError);
            await context.Response.WriteAsync(result);
        }
    }
}
