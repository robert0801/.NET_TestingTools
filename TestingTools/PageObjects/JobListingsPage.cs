using static Browser.Action;
using Elements;
using OpenQA.Selenium;

namespace PageObjects;

public class JobListingsPage : BasePage
{
    private readonly BaseElement viewAndApplyBtn = new BaseElement(By.XPath("//*[text()='View and apply']"));
    private readonly BaseElement viewMoreBtn = new BaseElement(By.XPath("//*[text()='View More']"));
    private readonly BaseElement searchResultHeading = new BaseElement(By.ClassName("search-result__heading"));
    private readonly BaseElement registerYourInterestBtn = new BaseElement(By.XPath("//*[contains(@class, 'desktop') and contains(text(), 'Register')]"));
    private readonly BaseElement footerTitle = new BaseElement(By.XPath("//div[@class='colctrl__holder']/div[@class='title']"));

    public void ClickToTheLastViewAndApplyBtn()
    {
        ScrollToTheLastOptionInSearchResult();
        var lastWebElement = viewAndApplyBtn.GetWebElements().Last();
        GetActions().MoveToElement(lastWebElement).Perform();
        lastWebElement.Click();
    }

    private void ScrollToTheLastOptionInSearchResult()
    {
        searchResultHeading.waitForVisible();
        while(true)
        {   
            try {
                GetActions().MoveToElement(footerTitle).Build().Perform();
                viewMoreBtn.Click();
                base.WaitTillPreloaderNotShown(new TimeSpan(0, 0, 10));
            }
            catch (Exception)
            {                
                Console.WriteLine("There is not exist additional 'More and view' button on the page.");
                break;
            }
        }
    }
}