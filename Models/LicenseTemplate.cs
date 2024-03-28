namespace CryptlexLicensingApp.Models;

public class LicenseTemplateRequest
{
    public string Name { get; set; }
    public string FingerprintMatchingStrategy { get; set; }
    public bool AllowVmActivation { get; set; }
    public bool AllowContainerActivation { get; set; }
    public bool UserLocked { get; set; }
    public bool DisableGeoLocation { get; set; }
    public string AllowedIpRange { get; set; }
    public List<string> AllowedIpRanges { get; set; }
    public List<string> AllowedCountries { get; set; }
    public List<string> DisallowedCountries { get; set; }
    public List<string> AllowedIpAddresses { get; set; }
    public List<string> DisallowedIpAddresses { get; set; }
    public int Validity { get; set; }
    public string ExpirationStrategy { get; set; }
    public int AllowedActivations { get; set; }
    public int AllowedDeactivations { get; set; }
    public string Type { get; set; }
    public string KeyPattern { get; set; }
    public int LeaseDuration { get; set; }
    public bool AllowClientLeaseDuration { get; set; }
    public string LeasingStrategy { get; set; }
    public int AllowedFloatingClients { get; set; }
    public int ServerSyncGracePeriod { get; set; }
    public int ServerSyncInterval { get; set; }
    public int AllowedClockOffset { get; set; }
    public bool DisableClockValidation { get; set; }
    public int ExpiringSoonEventOffset { get; set; }
    public List<string> RequiredMetadataKeys { get; set; }
    public List<string> RequiredMeterAttributes { get; set; }

    public LicenseTemplateRequest()
    {
        AllowedIpRanges = new List<string>();
        AllowedCountries = new List<string>();
        DisallowedCountries = new List<string>();
        AllowedIpAddresses = new List<string>();
        DisallowedIpAddresses = new List<string>();
        RequiredMetadataKeys = new List<string>();
        RequiredMeterAttributes = new List<string>();
    }
}

