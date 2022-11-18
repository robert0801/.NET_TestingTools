using Core;
using OpenQA.Selenium; 

namespace Business.ApplicationInterface;

public class ArticlePage : BasePage
{
    public BaseElement ArticleTitle { get; set; } = new BaseElement(By.XPath("//*[@class='top-container']//h1"));
}