﻿using dbdocs.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace dbdocs.Serializers
{
    public class JsonSerializer : IJsonSerializer
    {
        /// <summary>
        /// Deserialize JSON to C# class object
        /// </summary>
        /// <typeparam name="T">Target class</typeparam>
        /// <param name="jsonString">JSON string</param>
        /// <returns></returns>
        public T FromJson<T>(string jsonString) => JsonConvert.DeserializeObject<T>(jsonString, Settings);

        /// <summary>
        /// Serialize C# class to JSON
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="model">Class object to serialize</param>
        /// <returns>JSON string</returns>
        public string ToJson<T>(T model) => JsonConvert.SerializeObject(model, Settings);

        /// <summary>
        /// Serializers settings
        /// </summary>
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
