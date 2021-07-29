using dbdocs.Interfaces;
using YamlDotNet.Serialization;

namespace dbdocs.Serializers
{
    public class YamlSerializer : IYamlSerializer
    {
        /// <summary>
        /// Serialize C# Class to YAML
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="model">Class object to serialize</param>
        /// <returns>YAML string</returns>
        public string ToYaml<T>(T model)
        {
            var serializer = new SerializerBuilder().Build();
            return serializer.Serialize(model);
        }

        /// <summary>
        /// Deserialize YAML to C# class object
        /// </summary>
        /// <typeparam name="T">Target class</typeparam>
        /// <param name="yaml">YAML string</param>
        /// <returns></returns>
        public T FromYaml<T>(string yaml)
        {
            var deserializer = new DeserializerBuilder().Build();
            return deserializer.Deserialize<T>(yaml);
        }
    }
}
