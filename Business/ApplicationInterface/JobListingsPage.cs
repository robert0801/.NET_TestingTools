using Core;
using OpenQA.Selenium;

namespace Business.ApplicationInterface;

public class JobListingsPage : BasePage
{
    public BaseElement ViewAndApplyBtn { get; set; } = new BaseElement(By.XPath("//*[text()='View and apply']"));
    public BaseElement ViewMoreBtn { get; set; } = new BaseElement(By.XPath("//*[text()='View More']"));
    public BaseElement SearchResultHeading { get; set; } = new BaseElement(By.ClassName("search-result__heading"));
    public BaseElement FooterTitle { get; set; } = new BaseElement(By.XPath("//div[@class='colctrl__holder']/div[@class='title']"));
}