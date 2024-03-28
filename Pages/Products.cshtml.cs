using CryptlexLicensingApp.Models;
using CryptlexLicensingApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace CryptlexLicensingApp.Pages
{
    [Authorize]
    public class ProductsModel(ILogger<LoginModel> logger, HttpService httpService) : PageModel
    {
        private readonly ILogger<LoginModel> _logger = logger;
        private readonly HttpService _httpService = httpService;
        public List<ProductResponse> ProductResponses { get; set; } = [];

        public async Task OnGet()
        {
            try
            {
                await GetProducts();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private async Task GetProducts()
        {
            ProductResponses = await _httpService.SendGetAsync<List<ProductResponse>>("v3/products");
            _logger.LogInformation("Products: {Count}", ProductResponses?.Count);
        }
    }
}
