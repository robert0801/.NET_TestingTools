using static Browser.Action;
using Elements;
using OpenQA.Selenium;

namespace PageObjects;

public class SearchResultPage : BasePage
{
    private readonly BaseElement searchResultsCounter = new BaseElement(By.XPath("//h2[@class='search-results__counter']"));
    private readonly BaseElement strongWordsInDescription = new BaseElement(By.XPath("//*[@class='search-results__description']/strong"));
    private readonly BaseElement viewMoreBtn = new BaseElement(By.XPath("//*[text()='View More']"));
    private readonly BaseElement footer = new BaseElement(By.ClassName("search-results__footer"));
    public List<string> GetAllStrongWordsFromSearchResult()
    {
        var listWithText = new List<string>();
        ScrollToTheLastOptionInSearchResult();
        var webElements = strongWordsInDescription.GetWebElements();
        foreach (var item in webElements)
        {
            listWithText.Add(item.Text);
        }
        return listWithText;
    }
    private void ScrollToTheLastOptionInSearchResult()
    {
        searchResultsCounter.waitForVisible();
        while(true)
        {
            try {
                GetActions().MoveToElement(footer).Perform();
                viewMoreBtn.Click();
                base.WaitTillPreloaderNotShown(new TimeSpan(0, 0 ,10));
            }
            catch (Exception)
            {
                Console.WriteLine("There is not exist additional 'More and view' button on the page.");
                break;
            }
        }
    }
}