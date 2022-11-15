using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Elements;

public class BaseElement : IWebElement, IWrapsElement
{
    protected By locator;

    public BaseElement(By locator)
    {
        this.locator = locator;
    }

    public string TagName => this.FindElement(locator).TagName;

    public string Text
    { 
        get
        {
            waitForVisible();
            return this.FindElement(locator).Text;
        } 
    }

    public bool Enabled => this.FindElement(locator).Enabled;

    public bool Selected => this.FindElement(locator).Selected;
    public Point Location => this.FindElement(locator).Location;

    public Size Size => this.FindElement(locator).Size;

    public bool Displayed => this.FindElement(locator).Displayed;

    public IWebElement WrappedElement => this.FindElement(locator);

    public void Clear()
    {
        waitForVisible();
        this.FindElement(locator).Clear();
    }

    public void SendKeys(string text)
    {
        waitForVisible();
        this.FindElement(locator).SendKeys(text);
    }

    public void Submit()
    {
        waitForVisible();
        this.FindElement(locator).Submit();
    }

    public void Click()
    {
        waitForVisible();
        waitForEnabled();
        this.FindElement(locator).Click();
    }

    public string GetAttribute(string attributeName)
    {
        return this.FindElement(locator).GetAttribute(attributeName);
    }

    public string GetDomAttribute(string attributeName)
    {
        return this.FindElement(locator).GetDomAttribute(attributeName);
    }

    public string GetDomProperty(string propertyName)
    {
        return this.FindElement(locator).GetDomProperty(propertyName);
    }

    public string GetCssValue(string propertyName)
    {
        return this.FindElement(locator).GetCssValue(propertyName);
    }

    public ISearchContext GetShadowRoot()
    {
        return this.FindElement(locator).GetShadowRoot();
    }

    public IWebElement FindElement(By by)
    {
       return Browser.Driver.GetDriver().FindElement(by);
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        return Browser.Driver.GetDriver().FindElements(by);
    }

    public IWebElement GetWebElement()
    {
        return this.FindElement(locator);
    }

    public void ClickUsingJs()
    {
        waitForEnabled();
        Browser.JsExecutor.GetJsExecutor().ExecuteScript("arguments[0].click();", this.FindElement(locator));
    }

    public ReadOnlyCollection<IWebElement> GetWebElements()
    {
        return this.FindElements(locator);
    }

    public void waitForEnabled()
    {
        var wait = new WebDriverWait(Browser.Driver.GetDriver(), new TimeSpan(0, 0, 30));
        var element = wait.Until(condition => 
        {
            try {
                var elementToBeEnabled = this.FindElement(locator);
                return elementToBeEnabled.Enabled;

            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (ElementNotInteractableException)
            {
                return false;
            }
        });
    }

    public void waitForVisible()
    {
        var wait = new WebDriverWait(Browser.Driver.GetDriver(), new TimeSpan(0, 0, 30));
        var element = wait.Until(condition => 
        {
            try {
                var elementToBeVisible = this.FindElement(locator);
                return elementToBeVisible.Displayed;

            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        });
    }

    public void waitForNonVisible(TimeSpan waitingTime)
    {
        var wait = new WebDriverWait(Browser.Driver.GetDriver(), waitingTime);
        var element = wait.Until(condition => 
        {
            try {
                var elementToBeVisible = this.FindElement(locator);
                return !elementToBeVisible.Displayed;

            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        });
    }
}