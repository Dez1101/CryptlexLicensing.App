using CryptlexLicensingApp.Models;
using CryptlexLicensingApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CryptlexLicensingApp.Pages;

[Authorize]
public class LicenseTemplatesModel(ILogger<LoginModel> logger, HttpService httpService) : PageModel
{
    private readonly ILogger<LoginModel> _logger = logger;
    private readonly HttpService _httpService = httpService;
    public List<LicenseTemplateRequest>  licenseTemplates { get; set; } = [];

    private async Task GetLicenses()
    {
        licenseTemplates = await _httpService.SendGetAsync<List<LicenseTemplateRequest>>("v3/license-templates");
        _logger.LogInformation("License Templates: {Count}", licenseTemplates.Count);
    }
}
