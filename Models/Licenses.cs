namespace CryptlexLicensingApp.Models
{
    public class License
    {
        public string Key { get; set; }
        public bool Revoked { get; set; }
        public bool Suspended { get; set; }
        public int TotalActivations { get; set; }
        public int TotalDeactivations { get; set; }
        public int Validity { get; set; }
        public string ExpirationStrategy { get; set; }
        public string FingerprintMatchingStrategy { get; set; }
        public int AllowedActivations { get; set; }
        public int AllowedDeactivations { get; set; }
        public string Type { get; set; }
        public int AllowedFloatingClients { get; set; }
        public int ServerSyncGracePeriod { get; set; }
        public int ServerSyncInterval { get; set; }
        public int AllowedClockOffset { get; set; }
        public bool DisableClockValidation { get; set; }
        public int ExpiringSoonEventOffset { get; set; }
        public int LeaseDuration { get; set; }
        public string LeasingStrategy { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool AllowVmActivation { get; set; }
        public bool AllowContainerActivation { get; set; }
        public bool AllowClientLeaseDuration { get; set; }
        public bool UserLocked { get; set; }
        public bool RequireAuthentication { get; set; }
        public bool DisableGeoLocation { get; set; }
        public string Notes { get; set; }
        public string ProductId { get; set; }
        public object ProductVersionId { get; set; }
        public object MaintenancePolicyId { get; set; }
        public object MaintenanceExpiresAt { get; set; }
        public object CurrentReleaseVersion { get; set; }
        public string MaxAllowedReleaseVersion { get; set; }
        public object Organization { get; set; }
        public object User { get; set; }
        public object Reseller { get; set; }
        public object[] AdditionalUserIds { get; set; }
        public object AllowedIpRange { get; set; }
        public object[] AllowedIpRanges { get; set; }
        public object[] AllowedIpAddresses { get; set; }
        public object[] DisallowedIpAddresses { get; set; }
        public object[] AllowedCountries { get; set; }
        public object[] DisallowedCountries { get; set; }
        public object[] Metadata { get; set; }
        public object[] MeterAttributes { get; set; }
        public object[] Tags { get; set; }
        public object[] ExternalUserIds { get; set; }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
