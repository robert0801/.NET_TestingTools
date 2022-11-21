using Business.Data;
using Business.Business;
using Core.BrowserUtils;
using log4net.Config;
using log4net;
using NUnit.Framework.Interfaces;
using Core;

namespace Tests.UiTests
{
    public abstract class BaseTest
    {
        private readonly string baseUrl = Data.StartUrl;
        private StartContext startContext = new StartContext();  

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            XmlConfigurator.Configure(new FileInfo("../../../Log.config"));
        }

        [SetUp]
        public void Setup()
        {
            Log.Info("Opening browser...");
            DriverHelper.GetDriver();
            ActionHelper.GetActions();
            JsExecutorHelper.GetJsExecutor();
            Log.Info("Browser successfully opened.");

            setUpDirForSavingFiles();
            DriverHelper.GetDriver().Url = baseUrl;
            startContext.AcceptCookies();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ScreenshotMaker.TakeBrowserScreenshot();
            }

            DriverHelper.Quit();
            ActionHelper.DestroyActionHelper();
            JsExecutorHelper.DestroyJsExecutorHelper();
        }

        private void setUpDirForSavingFiles()
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + DriverFactory.FolderForDownloadingFiles))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + DriverFactory.FolderForDownloadingFiles);
            }
            else
            {
                var allFiles = Directory.GetFiles(Directory.GetCurrentDirectory() + DriverFactory.FolderForDownloadingFiles);
                foreach (var file in allFiles)
                {
                    File.Delete(file);
                }
            }
        }

        protected ILog Log
        {
            get => LogManager.GetLogger(this.GetType());
        }
    }
}