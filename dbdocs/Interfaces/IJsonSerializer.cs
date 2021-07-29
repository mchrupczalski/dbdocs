namespace dbdocs.Interfaces
{
    public interface IJsonSerializer
    {
        T FromJson<T>(string jsonString);
        string ToJson<T>(T model);
    }
}