using dbdocs.lib.DataAccess;
using dbdocs.lib.Infrastructure;
using dbdocs.lib.Interfaces;
using dbdocs.lib.Models;
using dbdocs.lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbdocs.lib.Processors
{
    public class ServerProcessor
    {
        private readonly IConfigModel _config;
        private readonly IServerDataService _serverDataService;

        public ServerProcessor(IConfigModel config, IServerDataService serverDataService)
        {
            _config = config;
            _serverDataService = serverDataService;
        }

        public IServerModel ProcessServer()
        {
            ServerModel output = new ServerModel();

            // get list of databases
            output.Databases = _serverDataService.GetDatabaseModels(_config.Databases).ToList();

            // get list of tables
            foreach (var db in output.Databases)
            {
                ProcessDatabase(db);
            }

            // get list of table fields

            return output;
        }

        private void ProcessDatabase(DatabaseModel db)
        {
            if (!_serverDataService.IsUserDbo(db.Name))
            {
                Console.WriteLine($"Cannot process { db.Name } database - dbo access required.");
                return;
            }

            db.Tables = ProcessTables(db.Name);
        }

        private List<TableModel> ProcessTables(string dbName)
        {
            var results = _serverDataService.GetTableModels(dbName).ToList();
            var tables = results.GroupBy(t => t.Uid).Select(c =>
            {
                var groupedTable = c.First();
                groupedTable.Fields = c.Select(t => t.Fields.Single()).ToList();
                return groupedTable;
            });

            return tables.ToList();
        }
    }
}
