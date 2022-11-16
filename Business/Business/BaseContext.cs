using Business.ApplicationInterface;
using Core.BrowserUtils;
using Core;
using log4net;
using OpenQA.Selenium.Support.UI;

namespace Business.Business;

public abstract class BaseContext<T> where T : BasePage, new()
{
    protected T page;

    public BaseContext()
    {
        page = new T();
    }

    public bool IsFileExist(string fullPath)
    {
        int waitingTime = 0;
        bool isExist = false;
        int.TryParse(AppConfigReader.Timeout, out waitingTime);

        var wait = new WebDriverWait(DriverHelper.GetDriver(), TimeSpan.FromSeconds(waitingTime));
        wait.Until<bool>(file => isExist = File.Exists(fullPath));
        return File.Exists(fullPath);
    }

    public void WaitTillPreloaderNotShown(int waitingTime)
    {
        page.Preloader.WaitForNonVisible(waitingTime);
    }

    protected ILog Log
    {
        get { return LogManager.GetLogger(this.GetType()); }
    }
}