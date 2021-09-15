using dbdocs.lib.Interfaces;

namespace dbdocs.lib.Interfaces
{
    public interface IConfigModel
    {
        IServerConnectionModel ServerConnectionInfo { get; set; }
        string[] Databases { get; set; }
    }
}