using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Core.Enums;
using log4net;

namespace Core.BrowserUtils;

public class DriverFactory
{
    private const string ChromeDefaultDirOption = "download.default_directory";
    private const string FirefoxDefaultDirOption = "browser.download.dir";
    public const string FolderForDownloadingFiles = "/Users/Robert_Haidul/Downloads/TempDir/";

    private static ILog Log
    {
        get => LogManager.GetLogger("DriverFactory");
    }
    private DriverFactory() {}

    public static IWebDriver GetWebDriver(BrowserType browserType)
    {
        IWebDriver? driver = null;
        switch (browserType)
        {
            case BrowserType.CHROME:
            {
                var options = new ChromeOptions();
                options.AddUserProfilePreference(ChromeDefaultDirOption, @$"{FolderForDownloadingFiles}");
                driver = new ChromeDriver(options);
                driver.Manage().Window.Maximize();
                break;
            }
            case BrowserType.FIREFOX:
            {
                var options = new FirefoxOptions();
                options.SetPreference(FirefoxDefaultDirOption, FolderForDownloadingFiles);
                driver = new FirefoxDriver(options);
                driver.Manage().Window.Maximize();
                break;
            }
            default:
            {
                Log.Error($"Passed invalid browser type - {browserType.ToString()}");
                throw new InvalidDataException($"Passed invalid browser type - {browserType.ToString()}");
            }
        }
        return driver;
    }
}