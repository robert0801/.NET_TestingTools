using Elements;
using OpenQA.Selenium;

namespace PageObjects;

public class InsightsPage : BasePage
{
    private readonly BaseElement slider = new BaseElement(By.ClassName("slider"));
    private readonly BaseElement fullSliderTextInfo = new BaseElement(By.XPath("//*[@class='owl-item active center']/div"));
    private readonly BaseElement learnMoreBtn = new BaseElement(By.XPath("//*[contains(@class, 'active center')]//*[normalize-space(text()) = 'Learn more' and contains(@class, 'desktop')]"));
    private string articleTitle = "(//div[@class='title']/h2)[{0}]";
    public void DragAndDropCarousel(int offsetX, int offsetY, int countOfScrolls)
    {
        for (var i = 0; i < countOfScrolls; i++)
        {
            Browser.Action.GetActions()
                .ClickAndHold(slider)
                .DragAndDropToOffset(slider, offsetX, offsetY)
                .Release(slider)
                .Build()
                .Perform();
        }
    }

    public string GetCurrentArticleTitle()
    { 
        string title = fullSliderTextInfo.GetDomProperty("textContent");
        return title.Trim().Split("\n")[0];
    }

    public void ClickLearnMoreBtnOnSlide()
    {
        learnMoreBtn.Click();
    }

}