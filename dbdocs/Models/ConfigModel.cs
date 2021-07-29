using dbdocs.Interfaces;
using Newtonsoft.Json;

namespace dbdocs.Models
{
    public class ConfigModel : IConfigModel
    {
        private string _server;
        private string _dataBase;
        private bool _useWindowsAuth;
        private string _sqlUserName;
        private string _sqlPassword;
        private string _sqlProjectRootPath;

        [JsonProperty("server")]
        public string Server { get => _server; set => _server = value; }

        [JsonProperty("dataBase")]
        public string DataBase { get => _dataBase; set => _dataBase = value; }

        [JsonProperty("useWindowsAuth")]
        public bool UseWindowsAuth { get => _useWindowsAuth; set => _useWindowsAuth = value; }

        [JsonProperty("sqlUserName")]
        public string SqlUserName { get => _sqlUserName; set => _sqlUserName = value; }

        [JsonProperty("sqlPassword")]
        public string SqlPassword { get => _sqlPassword; set => _sqlPassword = value; }

        [JsonProperty("sqlProjectRootPath")]
        public string SqlProjectRootPath { get => _sqlProjectRootPath; set => _sqlProjectRootPath = value; }
    }
}
