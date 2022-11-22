using Core.BrowserUtils;
using Business.ApplicationInterface;

namespace Business.Business;

public class AboutContext : BaseContext<AboutPage>
{
    public void ScrollToFactsheetSection()
    {
        Log.Info("Scrolling to the factsheet section.");
        JsExecutorHelper.GetJsExecutor().ExecuteScript("arguments[0].scrollIntoView(true); window.scrollBy(0, -60);", page.DownloadBtn);
    }

    public void ClickDownloadBtn()
    {
        page.DownloadBtn.ClickUsingJs();
    }
}