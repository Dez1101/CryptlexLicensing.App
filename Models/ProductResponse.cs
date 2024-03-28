namespace CryptlexLicensingApp.Models
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string PublicKey { get; set; }
        public int TotalLicenses { get; set; }
        public int TotalTrialActivations { get; set; }
        public int TotalReleases { get; set; }
        public int TotalProductVersions { get; set; }
        public int TotalFeatureFlags { get; set; }
        public object[] EmailTemplates { get; set; }
        public object[] AutomatedEmails { get; set; }
        public string LicenseTemplateId { get; set; }
        public object TrialPolicyId { get; set; }
        public Licensepolicy LicensePolicy { get; set; }
        public object TrialPolicy { get; set; }
        public object[] Metadata { get; set; }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class Licensepolicy
    {
        public int Validity { get; set; }
        public string ExpirationStrategy { get; set; }
        public string FingerprintMatchingStrategy { get; set; }
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
        public bool RequireAuthentication { get; set; }
        public object[] RequiredMetadataKeys { get; set; }
        public object[] RequiredMeterAttributes { get; set; }
        public string Name { get; set; }
        public bool AllowVmActivation { get; set; }
        public bool AllowContainerActivation { get; set; }
        public bool UserLocked { get; set; }
        public bool DisableGeoLocation { get; set; }
        public object AllowedIpRange { get; set; }
        public object[] AllowedIpRanges { get; set; }
        public object[] AllowedCountries { get; set; }
        public object[] DisallowedCountries { get; set; }
        public object[] AllowedIpAddresses { get; set; }
        public object[] DisallowedIpAddresses { get; set; }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}