using Core.BrowserUtils;
using Business.ApplicationInterface;

namespace Business.Business;

public class InsightsContext : BaseContext<InsightsPage>
{
    public void DragAndDropCarousel(int offsetX, int offsetY, int countOfScrolls)
    {
        Log.Info($"Scrolling slider {countOfScrolls} time.");
        for (var i = 0; i < countOfScrolls; i++)
        {
            ActionHelper.GetActions()
                .ClickAndHold(page.Slider)
                .DragAndDropToOffset(page.Slider, offsetX, offsetY)
                .Release(page.Slider)
                .Build()
                .Perform();
        }
    }

    public string GetCurrentArticleTitle()
    { 
        Log.Info("Getting article title for opened page.");
        string title = page.FullSliderTextInfo.GetDomProperty("textContent");
        return title.Trim().Split("\n")[0];
    }

    public void ClickLearnMoreBtnOnSlide()
    {
        page.LearnMoreBtn.Click();
    }

}