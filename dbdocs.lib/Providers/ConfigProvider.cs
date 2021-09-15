using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbdocs.lib.Interfaces;

namespace dbdocs.lib.Providers
{
    public class ConfigProvider<T> where T : IConfigModel
    {
        private readonly ISerializer _serializer;
        private readonly string _config;

        public ConfigProvider(ISerializer serializer, string config)
        {
            if (string.IsNullOrEmpty(config))
            {
                throw new ArgumentException($"'{nameof(config)}' cannot be null or empty.", nameof(config));
            }

            _serializer = serializer;
            _config = config;
        }

        public T GetConfig()
        {
            return _serializer.Deserialize<T>(_config);
        }
    }
}
