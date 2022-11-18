using Business.Business;

namespace Tests.UiTests
{
    [TestFixture]
    public class SearchTest : BaseTest
    {
        private StartContext startPage = new StartContext();
        private CareerContext careerPage = new CareerContext();
        private JobListingsContext jobListingsPage = new JobListingsContext();
        private JobDescriptionContext jobDescriptionPage = new JobDescriptionContext();
        private SearchResultContext searchResultPage = new SearchResultContext();

        [TestCase("Java", "All Locations")]
        public void ValidateThatUserCanSearchForPositionBasedOnCriteriaTest(string programmingLang, string location)
        {
            startPage.ClickToCareerButtonInTopBar();
            careerPage.InsertSpecificJobToKeywordField(programmingLang);
            careerPage.ChooseLocationFromDropdown(location);
            careerPage.ChooseRemoteCheckbox();
            careerPage.ClickFindBtn();
            jobListingsPage.ClickToTheLastViewAndApplyBtn();

            Assert.That(jobDescriptionPage.GetJobTitle(), Is.EqualTo(programmingLang), $"Opened vacancy doesn't contain information about {programmingLang}");
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
}
