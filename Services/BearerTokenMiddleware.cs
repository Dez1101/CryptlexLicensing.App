using System.Security.Claims;

namespace CryptlexLicensingApp.Services
{
    public class BearerTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public BearerTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, HttpService httpService)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                string accessToken = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Authentication)?.Value;
                if (!string.IsNullOrEmpty(accessToken))
                {
                    httpService.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            await _next(context);
        }
    }

}
