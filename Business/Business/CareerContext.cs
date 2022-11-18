using Core.BrowserUtils;
using Business.ApplicationInterface;
using OpenQA.Selenium;

namespace Business.Business;

public class CareerContext : BaseContext<CareerPage>
{
    public void InsertSpecificJobToKeywordField(string programmingLang)
    {
        page.KeywordField.SendKeys(programmingLang);
    }

    public void ChooseLocationFromDropdown(string location)
    {
        Log.Info($"Choosing {location} for location dropdown.");
        page.LocationDropdown.Click();
        var exepectedLocation = DriverHelper.GetDriver().FindElement(By.XPath(string.Format(page.OptionInLocationDropdown, location)));
        ActionHelper.GetActions().MoveToElement(exepectedLocation).Perform();
        exepectedLocation.Click();
    }

    public void ChooseRemoteCheckbox()
    {
        page.RemoteCheckbox.Click();
    }

    public void ClickFindBtn()
    {
        page.FindBtn.Click();
    }
}