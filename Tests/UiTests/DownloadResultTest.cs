using Business.Business;
using Core.BrowserUtils;

namespace Tests.UiTests
{
    [TestFixture]
    public class DownloadResultTest : BaseTest
    {
        private StartContext startContext = new StartContext();
        private AboutContext aboutContext = new AboutContext();

        [Test]
        public void CheckThatFileHasCorrectName()
        {
            string downloadFolder = DriverFactory.FolderForDownloadingFiles;
            string expectedFileName = "EPAM_Systems_Company_Overview.pdf";

            startContext.ClickAboutButtonInTopBar();
            aboutContext.ScrollToFactsheetSection();
            aboutContext.ClickDownloadBtn();

            Assert.True(aboutContext.IsFileExist(downloadFolder + expectedFileName), "Expected file doesn't exist in expected folder or has incorrect name");
        }
    }
}