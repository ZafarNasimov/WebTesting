using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;

namespace FinalTask.API
{
    public static class ProjectAPI
    {
        private static BaseClient baseClient = BaseClient.GetInstance;

        public static RestResponse GetToken(string variant)
        {
            RestRequest request = new RestRequest("token/get", Method.Post);
            request.AddParameter("variant", variant);
            return baseClient.ExecuteRequest(request);
        }

        public static RestResponse GetListOfTests(string projectId)
        {
            RestRequest request = new RestRequest("test/get/json", Method.Post);
            request.AddParameter("projectId", projectId);
            return baseClient.ExecuteRequest(request);
        }

        public static RestResponse CreateTest(string SID, string projectName, string testname, string methodName, string env)
        {
            return baseClient.ExecuteRequest($"test/put?SID={SID}&projectName={projectName}&testName={testname}&methodName={methodName}&env={env}", Method.Post);
        }

        public static RestResponse AttachLogFile(string testId, string log)
        {
            RestRequest request = new RestRequest("test/put/log", Method.Post);
            request.AddParameter("testId", testId);
            request.AddParameter("content", log);
            return baseClient.ExecuteRequest(request);
        }

        public static RestResponse AttachScreenshot(string testId, string content, string contentType)
        {
            RestRequest request = new RestRequest("test/put/attachment", Method.Post);
            request.AddParameter("testId", testId);
            request.AddParameter("content", content);
            request.AddParameter("contentType", contentType);
            return baseClient.ExecuteRequest(request);
        }
    }
}
