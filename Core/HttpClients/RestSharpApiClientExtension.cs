using log4net;
using RestSharp;
using System.Threading;

namespace Core.HttpClients
{
    public static class RestSharpApiClientExtension
    {
        private static ILog Log
        {
            get => LogManager.GetLogger("RestSharpApiClientExtension" + Thread.CurrentThread.ManagedThreadId);
        }

        public static RestResponse GetWithLogs(this RestClient client, RestRequest request)
        {
            Log.Info("GET request by URI: " + request.Resource);
            var response = client.Get(request);
            LoggingResponseHeadersAndBody(response);

            return client.Get(request);
        }

        public static RestResponse PostWithLogs(this RestClient client, RestRequest request)
        {
            Log.Info("Post request by URI: " + request.Resource);
            var response = client.Get(request);
            LoggingResponseHeadersAndBody(response);

            return client.Post(request);
        }

        private static void LoggingResponseHeadersAndBody(RestResponse response)
        {
            Log.Info("Response headers");
            response.Headers.ToList().ForEach(header => Log.Info(header.ToString()));

            Log.Info("Response body" + response.Content);
        }
    }
}