using Business.ApplicationInterface;
using Core.BrowserUtils;

namespace Business.Business;

public class SearchResultContext : BaseContext<SearchResultPage>
{
    public List<string> GetAllStrongWordsFromSearchResult()
    {
        Log.Info("Getting all bolds word in the search result.");
        var listWithText = new List<string>();
        ScrollToTheLastOptionInSearchResult();
        var webElements = page.StrongWordsInDescription.GetWebElements();
        foreach (var item in webElements)
        {
            listWithText.Add(item.Text);
        }
        return listWithText;
    }

    private void ScrollToTheLastOptionInSearchResult()
    {
        Log.Info("Scroll to the last possition on the search result page.");
        page.SearchResultsCounter.WaitForVisible(15);
        while(true)
        {
            try {
                ActionHelper.GetActions().MoveToElement(page.Footer).Perform();
                page.ViewMoreBtn.Click();
                base.WaitTillPreloaderNotShown(10);
            }
            catch (Exception)
            {
                Log.Info("There is not exist additional 'More and view' button on the page.");
                break;
            }
        }
    }
}