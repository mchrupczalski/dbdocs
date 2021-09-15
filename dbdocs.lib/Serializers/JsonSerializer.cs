using dbdocs.lib.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace dbdocs.lib.Serializers
{
    public class JsonSerializer : ISerializer
    {
        public class ConcreteTypeConverter<TConcrete> : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                //assume we can convert to anything for now
                return true;
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                //explicitly specify the concrete type we want to create
                return serializer.Deserialize<TConcrete>(reader);
            }

            public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                //use the default serialization - it works fine
                serializer.Serialize(writer, value);
            }
        }

        /// <summary>
        /// De-serialize JSON to C# class object
        /// </summary>
        /// <typeparam name="T">Target class</typeparam>
        /// <param name="jsonString">JSON string</param>
        /// <returns></returns>
        public T Deserialize<T>(string jsonString) => JsonConvert.DeserializeObject<T>(jsonString, Settings);

        /// <summary>
        /// Serialize C# class to JSON
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="model">Class object to serialize</param>
        /// <returns>JSON string</returns>
        public string Serialize<T>(T model) => JsonConvert.SerializeObject(model, Settings);

        /// <summary>
        /// Serializers settings
        /// </summary>
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            TypeNameHandling = TypeNameHandling.Auto,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
