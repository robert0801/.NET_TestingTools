using PageObjects;

namespace Tests;

[TestFixture]
public class CarouselTest : BaseTest
{
    private StartPage startPage = new StartPage();
    private InsightsPage insightsPage = new InsightsPage();
    private ArticlePage articlePage = new ArticlePage();

    [Test]
    public void ValidateThatNameOfArticleMatchesWithNameInArticle()
    {
        startPage.ClickInsightsButtonInTopBar();
        insightsPage.DragAndDropCarousel(-500, 0, 2);
        var exepectedTitle = insightsPage.GetCurrentArticleTitle();
        insightsPage.ClickLearnMoreBtnOnSlide();

        Assert.AreEqual(exepectedTitle, articlePage.GetArticleTitle(), "Opened page has unexpected title.");
    }
}