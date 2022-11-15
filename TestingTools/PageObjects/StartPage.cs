using Elements;
using OpenQA.Selenium;

namespace PageObjects;

public class StartPage : BasePage
{
    private readonly BaseElement acceptCookiesBtn = new BaseElement(By.Id("onetrust-accept-btn-handler"));
    private readonly BaseElement careerTopBtn = new BaseElement(By.XPath("//a[@href='/careers']"));
    private readonly BaseElement aboutTopBtn = new BaseElement(By.XPath("//*[@class='top-navigation__item-text']/a[@href='/about']"));
    private readonly BaseElement insightsTopBtn = new BaseElement(By.XPath("//*[@class='top-navigation__item-text']/a[@href='/insights']"));
    private readonly BaseElement searchGlassBtn = new BaseElement(By.XPath("//*[text()='Search']/parent::button"));
    private readonly BaseElement searchLine = new BaseElement(By.Name("q"));
    private readonly BaseElement searchBtn = new BaseElement(By.ClassName("header-search__submit"));

    public void ClickToCareerButtonInTopBar()
    {
       careerTopBtn.Click();
    }

    public void ClickAboutButtonInTopBar()
    {
       aboutTopBtn.Click();
    }

    public void ClickInsightsButtonInTopBar()
    {
       insightsTopBtn.Click();
    }

    public void ClickSearchGlassBtn()
    {
        searchGlassBtn.Click();
    }

    public void SearchByValue(string value)
    {
        searchLine.SendKeys(value);
        searchBtn.Click();
    }

    public void AcceptCookies()
    {
        acceptCookiesBtn.ClickUsingJs();
    }

}
