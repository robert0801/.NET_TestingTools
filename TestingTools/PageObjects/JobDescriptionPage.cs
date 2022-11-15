using Elements;
using OpenQA.Selenium;

namespace PageObjects;

public class JobDescriptionPage : BasePage
{
    private readonly BaseElement pageTitle = new BaseElement(By.ClassName("form-component__description"));

    public string GetJobTitle()
    {
        return pageTitle.Text;
    }

}