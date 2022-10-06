using RestSharp;

namespace FinalTask.API
{
    public class Responses
    {
        private RestResponse restResponse = new RestResponse();

        public Responses(RestResponse response)
        {
            restResponse = response;
        }

        public RestResponse GetResponse()
        {
            return restResponse;
        }

        public System.Net.HttpStatusCode GetResponseStatusCode()
        {
            return GetResponse().StatusCode;
        }

        public string GetContentType()
        {
            return GetResponse().ContentType;
        }

        public string GetResponseContent()
        {
            return GetResponse().Content;
        }

    }
}
