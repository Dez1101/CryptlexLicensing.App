using Microsoft.AspNetCore.Authentication;
using System.Net;

namespace CryptlexLicensingApp.Services
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

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, "An UnauthorizedAccessException occurred.");
                await HandleUnauthorizedAccessExceptionAsync(httpContext);
            }
        }

        private static async Task HandleUnauthorizedAccessExceptionAsync(HttpContext context)
        {
            await context.SignOutAsync("CookieAuthentication");

            // Then, redirect to the login page
            context.Response.Redirect("/Login");
        }
    }
}
