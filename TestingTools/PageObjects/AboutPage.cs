using static Browser.Action;
using Elements;
using OpenQA.Selenium;

namespace PageObjects;

public class AboutPage : BasePage
{
    private readonly BaseElement factsheetField = new BaseElement(By.CssSelector("h3 > span"));
    private readonly BaseElement downloadBtn = new BaseElement(By.XPath("//*[normalize-space(text())='Download']"));

    public void ScrollToFactsheetSection()
    {
        GetActions().MoveToElement(factsheetField).Perform();
    }

    public void ClickDownloadBtn()
    {
        downloadBtn.Click();
    }
}