using FinalTask.Models;
using Newtonsoft.Json;

namespace FinalTask.Utils
{
    public static class JsonUtil
    {
        public static string _testJsonString = File.ReadAllText("../net6.0/Resources/testdata.json");
        public static string _configJsonString = File.ReadAllText("../net6.0/Resources/config.json");
        public static string _log = File.ReadAllText("../net6.0/Log/log.log").ToString();

        public static TestInfo[]? GetTestContent(string content)
        {
            return JsonConvert.DeserializeObject<TestInfo[]>(content);
        }

        public static TestData? GetTestData(string content)
        {
            return JsonConvert.DeserializeObject<TestData>(content);
        }

        public static ConfigData? GetConfigData(string content)
        {
            return JsonConvert.DeserializeObject<ConfigData>(content);
        }
    }
}
