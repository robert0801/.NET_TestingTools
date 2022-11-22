using Core.BrowserUtils;
using Business.ApplicationInterface;

namespace Business.Business;

public class JobListingsContext : BaseContext<JobListingsPage>
{
    public void ClickToTheLastViewAndApplyBtn()
    {
        Log.Info("Click to the last job possition on the JobListinings page.");
        ScrollToTheLastOptionInSearchResult();
        var lastWebElement = page.ViewAndApplyBtn.GetWebElements().Last();
        lastWebElement.Click();
    }

    private void ScrollToTheLastOptionInSearchResult()
    {
        Log.Info("Scroll to the last possition on the search result page.");
        page.SearchResultHeading.WaitForVisible(30);
        while(true)
        {   
            try {
                JsExecutorHelper.GetJsExecutor().ExecuteScript("arguments[0].scrollIntoView(true);", page.FooterTitle);
                page.ViewMoreBtn.Click();
                base.WaitTillPreloaderNotShown(10);
            }
            catch (Exception)
            {              
                Log.Info("There is not exist additional 'More and view' button on the page.");
                JsExecutorHelper.GetJsExecutor().ExecuteScript("window.scrollBy(0, -800);");
                break;
            }
        }
    }
}