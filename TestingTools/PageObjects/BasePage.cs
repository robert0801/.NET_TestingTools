using Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjects;

public abstract class BasePage
{
    private readonly BaseElement preloader = new BaseElement(By.XPath("//div[@class='preloader' and contains(@style, 'block')]"));
    public bool IsFileExist(string fullPath)
    {
        bool isExist = false;
        var wait = new WebDriverWait(Browser.Driver.GetDriver(), new TimeSpan(0, 0, 30));
        wait.Until<bool>(file => isExist = File.Exists(fullPath));
        return File.Exists(fullPath);
    }

    public void WaitTillPreloaderNotShown(TimeSpan waitingTime)
    {
        preloader.waitForNonVisible(waitingTime);
    }
}