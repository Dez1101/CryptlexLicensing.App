using CryptlexLicensingApp.Models;
using CryptlexLicensingApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace CryptlexLicensingApp.Pages;

[Authorize]
public class LicenseTemplatesModel(ILogger<LoginModel> logger, HttpService httpService) : PageModel
{
    private readonly ILogger<LoginModel> _logger = logger;
    private readonly HttpService _httpService = httpService;
    public List<LicenceTemplate>  licenseTemplates { get; set; } = [];

    public async Task OnGet()
    {
        await GetLicenses();
    }

    private async Task GetLicenses()
    {
        licenseTemplates = await _httpService.SendGetAsync<List<LicenceTemplate>>("v3/license-templates");
        _logger.LogInformation("License Templates: {Count}", licenseTemplates.Count);
    }

    public async Task OnPost()
    {
        var data = new
        {
            AllowClientLeaseDuration,
            AllowContainerActivation,
            AllowedActivations,
            AllowedClockOffset,
            AllowedDeactivations,
            AllowVmActivation,
            DisableClockValidation,
            DisableGeoLocation,
            ExpirationStrategy,
            ExpiringSoonEventOffset,
            FingerprintMatchingStrategy,
            Name,
            ServerSyncGracePeriod,
            Type,
            UserLocked,
            Validity,
        };

        var rtn = await _httpService.SendPostAsync<dynamic>("v3/license-templates", data);
        HttpContext.Response.Redirect("/LicenseTemplates");
    }

    #region form elements
    [BindProperty]
    public bool AllowClientLeaseDuration { get; set; }

    [BindProperty]
    public bool AllowContainerActivation { get; set; }

    [BindProperty]
    public int AllowedActivations { get; set; }

    [BindProperty]
    public int AllowedClockOffset { get; set; }

    [BindProperty]
    public int AllowedDeactivations { get; set; }

    [BindProperty]
    public bool AllowVmActivation { get; set; }

    [BindProperty]
    public bool DisableClockValidation { get; set; }

    [BindProperty]
    public bool DisableGeoLocation { get; set; }

    [BindProperty]
    public string ExpirationStrategy { get; set; }

    [BindProperty]
    public int ExpiringSoonEventOffset { get; set; }

    [BindProperty]
    public string FingerprintMatchingStrategy { get; set; }

    [BindProperty]
    public string Name { get; set; }

    [BindProperty]
    public int ServerSyncGracePeriod { get; set; }

    [BindProperty]
    public int ServerSyncInterval { get; set; }

    [BindProperty]
    public string Type { get; set; }

    [BindProperty]
    public bool UserLocked { get; set; }

    [BindProperty]
    public int Validity { get; set; }
    #endregion
}
