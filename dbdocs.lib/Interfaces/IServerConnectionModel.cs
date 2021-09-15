namespace dbdocs.lib.Interfaces
{
    public interface IServerConnectionModel
    {
        string ApplicationIntent { get; set; }
        int ConnectTimeout { get; set; }
        string DataSource { get; set; }
        bool Encrypt { get; set; }
        bool IntegratedSecurity { get; set; }
        bool MultiSubnetFailover { get; set; }
        string Password { get; set; }
        bool TrustServerCertificate { get; set; }
        string UserId { get; set; }
        string ConnectionString { get; }
    }
}