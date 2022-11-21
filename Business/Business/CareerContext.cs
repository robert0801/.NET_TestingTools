using Core.BrowserUtils;
using Business.ApplicationInterface;
using OpenQA.Selenium;
using Core;

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
        BaseElement exepectedLocation = new BaseElement(By.XPath(string.Format(page.OptionInLocationDropdown, location)));
        JsExecutorHelper.GetJsExecutor().ExecuteScript("arguments[0].scrollIntoView(true);", exepectedLocation);
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