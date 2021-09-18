using dbdocs.lib.Infrastructure;
using dbdocs.lib.Interfaces;
using dbdocs.lib.Models;
using System;
using System.Collections.Generic;

namespace dbdocs.lib.Services
{
    public class ServerDataService : DataServiceBase, IServerDataService
    {
        private readonly ISqlLoader _sqlLoader;

        public ServerDataService(IDataAccess dataAccess, ISqlLoader sqlLoader) : base(dataAccess)
        {
            _sqlLoader = sqlLoader;
        }

        public IEnumerable<DatabaseModel> GetDatabaseModels(string[] databasesNames)
        {
            string query = _sqlLoader.GetQuery_Database(databasesNames);
            return DataAccess.ExecuteTextLoadModelCollection<DatabaseModel>(query);
        }

        public bool IsUserDbo(string dbName)
        {
            string query = _sqlLoader.GetQuery_DboCheck(dbName);
            return DataAccess.ExecuteTextWithOutput<bool>(query);
        }

        public IEnumerable<TableModel> GetTableModels(string dbName)
        {
            string query = _sqlLoader.GetQuery_Tables(dbName);
            Func<TableModel, TableFieldModel, TableModel> func = (t, c) => { t.Fields.Add(c); return t; };

            //return DataAccess.ExecuteTextLoadModelCollection<TableModel>(query);
            return DataAccess.ExecuteText_LoadModelCollection_Multimapping<TableModel, TableFieldModel>(query, "ColumnId", func);
        }
    }
}
