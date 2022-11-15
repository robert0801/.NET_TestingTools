using PageObjects;

namespace Tests;

[TestFixture]
public class SearchTest : BaseTest
{
    private StartPage startPage = new StartPage();
    private CareerPage careerPage = new CareerPage();
    private JobListingsPage jobListingsPage = new JobListingsPage();
    private JobDescriptionPage jobDescriptionPage = new JobDescriptionPage();
    private SearchResultPage searchResultPage = new SearchResultPage();

    [TestCase("Java", "All Locations")]
    public void ValidateThatUserCanSearchForPositionBasedOnCriteriaTest(string programmingLang, string location)
    {
        startPage.ClickToCareerButtonInTopBar();
        careerPage.InsertSpecificJobToKeywordField(programmingLang);
        careerPage.ChooseLocationFromDropdown(location);
        careerPage.ChooseRemoteCheckbox();
        careerPage.ClickFindBtn();
        jobListingsPage.ClickToTheLastViewAndApplyBtn();

        Assert.True(jobDescriptionPage.GetJobTitle().Contains(programmingLang), $"Opened vacancy doesn't contain information about {programmingLang}");
    }

    [TestCase("BLOCKCHAIN")]
    [TestCase("Cloud")]
    [TestCase("Automation")]
    public void ValidateGlobalSarchWorksTest(string searchParametr)
    {
        startPage.ClickSearchGlassBtn();
        startPage.SearchByValue(searchParametr);

        Assert.Multiple(() =>
        {
            var investigatedElements = searchResultPage.GetAllStrongWordsFromSearchResult();
            foreach (var result in investigatedElements)
            {
                Assert.True(result.ToUpper().Contains(searchParametr.ToUpper()), 
                    $"Result is incorrect. Expected: {searchParametr} but found {result}");
            }
        });
    }
}
