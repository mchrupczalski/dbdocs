using System.Data;

namespace dbdocs.lib.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetDBConnection();
    }
}