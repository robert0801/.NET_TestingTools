using Elements;
using OpenQA.Selenium; 

namespace PageObjects;

public class ArticlePage : BasePage
{
    private readonly BaseElement articleTitle = new BaseElement(By.XPath("//*[@class='top-container']//h1"));

    public string GetArticleTitle()
    {
        return articleTitle.Text.Trim();
    }
}