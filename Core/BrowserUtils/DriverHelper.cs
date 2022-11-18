using Core.Enums;
using log4net;
using OpenQA.Selenium;

namespace Core.BrowserUtils;

public class DriverHelper
{
    private static IWebDriver? driver;
    private static BrowserType browserType;
    private static ILog Log
    {
        get { return LogManager.GetLogger("DriverHelper"); }
    }

    private DriverHelper() {}

    public static IWebDriver GetDriver()
    {
        if (null == driver)
        {
            Log.Info("Driver is NULL. Creating a new instance for DriverHelper...");
            InitParameters();
        }
        if (null != driver) return driver;
        else 
        {
            Log.Error("Exception during WebDriver initialization.");
            throw new Exception("Exception during WebDriver initialization.");
        }
    }

    public static void Quit()
    {
        Log.Info("Destroying currect WebDriver instance...");
        driver?.Quit();
        driver = null;
    }

    private static void InitParameters()
    {
        Enum.TryParse(ConfigurationReader.Browser.ToUpper(), out browserType);
        driver = DriverFactory.GetWebDriver(browserType);
    }
}