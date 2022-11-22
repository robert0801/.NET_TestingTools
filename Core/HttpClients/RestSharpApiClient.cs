using log4net;
using RestSharp;
using RestSharp.Authenticators;

namespace Core.HttpClients
{
    public class RestShartHttpClient
    {
        private static RestClient? client;
        private static string? myToken;
        private RestShartHttpClient() {}
        private static ILog Log
        {
            get =>LogManager.GetLogger("RestShartHttpClient");
        }

        public static RestClient? GetRestClient(string baseUrl)
        {
            if (null == client)
            {
                InitializeHttpClient(baseUrl);
            }
            if (null != client) return client;
            else 
            {
                Log.Error("It is impossible to initialize RestClient.");
                throw new NullReferenceException();
            }
        }

        private static void InitializeHttpClient(string baseUrl)
        {
            client = new RestClient(baseUrl);
            client.Authenticator = new JwtAuthenticator(GetBearerToken());
            client.UseJson();
        }

        private static string GetBearerToken()
        {
            if (null == myToken)
            {
                myToken = new Random().Next(1000, 1_000_000).ToString();
            }
            return myToken;
        }

    }
}