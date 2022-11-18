using Core;
using OpenQA.Selenium;

namespace Business.ApplicationInterface;

public class InsightsPage : BasePage
{
    public BaseElement Slider {get; set; }= new BaseElement(By.ClassName("slider"));
    public BaseElement FullSliderTextInfo {get; set; }= new BaseElement(By.XPath("//*[@class='owl-item active center']/div"));
    public BaseElement LearnMoreBtn { get; set; }= new BaseElement(By.XPath("//*[contains(@class, 'active center')]//*[normalize-space(text()) = 'Learn more' and contains(@class, 'desktop')]"));
    public string ArticleTitle {get; set; } = "(//div[@class='title']/h2)[{0}]";
}