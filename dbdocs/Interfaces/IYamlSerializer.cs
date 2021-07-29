namespace dbdocs.Interfaces
{
    public interface IYamlSerializer
    {
        T FromYaml<T>(string yaml);
        string ToYaml<T>(T model);
    }
}