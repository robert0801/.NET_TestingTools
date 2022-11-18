using Core;
using OpenQA.Selenium;

namespace Business.ApplicationInterface;

public class AboutPage : BasePage
{
    public BaseElement DownloadBtn { get; set; } = new BaseElement(By.XPath("//*[normalize-space(text())='Download']"));
}