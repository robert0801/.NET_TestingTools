using System.Collections.ObjectModel;
using System.Drawing;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Core.BrowserUtils;

namespace Core;

public class BaseElement : IWebElement, IWrapsElement
{
    private By locator;
    private int waitingTime;
    private static ILog Log
    {
        get { return LogManager.GetLogger("BaseElement"); }
    }

    public BaseElement(By locator)
    {
        this.locator = locator;
        int.TryParse(AppConfigReader.Timeout, out waitingTime);
    }

    public string TagName
    {
        get
        {
            WaitForVisible();
            Log.Info($"Getting property TagName for element with locator = {locator.Criteria}");
            return this.FindElement(locator).TagName;
        } 
    }

    public string Text
    { 
        get
        {
            WaitForVisible();
            Log.Info($"Getting Text from element with locator = {locator.Criteria}");
            return this.FindElement(locator).Text;
        } 
    }

    public bool Enabled
    { 
        get
        {
            WaitForVisible();
            Log.Info($"Getting property Enabled for element with locator = {locator.Criteria}");
            return this.FindElement(locator).Enabled;
        }
    }

    public bool Selected
    {
        get
        {
            WaitForVisible();
            Log.Info($"Getting property Selected for element with locator = {locator.Criteria}");
            return this.FindElement(locator).Selected;
        }
    }
    public Point Location
    {
        get
        {
            WaitForVisible();
            Log.Info($"Getting Location for element with locator = {locator.Criteria}");
            return this.FindElement(locator).Location;
        }
    }

    public Size Size
    {
        get
        {
            WaitForVisible();
            Log.Info($"Getting Size for element with locator = {locator.Criteria}");
            return this.FindElement(locator).Size;
        }
    }

    public bool Displayed
    {
        get
        {
            WaitForVisible();
            Log.Info($"Getting property Displayed for element with locator = {locator.Criteria}");
            return this.FindElement(locator).Displayed;
        }
    }

    public IWebElement WrappedElement
    {
        get
        {
            Log.Info($"Finding element with locator = {locator.Criteria}");
            WaitForVisible();
            return this.FindElement(locator);
        }
    }

    public void Clear()
    {
        Log.Info($"Clearing filed of element with locator = {locator.Criteria}");
        WaitForVisible();
        this.FindElement(locator).Clear();
    }

    public void SendKeys(string text)
    {
        Log.Info($"Sending text = {text} to the element with locator = {locator.Criteria}");
        WaitForVisible();
        this.FindElement(locator).SendKeys(text);
    }

    public void Submit()
    {
        Log.Info($"Submiting element with locator = {locator.Criteria}");
        WaitForVisible();
        this.FindElement(locator).Submit();
    }

    public void Click()
    {
        WaitForVisible();
        WaitForEnabled();
        Log.Info($"Click to the element with locator {locator.Criteria}");
        this.FindElement(locator).Click();
    }

    public string GetAttribute(string attributeName)
    {
        WaitForVisible();
        Log.Info($"Getting attribute {attributeName} for element with locator = {locator.Criteria}");
        return this.FindElement(locator).GetAttribute(attributeName);
    }

    public string GetDomAttribute(string attributeName)
    {
        Log.Info($"Getting domAttribute {attributeName} for element with locator = {locator.Criteria}");
        return this.FindElement(locator).GetDomAttribute(attributeName);
    }

    public string GetDomProperty(string propertyName)
    {
        Log.Info($"Getting domProperty {propertyName} for element with locator = {locator.Criteria}");
        return this.FindElement(locator).GetDomProperty(propertyName);
    }

    public string GetCssValue(string propertyName)
    {
        Log.Info($"Getting cssValue {propertyName} for element with locator = {locator.Criteria}");
        return this.FindElement(locator).GetCssValue(propertyName);
    }

    public ISearchContext GetShadowRoot()
    {
        Log.Info($"Getting ShadowRoot for element with locator = {locator.Criteria}");
        return this.FindElement(locator).GetShadowRoot();
    }

    public IWebElement FindElement(By by)
    {
        Log.Info($"Finding element with locator = {locator.Criteria}");
        return DriverHelper.GetDriver().FindElement(by);
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        Log.Info($"Finding elements with locator = {locator.Criteria}");
        return DriverHelper.GetDriver().FindElements(by);
    }

    public IWebElement GetWebElement()
    {
        return this.FindElement(locator);
    }

    public void ClickUsingJs()
    {
        Log.Info($"Clicking via JsExecutor by element with locator = {locator.Criteria}");
        WaitForEnabled();
        JsExecutorHelper.GetJsExecutor().ExecuteScript("arguments[0].click();", this.FindElement(locator));
    }

    public ReadOnlyCollection<IWebElement> GetWebElements()
    {
        return this.FindElements(locator);
    }

    public void WaitForEnabled()
    {
        WaitForEnabled(waitingTime);
    }

    public void WaitForEnabled(int waitingTime)
    {
        var wait = new WebDriverWait(DriverHelper.GetDriver(), TimeSpan.FromSeconds(waitingTime));
        var element = wait.Until(condition => 
        {
            try {
                var elementToBeEnabled = this.FindElement(locator);
                return elementToBeEnabled.Enabled;

            }
            catch (StaleElementReferenceException)
            {
                Log.Debug($"Element with locator {locator.Criteria} still Not Enabled. Continue waiting...");
                return false;
            }
            catch (NoSuchElementException)
            {
                Log.Debug($"Element with locator {locator.Criteria} still Not Enabled. Continue waiting...");
                return false;
            }
            catch (ElementNotInteractableException)
            {
                Log.Debug($"Element with locator {locator.Criteria} still Not Enabled. Continue waiting...");
                return false;
            }
        });
    }

    public void WaitForVisible()
    {
        WaitForVisible(waitingTime);
    }

    public void WaitForVisible(int waitingTime)
    {
        var wait = new WebDriverWait(DriverHelper.GetDriver(), TimeSpan.FromSeconds(waitingTime));
        var element = wait.Until(condition => 
        {
            try {
                var elementToBeVisible = this.FindElement(locator);
                return elementToBeVisible.Displayed;

            }
            catch (StaleElementReferenceException)
            {
                Log.Debug($"Element with locator {locator.Criteria} still Not Visible. Continue waiting...");
                return false;
            }
            catch (NoSuchElementException)
            {
                Log.Debug($"Element with locator {locator.Criteria} still Not Visible. Continue waiting...");
                return false;
            }
        });
    }

    public void WaitForNonVisible()
    {
        WaitForNonVisible(waitingTime);
    }

    public void WaitForNonVisible(int waitingTime)
    {
        var wait = new WebDriverWait(DriverHelper.GetDriver(), TimeSpan.FromSeconds(waitingTime));
        var element = wait.Until(condition => 
        {
            try {
                var elementToBeVisible = this.FindElement(locator);
                return !elementToBeVisible.Displayed;

            }
            catch (StaleElementReferenceException)
            {
                Log.Debug($"Element with locator {locator.Criteria} still Visible. Continue waiting...");
                return true;
            }
            catch (NoSuchElementException)
            {
                Log.Debug($"Element with locator {locator.Criteria} still Visible. Continue waiting...");
                return true;
            }
        });
    }
}