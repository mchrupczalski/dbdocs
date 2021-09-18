using dbdocs.lib.Interfaces;

namespace dbdocs.lib.SQL
{
    public class SqlLoader : ISqlLoader
    {
        private readonly IFileSystem _fileSystem;

        public SqlLoader(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public string GetQuery_Database(string[] databases)
        {
            const string fName = "SQL\\Databases.sql";
            const string replaceTag = "<<Replace_Me>>";

            string query = _fileSystem.ReadTextFile(fName);
            string replaceWith = $"'{ string.Join("','", databases) }'";
            query = query.Replace(replaceTag, replaceWith);

            return query;
        }

        public string GetQuery_DboCheck(string dbName)
        {
            const string fName = "SQL\\DboCheck.sql";
            const string replaceTag = "<<Replace_Me>>";

            string query = _fileSystem.ReadTextFile(fName);
            query = query.Replace(replaceTag, dbName);

            return query;
        }

        public string GetQuery_Tables(string dbName)
        {
            const string fName = "SQL\\TablesAndColumns.sql";
            const string replaceTag = "<<Replace_Me>>";

            string query = _fileSystem.ReadTextFile(fName);
            query = query.Replace(replaceTag, dbName);

            return query;
        }
    }
}
