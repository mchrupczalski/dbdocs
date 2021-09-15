using dbdocs.lib.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace dbdocs.lib.Models
{
    [ExcludeFromCodeCoverage]
    public class ServerConnectionModel : IServerConnectionModel
    {
        [JsonProperty("Data Source")]
        public string DataSource { get; set; } = "localhost";

        [JsonProperty("Initial catalog")]
        public string InitialCatalog { get; set; } = "master";

        [JsonProperty("Integrated Security")]
        public bool IntegratedSecurity { get; set; } = true;

        [JsonProperty("User ID")]
        public string UserId { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Connect Timeout")]
        public int ConnectTimeout { get; set; } = 60;

        [JsonProperty("Encrypt")]
        public bool Encrypt { get; set; } = false;

        [JsonProperty("Trust Server Certificate")]
        public bool TrustServerCertificate { get; set; } = false;

        [JsonProperty("Application Intent")]
        public string ApplicationIntent { get; set; } = "Read";

        [JsonProperty("Multi Subnet Failover")]
        public bool MultiSubnetFailover { get; set; } = false;

        public string ConnectionString
        {
            get
            {
                if (IntegratedSecurity)
                {
                    return $"Data Source={ DataSource };"
                           + $"Initial Catalog={ InitialCatalog };"
                           + $"Integrated Security={ IntegratedSecurity };"
                           + $"Connect Timeout={ ConnectTimeout };"
                           + $"Encrypt={ Encrypt };"
                           + $"TrustServerCertificate={ TrustServerCertificate };"
                           + $"ApplicationIntent={ ApplicationIntent };"
                           + $"MultiSubnetFailover={ MultiSubnetFailover }";
                }
                else
                {
                    return $"Data Source={ DataSource };"
                           + $"Initial Catalog={ InitialCatalog };"
                           + $"User ID={ UserId };"
                           + $"Password={ Password };"
                           + $"Connect Timeout={ ConnectTimeout };"
                           + $"Encrypt={ Encrypt };"
                           + $"TrustServerCertificate={ TrustServerCertificate };"
                           + $"ApplicationIntent={ ApplicationIntent };"
                           + $"MultiSubnetFailover={ MultiSubnetFailover }";
                }
            }
        }
    }
}