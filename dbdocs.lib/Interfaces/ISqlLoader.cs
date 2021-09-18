namespace dbdocs.lib.Interfaces
{
    public interface ISqlLoader
    {
        string GetQuery_Database(string[] databases);
        string GetQuery_DboCheck(string dbName);
        string GetQuery_Tables(string dbName);
    }
}