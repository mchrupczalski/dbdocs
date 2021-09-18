using dbdocs.lib.DataAccess;
using dbdocs.lib.Interfaces;
using dbdocs.lib.Models;
using dbdocs.lib.Processors;
using dbdocs.lib.Providers;
using dbdocs.lib.Serializers;
using dbdocs.lib.Services;
using dbdocs.lib.SQL;
using dbdocs.lib.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.IO;

namespace dbdocs.console
{
    class Program
    {
        private static ConfigProvider<JsonConfigModel> _configProvider = null;
        private static JsonConfigModel _config = null;

        static void Main(string[] args)
        {
            try
            {
                DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);

                _config = LoadConfig();
                string cnxString = _config.ServerConnectionInfo.ConnectionString;
                var cnxFactory = new DbConnectionFactory(cnxString);
                var dal = new SqlServerDataAccess(cnxFactory);
                var fs = new FileSystem();
                var sql = new SqlLoader(fs);
                var sds = new ServerDataService(dal, sql);
                var processor = new ServerProcessor(_config, sds);
                var serverInfo = (ServerModel)processor.ProcessServer();
                GenerateDoc(serverInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: { ex.Message }");
            }

            Console.WriteLine("done");
            Console.ReadLine();
        }

        private static void GenerateDoc(ServerModel serverModel)
        {
            string fileSavePath = $"{ Directory.GetCurrentDirectory() }\\dbdocs\\db_docs_generated.json";

            var serializer = new JsonSerializer();
            string docJson = serializer.Serialize<ServerModel>(serverModel);
            var fs = new FileSystem();
            fs.SaveTextFile(docJson, fileSavePath);

        }

        private static JsonConfigModel LoadConfig()
        {
            try
            {
                string configFilePath = GetConfigFilePath();
                IFileSystem fileSystem = new FileSystem();
                var configString = fileSystem.ReadTextFile(configFilePath);
                _configProvider = new ConfigProvider<JsonConfigModel>(new JsonSerializer(), configString);
                return _configProvider.GetConfig();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetConfigFilePath()
        {
            string configFileName = "dbdocs_config.json";
            string filePath = $"{ Directory.GetCurrentDirectory() }\\{ configFileName }";

            bool isFile = File.Exists(filePath);
            if (!isFile)
            {
                Console.WriteLine("The config file has not been found. Please input full path for the config file:");
                filePath = Console.ReadLine();
                isFile = File.Exists(filePath);
            }

            if (!isFile)
            {
                throw new NullReferenceException("Config file has not been found.");
            }

            return filePath;
        }
    }

    

}


