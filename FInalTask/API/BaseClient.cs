using FinalTask.Models;
using FinalTask.Utils;
using RestSharp;

namespace FinalTask.API
{
    public class BaseClient
    {
        private static ConfigData _configData = JsonUtil.GetConfigData(JsonUtil._configJsonString);
        private RestClient _restClient = new RestClient(_configData.Api_Url);

        private BaseClient() { }

        private static BaseClient instance = null;

        public static BaseClient GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BaseClient();
                }
                return instance;
            }
        }

        public RestResponse ExecuteRequest(string url, Method method)
        {
            RestRequest _request = new RestRequest(url, method);
            return _restClient.Execute(_request);
        }

        public RestResponse ExecuteRequest(RestRequest request)
        {
            return _restClient.Execute(request);
        }
    }
}
