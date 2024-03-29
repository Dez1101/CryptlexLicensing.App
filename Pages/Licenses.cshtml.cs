using CryptlexLicensingApp.Models;
using CryptlexLicensingApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CryptlexLicensingApp.Pages
{
    [Authorize]
    public class LicensesModel(ILogger<LoginModel> logger, HttpService httpService) : PageModel
    {
        private readonly ILogger<LoginModel> _logger = logger;
        private readonly HttpService _httpService = httpService;
        public List<License> Licences { get; set; } = [];
        public List<ProductResponse> ProductResponses { get; set; } = [];

        [BindProperty]
        public string ProductId { get; set; }

        public async Task OnGet()
        {
            try
            {
                await GetProducts();
                await GetLicenses();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task GetProducts()
        {
            ProductResponses = await _httpService.SendGetAsync<List<ProductResponse>>("v3/products");
            _logger.LogInformation("Products: {Count}", ProductResponses?.Count);
        }

        private async Task GetLicenses()
        {
            Licences = await _httpService.SendGetAsync<List<License>>("v3/licenses");
            _logger.LogInformation("Licenses: {Count}", Licences?.Count);
        }

        public async Task OnPost()
        {
            var data = new
            {
                ProductId,
            };

            var rtn = await _httpService.SendPostAsync<ProductPostResponse>("v3/licenses", data);
            HttpContext.Response.Redirect("/licenses");
        }
    }
}
