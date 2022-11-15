using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Browser;

public sealed class Driver
{   
    private readonly String baseUrl = "https://www.epam.com/";
    public static string FolderForDownloadingFiles { get; set; } = "/Users/Robert_Haidul/Downloads/TempDir/";
    public static IWebDriver WebDriver { private get; set; }

    private Driver() {}

    public static IWebDriver GetDriver()
    {
        if (null == WebDriver)
        {
            InitParameters();
        }
        return WebDriver;
    }

    private static void InitParameters()
    {
        var options = new ChromeOptions();
        options.AddUserProfilePreference("download.default_directory", @$"{FolderForDownloadingFiles}");
        WebDriver = new ChromeDriver(options);
        WebDriver.Manage().Window.Maximize();
    }
}