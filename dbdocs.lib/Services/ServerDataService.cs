using dbdocs.lib.Infrastructure;
using dbdocs.lib.Interfaces;
using dbdocs.lib.Models;
using System.Collections.Generic;

namespace dbdocs.lib.Services
{
    public class ServerDataService : DataServiceBase, IServerDataService
    {
        public ServerDataService(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public IEnumerable<DatabaseModel> GetDatabaseModels(string[] databasesNames)
        {
            string query = string.Empty;
            query += $"\nSELECT";
            query += $"\n     d.database_id                  AS [Uid]";
            query += $"\n    ,d.name                         AS [Name]";
            query += $"\n    ,d.create_date                  AS CreateDate";
            query += $"\n    ,d.compatibility_level          AS CompatibilityLevel";
            query += $"\n    ,d.collation_name               AS Collation";
            query += $"\n    ,d.user_access_desc             AS UserAccess";
            query += $"\n    ,d.is_read_only                 AS IsReadOnly";
            query += $"\nFROM sys.databases AS d";
            query += $"\nWHERE d.name IN ('{ string.Join("','", databasesNames) }')";

            return DataAccess.ExecuteTextLoadModelCollection<DatabaseModel>(query);
        }

        public bool IsUserDbo(string dbName)
        {
            string query = $"USE { dbName }; SELECT CAST(IS_MEMBER('db_owner') AS BIT) AS IsDbo;";
            return DataAccess.ExecuteTextWithOutput<bool>(query);
        }
    }
}
