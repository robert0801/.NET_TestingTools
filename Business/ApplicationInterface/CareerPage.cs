using OpenQA.Selenium;
using Core;

namespace Business.ApplicationInterface;

public class CareerPage : BasePage
{
    public BaseElement KeywordField { get; set; } = new BaseElement(By.XPath("//*[@placeholder='Keyword']"));
    public BaseElement LocationDropdown { get; set; } = new BaseElement(By.ClassName("select2-selection__arrow"));
    public BaseElement LocationSelector { get; set; } = new BaseElement(By.XPath("//*[@class='select2-results']/ul"));
    public BaseElement RemoteCheckbox {get; set; } = new BaseElement(By.XPath("//label[contains(text(), 'Remote')]"));
    public BaseElement FindBtn { get; set; } = new BaseElement(By.CssSelector("#jobSearchFilterForm > button"));
    public string OptionInLocationDropdown { get; set; } = "//li[@title='{0}']";
}