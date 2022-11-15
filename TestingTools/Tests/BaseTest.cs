using OpenQA.Selenium;
using PageObjects;

namespace Tests;

public class BaseTest
{
    private readonly string baseUrl = "https://www.epam.com/";
    private StartPage startPage = new StartPage();  

    [SetUp]
    public void Setup()
    {
        setUpDirForSavingFiles();
        Browser.Driver.GetDriver();
        Browser.Action.GetActions();
        Browser.JsExecutor.GetJsExecutor();
        Browser.Driver.GetDriver().Url = baseUrl;
        startPage.AcceptCookies();
    }

    [TearDown]
    public void TearDown()
    {
        Browser.Driver.GetDriver().Quit();
        Browser.Driver.WebDriver = null;
        Browser.Action.Actions = null;
        Browser.JsExecutor.Executor = null;
    }

    private void setUpDirForSavingFiles()
    {
        if (!Directory.Exists(Browser.Driver.FolderForDownloadingFiles))
        {
            Directory.CreateDirectory(Browser.Driver.FolderForDownloadingFiles);
        }
        else
        {
            var allFiles = Directory.GetFiles(Browser.Driver.FolderForDownloadingFiles);
            foreach (var file in allFiles)
            {
                File.Delete(file);
            }
        }
    }
}