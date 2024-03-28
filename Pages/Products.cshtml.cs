using System.IO;
using System.Text.Json;
using CryptlexLicensingApp.Models;
using CryptlexLicensingApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Xml.Linq;
using System.Text;


namespace CryptlexLicensingApp.Pages
{
    [Authorize]
    public class ProductsModel(ILogger<LoginModel> logger, HttpService httpService) : PageModel
    {
        private readonly ILogger<LoginModel> _logger = logger;
        private readonly HttpService _httpService = httpService;
        public List<ProductResponse> ProductResponses { get; set; } = [];
        public List<LicenceTemplate> LicenceTemplates { get; set; } = [];

        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string DisplayName { get; set; }
        [BindProperty]
        public string LicenseTemplateId { get; set; }
        [BindProperty]
        public string Name { get; set; }

        public async Task OnGet()
        {
            try
            {
                await GetProducts();
                await GetLicenceTemplates();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                throw;
            }
        }

        private async Task GetProducts()
        {
            ProductResponses = await _httpService.SendGetAsync<List<ProductResponse>>("v3/products");
            _logger.LogInformation("Products: {Count}", ProductResponses?.Count);
        }

        private async Task GetLicenceTemplates()
        {
            LicenceTemplates = await _httpService.SendGetAsync<List<LicenceTemplate>>("v3/license-templates");
        }

        public async Task OnPost()
        {
            var data = new
            {
                Description,
                DisplayName,
                Name,
                LicenseTemplateId = "d528fdbd-0fb8-48f5-9b56-7638ee5790c1"
            };

            await _httpService.SendPostAsync<ProductPostResponse>("v3/products", data);
            HttpContext.Response.Redirect("/products");
        }

        public IActionResult OnPostSaveProductsToFile()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(ProductResponses);
                var downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                var filePath = Path.Combine(downloadsFolder, "products.json");

                SaveJsonToFile(filePath, jsonString);

                _logger.LogInformation("Products saved to file: {FilePath}", filePath);

                return RedirectToPage(); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving products to file");
                return Page();
            }
        }
        private void SaveJsonToFile(string filePath, string jsonString)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(jsonString);
            }
        }
    } 
}
