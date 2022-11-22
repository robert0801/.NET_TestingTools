using log4net;
using log4net.Config;
using RestSharp;
using Core.HttpClients;
using Business.Data;

namespace Tests.ApiTests
{
    public abstract class BaseApiTest
    {
        protected static RestClient client;
        
        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            XmlConfigurator.Configure(new FileInfo("../../../Log.config"));
        }

        [SetUp]
        public void SetUp()
        {
            client = RestShartHttpClient.GetRestClient(Data.BaseApiUrl);
        }

        protected ILog Log
        {
            get => LogManager.GetLogger(this.GetType());
        }
    }
}