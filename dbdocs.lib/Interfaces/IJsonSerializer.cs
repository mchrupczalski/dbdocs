namespace dbdocs.lib.Interfaces
{
    public interface ISerializer
    {
        T Deserialize<T>(string jsonString);
        string Serialize<T>(T model);
    }
}