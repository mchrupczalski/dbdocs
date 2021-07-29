namespace dbdocs.Interfaces
{
    public interface IConfigModel
    {
        string DataBase { get; set; }
        string Server { get; set; }
        string SqlPassword { get; set; }
        string SqlProjectRootPath { get; set; }
        string SqlUserName { get; set; }
        bool UseWindowsAuth { get; set; }
    }
}