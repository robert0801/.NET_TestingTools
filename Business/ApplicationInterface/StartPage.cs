using Core;
using OpenQA.Selenium;

namespace Business.ApplicationInterface;

public class StartPage : BasePage
{
    public BaseElement AcceptCookiesBtn {get; set; } = new BaseElement(By.Id("onetrust-accept-btn-handler"));
    public BaseElement CareerTopBtn {get; set; } = new BaseElement(By.XPath("//a[@href='/careers']"));
    public BaseElement AboutTopBtn {get; set; } = new BaseElement(By.XPath("//*[@class='top-navigation__item-text']/a[@href='/about']"));
    public BaseElement InsightsTopBtn {get; set; } = new BaseElement(By.XPath("//*[@class='top-navigation__item-text']/a[@href='/insights']"));
    public BaseElement SearchGlassBtn {get; set; } = new BaseElement(By.XPath("//*[text()='Search']/parent::button"));
    public BaseElement SearchLine {get; set; } = new BaseElement(By.Name("q"));
    public BaseElement SearchBtn {get; set; } = new BaseElement(By.ClassName("header-search__submit"));
}
