using dbdocs.lib.Models;
using System.Collections.Generic;

namespace dbdocs.lib.Interfaces
{
    public interface IServerDataService
    {
        IEnumerable<DatabaseModel> GetDatabaseModels(string[] databasesNames);
        IEnumerable<TableModel> GetTableModels(string dbName);
        bool IsUserDbo(string dbName);
    }
}