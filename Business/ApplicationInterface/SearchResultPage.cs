using Core;
using OpenQA.Selenium;

namespace Business.ApplicationInterface;

public class SearchResultPage : BasePage
{
    public BaseElement SearchResultsCounter { get; set; } = new BaseElement(By.XPath("//h2[@class='search-results__counter']"));
    public BaseElement StrongWordsInDescription { get; set; } = new BaseElement(By.XPath("//*[@class='search-results__description']/strong"));
    public BaseElement ViewMoreBtn { get; set; } = new BaseElement(By.XPath("//*[text()='View More']"));
    public BaseElement Footer { get; set; } = new BaseElement(By.ClassName("search-results__footer"));
}