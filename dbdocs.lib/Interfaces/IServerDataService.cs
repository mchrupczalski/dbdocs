using dbdocs.lib.Models;
using System.Collections.Generic;

namespace dbdocs.lib.Interfaces
{
    public interface IServerDataService
    {
        IEnumerable<DatabaseModel> GetDatabaseModels(string[] databasesNames);
        bool IsUserDbo(string dbName);
    }
}