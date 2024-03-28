using CryptlexLicensingApp.Models;
using CryptlexLicensingApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CryptlexLicensingApp.Pages
{
    public class LicensesModel(ILogger<LoginModel> logger, HttpService httpService) : PageModel
    {
        private readonly ILogger<LoginModel> _logger = logger;
        private readonly HttpService _httpService = httpService;
        public List<License> Licences { get; set; } = [];

        public async Task OnGet()
        {
            try
            {
                await GetLicenses();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private async Task GetLicenses()
        {
            Licences = await _httpService.SendGetAsync<List<License>>("v3/licenses");
            _logger.LogInformation("Licenses: {Count}", Licences.Count);
        }
    }
}
