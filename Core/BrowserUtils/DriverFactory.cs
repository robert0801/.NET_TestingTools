using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Core.Enums;
using log4net;

namespace Core.BrowserUtils;

public class DriverFactory
{
    public const string FolderForDownloadingFiles = "/Downloads/";

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
                options.AddUserProfilePreference("download.default_directory", @$"{Directory.GetCurrentDirectory() + FolderForDownloadingFiles}");
                options.AddUserProfilePreference("download.prompt_for_download", false);
                options.AddUserProfilePreference("directory_upgrade", true);
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
                options.AddArgument("--headless");
                options.AddArgument("--window-size=1920,1080");
                driver = new ChromeDriver(options);
                // driver.Manage().Window.Maximize();
                break;
            }
            case BrowserType.FIREFOX:
            {
                var options = new FirefoxOptions();
                options.SetPreference("browser.download.dir", @$"{Directory.GetCurrentDirectory() + FolderForDownloadingFiles}");
                options.SetPreference("browser.download.folderList", 2);
                options.AddArgument("--headless");
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