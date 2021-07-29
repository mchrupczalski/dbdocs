namespace dbdocs.Interfaces
{
    public interface IConfigViewModel
    {
        IConfigModel ConfigModel { get; }

        void Load();
    }
}