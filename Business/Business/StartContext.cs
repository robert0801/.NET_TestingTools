using Business.ApplicationInterface;

namespace Business.Business;

public class StartContext : BaseContext<StartPage>
{
    public void ClickToCareerButtonInTopBar()
    {
       page.CareerTopBtn.Click();
    }

    public void ClickAboutButtonInTopBar()
    {
       page.AboutTopBtn.Click();
    }

    public void ClickInsightsButtonInTopBar()
    {
       page.InsightsTopBtn.Click();
    }

    public void ClickSearchGlassBtn()
    {
        page.SearchGlassBtn.Click();
    }

    public void SearchByValue(string value)
    {
        page.SearchLine.SendKeys(value);
        page.SearchBtn.Click();
    }

    public void AcceptCookies()
    {
        page.AcceptCookiesBtn.ClickUsingJs();
    }
}
