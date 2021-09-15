using dbdocs.lib.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dbdocs.lib.Serializers.JsonSerializer;

namespace dbdocs.lib.Models
{
    public class JsonConfigModel : IConfigModel
    {
        [JsonProperty("Server Connection Info")]
        [JsonConverter(typeof(ConcreteTypeConverter<ServerConnectionModel>))]
        public IServerConnectionModel ServerConnectionInfo { get; set; }
        
        [JsonProperty("Databases")]
        public string[] Databases { get; set; }
    }
}
