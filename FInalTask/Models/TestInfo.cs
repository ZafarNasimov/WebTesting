using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FinalTask.Models
{
    [JsonObject]
    public class TestInfo
    {
        [JsonPropertyName("duration")]
        public string Duration { get; set; }
        [JsonPropertyName("method")]
        public string Method { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }
        [JsonPropertyName("endTime")]
        public DateTime EndTime { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
