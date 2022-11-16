using Core;
using OpenQA.Selenium;

namespace Business.ApplicationInterface;

public class JobDescriptionPage : BasePage
{
    public BaseElement PageTitle {get; set; } = new BaseElement(By.ClassName("form-component__description"));
}