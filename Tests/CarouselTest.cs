using Business.Business;

namespace Tests;

[TestFixture]
public class CarouselTest : BaseTest
{
    private StartContext startContext = new StartContext();
    private InsightsContext insightsContext = new InsightsContext();
    private ArticleContext articleContext = new ArticleContext();

    [Test]
    public void ValidateThatNameOfArticleMatchesWithNameInArticle()
    {
        startContext.ClickInsightsButtonInTopBar();
        insightsContext.DragAndDropCarousel(-500, 0, 2);
        var exepectedTitle = insightsContext.GetCurrentArticleTitle();
        insightsContext.ClickLearnMoreBtnOnSlide();

        Assert.AreEqual(exepectedTitle, articleContext.GetArticleTitle(), "Opened page has unexpected title.");
    }
}