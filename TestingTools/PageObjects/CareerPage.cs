using static Browser.Action;
using Elements;
using OpenQA.Selenium;

namespace PageObjects;

public class CareerPage : BasePage
{
    private readonly BaseElement keywordField = new BaseElement(By.XPath("//*[@placeholder='Keyword']"));
    private readonly BaseElement locationDropdown = new BaseElement(By.ClassName("select2-selection__arrow"));
    private readonly BaseElement locationSelector = new BaseElement(By.XPath("//*[@class='select2-results']/ul"));
    private readonly BaseElement remoteCheckbox = new BaseElement(By.XPath("//label[contains(text(), 'Remote')]"));
    private readonly BaseElement findBtn = new BaseElement(By.CssSelector("#jobSearchFilterForm > button"));
    private string optionInLocationDropdown = "//li[@title='{0}']";

    public void InsertSpecificJobToKeywordField(string programmingLang)
    {
        keywordField.SendKeys(programmingLang);
    }

    public void ChooseLocationFromDropdown(string location)
    {
        locationDropdown.Click();
        var exepectedLocation = Browser.Driver.GetDriver().FindElement(By.XPath(string.Format(optionInLocationDropdown, location)));
        GetActions().MoveToElement(exepectedLocation).Perform();
        exepectedLocation.Click();
    }

    public void ChooseRemoteCheckbox()
    {
         remoteCheckbox.Click();
    }

    public void ClickFindBtn()
    {
        findBtn.Click();
    }
}