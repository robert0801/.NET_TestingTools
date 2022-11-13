using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestingTools;

[TestFixture]
public class Tests
{
    private readonly By careerTitleBar = By.XPath("//a[@href='/careers']");
    private readonly By keywordField = By.XPath("//*[@placeholder='Keyword']");
    private readonly By locationDropdown = By.ClassName("select2-selection__arrow");
    private readonly By locationSelector = By.XPath("//*[@class='select2-results']/ul");
    private readonly By remoteCheckbox = By.XPath("//label[contains(text(), 'Remote')]");
    private readonly By findBtn = By.CssSelector("#jobSearchFilterForm > button");
    private readonly By viewAndApplyBtn = By.XPath("//*[text()='View and apply']");
    private readonly By acceptCookiesBtn = By.Id("onetrust-accept-btn-handler");
    private readonly By pageTitle = By.ClassName("form-component__description");
    private readonly By searchGlassBtn = By.XPath("//*[text()='Search']/parent::button");
    private readonly By searchLine = By.Name("q");
    private readonly By searchBtn = By.ClassName("header-search__submit");
    private readonly By viewMoreBtn = By.XPath("//*[text()='View More']");
    private readonly By searchResultInDescription = By.XPath("//*[@class='search-results__description']/strong");
    private string optionInLocationDropdown = "//li[@title='{0}']";

    private By outBrandsLbl = By.XPath("//*[text()='OUR BRANDS']");

    private readonly String baseUrl = "https://www.epam.com/";
    private IWebDriver driver;
    private WebDriverWait wait;
    private IJavaScriptExecutor executor;
    private Actions actions;

    [SetUp]
    public void Setup()
    {
        driver = driver ?? new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Manage().Window.Maximize();
        actions = actions ?? new Actions(driver);
        wait = wait ?? new WebDriverWait(driver, new TimeSpan(0, 0, 10));
        executor = executor ?? (IJavaScriptExecutor) driver;

        driver.Url = baseUrl;
        waitForEnabled(acceptCookiesBtn);
        clickUsingJs(driver.FindElement(acceptCookiesBtn));
    }

    [TestCase("Java", "All Locations")]
    public void ValidateThatUserCanSearchForPositionBasedOnCriteriaTest(string programmingLang, string location)
    {
        driver.FindElement(careerTitleBar).Click();
        driver.FindElement(keywordField).SendKeys(programmingLang);
        driver.FindElement(locationDropdown).Click();

        var exepectedLocation = driver.FindElement(By.XPath(string.Format(optionInLocationDropdown, location)));
        actions.MoveToElement(exepectedLocation).Perform();
        exepectedLocation.Click();
        driver.FindElement(remoteCheckbox).Click();
        driver.FindElement(findBtn).Click();

        var lastViewAndApplyBtn = driver.FindElements(viewAndApplyBtn).Last();
        actions.MoveToElement(lastViewAndApplyBtn).Perform();
        lastViewAndApplyBtn.Click();

        Assert.True(driver.FindElement(pageTitle).Text.Contains(programmingLang), $"Opened vacancy doesn't contain information about {programmingLang}");
    }

    [TestCase("BLOCKCHAIN")]
    [TestCase("Cloud")]
    [TestCase("Automation")]
    public void ValidateGlobalSarchWorksTest(string searchParametr)
    {
        driver.FindElement(searchGlassBtn).Click();
        driver.FindElement(searchLine).SendKeys(searchParametr);
        driver.FindElement(searchBtn).Click();

        while(true)
        {
            actions.MoveToElement(driver.FindElement(outBrandsLbl)).Perform();
            try {
            driver.FindElement(viewMoreBtn).Click();
            }
            catch (ElementNotInteractableException)
            {
                Console.WriteLine("There is not exist additional 'More and view' button on the page.");
                break;
            }
        }

        Assert.Multiple(() =>
        {
            var investigatedElements = driver.FindElements(searchResultInDescription);
            foreach (var result in investigatedElements)
            {
                Assert.True(result.Text.ToUpper().Contains(searchParametr.ToUpper()), 
                $"Result is incorrect. Expected: {searchParametr} but found {result.Text}");
            }
        });
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver = null;
    }

    private void waitForEnabled(By locator)
    {
        var element = wait.Until(condition => 
        {
            try {
                var elementToBeEnabled = driver.FindElement(locator);
                return elementToBeEnabled.Enabled;

            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        });
    }

    private void clickUsingJs(IWebElement element)
    {
        executor.ExecuteScript("arguments[0].click();", element);
    }
}
