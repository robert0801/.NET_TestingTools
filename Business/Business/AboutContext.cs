using Core.BrowserUtils;
using Business.ApplicationInterface;

namespace Business.Business;

public class AboutContext : BaseContext<AboutPage>
{
    public void ScrollToFactsheetSection()
    {
        Log.Info("Scrolling to the factsheet section.");
        ActionHelper.GetActions().MoveToElement(page.DownloadBtn).Perform();
    }

    public void ClickDownloadBtn()
    {
        page.DownloadBtn.Click();
    }
}