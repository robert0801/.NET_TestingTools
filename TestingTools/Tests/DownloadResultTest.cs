using PageObjects;

namespace Tests;

[TestFixture]
public class DownloadResultTest : BaseTest
{
    private StartPage startPage = new StartPage();
    private AboutPage aboutPage = new AboutPage();

    [Test]
    public void checkThatFileHasCorrectName()
    {
        string downloadFolder = Browser.Driver.FolderForDownloadingFiles;
        string expectedFileName = "EPAM_Systems_Company_Overview.pdf";

        startPage.ClickAboutButtonInTopBar();
        aboutPage.ScrollToFactsheetSection();
        aboutPage.ClickDownloadBtn();

        Assert.True(aboutPage.IsFileExist(downloadFolder + expectedFileName), "Expected file doesn't exist in expected folder or has incorrect name");

    }
}