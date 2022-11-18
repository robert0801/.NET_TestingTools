using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Business.ApplicationInterface;

public abstract class BasePage
{
    public BaseElement Preloader { get; set; } = new BaseElement(By.XPath("//div[@class='preloader' and contains(@style, 'block')]"));
}