using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FinalTask.Models
{
    [JsonObject]
    public class TestData
    {
        [JsonPropertyName("variant")]
        public string Variant { get; set; }
        [JsonPropertyName("projectId")]
        public string ProjectId { get; set; }
        [JsonPropertyName("projectName")]
        public string ProjectName { get; set; }
        [JsonPropertyName("testName")]
        public string TestName { get; set; }
        [JsonPropertyName("SID")]
        public string SID { get; set; }
        [JsonPropertyName("methodName")]
        public string MethodName { get; set; }
        [JsonPropertyName("env")]
        public string Env { get; set; }
        [JsonPropertyName("contentType")]
        public string ContentType { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }
    }
}
