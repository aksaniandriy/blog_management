using System.Threading;
using System.Threading.Tasks;
using Blog.Common.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Blog.Api.Middlewares
{
    public class ApiExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ApiExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (BlogException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, BlogException exception)
        {
            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)exception.HttpReturnCode;
            string message = exception.Message ?? "Unexpected error";
            await response.WriteAsync(message, new CancellationToken());
        }
    }
}
