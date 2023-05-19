using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env; // This will give us access to the environment variables
            _logger = logger; // This will give us access to the logger
            _next = next; // This will give us access to the next middleware
        }

        public async Task InvokeAsync(HttpContext context) // This method will be called whenever an exception is thrown
        {
            try {
                await _next(context); // This will call the next middleware
            } 
            catch (Exception ex) { // This will catch any exceptions that are thrown
                _logger.LogError(ex, ex.Message); // This will log the exception
                context.Response.ContentType = "application/json"; // This will set the content type of the response to JSON
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                // This will create a new ApiException object with the status code, message, and stack trace of the exception
                var response = _env.IsDevelopment() 
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString()) 
                    : new ApiException(context.Response.StatusCode, "Internal Server Error", null);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }; // This will create a new JsonSerializerOptions object with the property naming policy set to camel case

                var json = JsonSerializer.Serialize(response, options); // This will serialize the response object to JSON

                await context.Response.WriteAsync(json); // This will write the JSON to the response
            }
        }
    }
}