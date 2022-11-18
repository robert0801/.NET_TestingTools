using OpenQA.Selenium.Support.Extensions;
using Core.BrowserUtils;
using OpenQA.Selenium;

namespace Core;

public class ScreenshotMaker
{
    private static string NewScreenshotName
    {
        get { return "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff") + "." + ScreenshotImageFormat; }
    }
    private static ScreenshotImageFormat ScreenshotImageFormat
    {
        get { return ScreenshotImageFormat.Jpeg; }
    }
    public static string TakeBrowserScreenshot()
    {
        var screenshotPath = Path.Combine(Environment.CurrentDirectory, "Display" + NewScreenshotName);
        var image = DriverHelper.GetDriver().TakeScreenshot();
        image.SaveAsFile(screenshotPath, ScreenshotImageFormat);
        return screenshotPath;
    }
}