using CryptlexLicensingApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CryptlexLicensingApp.Pages
{
    public class LoginModel(ILogger<LoginModel> logger, HttpService httpService) : PageModel
    {
        private readonly ILogger<LoginModel> _logger = logger;
        private readonly HttpService _httpService = httpService;

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string AccountId { get; set; }

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Index");
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(AccountId))
            {
                var requestData = new
                {
                    accountId = AccountId,
                    email = Email,
                    password = Password
                };

                _logger.LogInformation("Sending authentication request: {RequestData}", requestData);

                var authResponse = await _httpService.SendPostAsync<AuthResponse>("v3/accounts/login", requestData, false);

                if (authResponse is not null)
                {
                    _logger.LogInformation("Authentication successful. Access Token: {AccessToken}", authResponse.AccessToken);

                    var claims = new List<Claim> { new(ClaimTypes.Name, Email), new(ClaimTypes.Authentication, authResponse.AccessToken) };
                    const string CookieAuthentication = "CookieAuthentication";
                    var identity = new ClaimsIdentity(claims, CookieAuthentication);
                    ClaimsPrincipal principal = new(identity);
                    await HttpContext.SignInAsync(CookieAuthentication, principal);
                    
                    return RedirectToPage("/Index");
                }
            }

            return Page();
        }
        private class AuthResponse
        {
            public string AccessToken { get; set; }
        }
    }
}
