using dbdocs.lib.Infrastructure;
using dbdocs.lib.Interfaces;
using dbdocs.lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbdocs.lib.Services
{
    public class DatabaseDataService : DataServiceBase
    {
        private readonly string _dbName;

        public DatabaseDataService(IDataAccess dataAccess, string dbName) : base(dataAccess)
        {
            _dbName = dbName;
        }

        public bool IsUserDbo()
        {
            string query = $"USE { _dbName }; SELECT CAST(IS_MEMBER('db_owner') AS BIT) AS IsDbo;";
            return DataAccess.ExecuteTextWithOutput<bool>(query);
        }

        public IDatabaseModel GetDatabaseModel()
        {
            string query = "SELECT"
                           + "\n      d.database_id                  AS [Uid]"
                           + "\n     ,d.name                         AS [Name]"
                           + "\n     ,d.create_date                  AS CreateDate"
                           + "\n     ,d.compatibility_level          AS CompatibilityLevel"
                           + "\n     ,d.collation_name               AS Collation"
                           + "\n     ,d.user_access_desc             AS UserAccess"
                           + "\n     ,d.is_read_only                 AS IsReadOnly"
                           + "\n FROM sys.databases AS d"
                           + $"\n WHERE d.name = '{ _dbName }'";

            return DataAccess.ExecuteTextLoadModel<DatabaseModel>(query);
        }
    }
}
