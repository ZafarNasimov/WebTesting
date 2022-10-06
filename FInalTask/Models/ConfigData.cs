using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FinalTask.Models
{
    [JsonObject]
    public class ConfigData
    {
        [JsonPropertyName("main_url")]
        public string Main_Url { get; set; }
        [JsonPropertyName("api_url")]
        public string Api_Url { get; set; }
    }
}
