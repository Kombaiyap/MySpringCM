using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpringCMTests.Actions;
using SpringCMTests.Constants;
using SpringCMTests.Pages;
using SpringCMTests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpringCMTests.Steps
{
    [Binding]
    public sealed class SpringCMSteps : TechTalk.SpecFlow.Steps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _context;
        private readonly SpringCMLauncher _launcher;
        private readonly TestSettingReader testSetting = new TestSettingReader();
        private readonly IWebDriver _webDriver;
        private readonly HomePage _homePage;
        private readonly DemoPage _demoPage;
        private readonly ResourcePage _resourcePage;
        public SpringCMSteps(ScenarioContext context)
        {
            _context = context;
            _launcher = new SpringCMLauncher();
            _webDriver = _launcher.GetWebDriverObject(testSetting.BrowserName);
            _homePage = new HomePage(_webDriver);
            _demoPage = new DemoPage(_webDriver);
            _resourcePage = new ResourcePage(_webDriver);
        }


        [Given(@"SpringCM page is launched")]
        public void GivenSpringCMPageIsLaunched()
        {
            _launcher.LaunchSprintCM(_webDriver,testSetting.BrowserName,testSetting.SprintCMUrl);
        }

        [When(@"I Search ""(.*)"" in the search field")]
        public void WhenISearchInTheSearchField(string searchText)
        {
           _homePage.ClickSearchIcon();
           _homePage.SearchContract(searchText);
        }

        [Then(@"""(.*)"" is displayed in the results label")]
        public void ThenIsDisplayedInTheResultsLabel(string resultsLabelText)
        {
            Assert.AreEqual(resultsLabelText, _homePage.GetQueryContentLabelText());
        }

        [Then(@"""(.*)"" link should be displayed")]
        public void ThenLinkShouldBeDisplayed(string expectedLinkText)
        {
            Assert.IsTrue(_homePage.GetSearchResults().Any(d => d.Equals(expectedLinkText)), $"{expectedLinkText} is not present in the results");
        }

        [Given(@"""(.*)"" links are displayed")]
        public void GivenLinksAreDisplayed(string contractLinks)
        {
            Given("SpringCM page is launched");
            When(@"I Search ""Contract Management"" in the search field");
            Then(@"""Contract Management"" is displayed in the results label");
            Then(@"""Contract Management Software | SpringCM"" link should be displayed");
        }

        [When(@"I click on ""(.*)"" link")]
        public void WhenIClickOnLink(string softwareManagementContractLink)
        {
            _homePage.ClickOnContractMagementLink(softwareManagementContractLink);
        }

        [Then(@"""(.*)"" home page is displayed")]
        public void ThenHomePageIsDisplayed(string pageTitle)
        {
            Assert.IsTrue(_webDriver.Title.Contains(pageTitle), $" {pageTitle} page is not displayed");
        }

        [When(@"I click on ""(.*)"" link in contract management page")]
        public void WhenIClickOnLinkInContractManagementPage(string productDemoLink)
        {
            _webDriver.FindElement(By.CssSelector($"a[title *= '{productDemoLink.ToUpper()}']")).Click();

        }

        [Then(@"""(.*)"" page is displayed")]
        public void ThenContractManagementDemoPageIsDisplayed(string newPageTitle)
        {
            var currentWindowHandle = _webDriver.CurrentWindowHandle;
            var windowHandles = _webDriver.WindowHandles;
            var newWindow = windowHandles.FirstOrDefault(d => !d.Equals(currentWindowHandle));
            _webDriver.SwitchTo().Window(newWindow);
            _webDriver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            WaitUtility.WaitTillElementIsVisible(_demoPage.PageHeader, _webDriver);
            Assert.AreEqual(newPageTitle, _demoPage.PageHeader.Text);

        }

        [When(@"I click on ""(.*)"" button")]
        public void WhenIClickOnButton(string playVideoButtonText)
        {
            _demoPage.ClickPlayVideoButton(playVideoButtonText);
        }

        [Then(@"Validation messages are displayed")]
        public void ThenValidationMessagesAreDisplayed()
        {
            Assert.IsTrue(_demoPage.AreValidationMessageDisplayed(), "Validation messages are not displayed");
        }

        [When(@"I fill the form")]
        public void WhenIFillTheFormAndSubmit(Table table)
        {
            _demoPage.FirstName.SendKeys(table.Rows[0]["firstName"]);
            _demoPage.LastName.SendKeys(table.Rows[0]["lastName"]);
            _demoPage.EmailId.SendKeys(table.Rows[0]["emailId"]);
            _demoPage.PhoneNumber.SendKeys(table.Rows[0]["phone"]);
            _demoPage.CompanyName.SendKeys(table.Rows[0]["companyName"]);
            _demoPage.CompanyName.SendKeys(Keys.ArrowDown + Keys.Enter);
            _demoPage.Country.SendKeys(table.Rows[0]["country"]);

        }

        [Then(@"video player for product demo is displayed")]
        public void ThenVideoPlayerForProductDemoIsDisplayed()
        {
            WaitUtility.WaitTillElementIsVisible(_demoPage.VideoContainer, _webDriver);
            Assert.IsTrue(_demoPage.VideoContainer.Displayed, "the video is not displayed");
        }

        [When(@"I select ""(.*)"" under Resource tab")]
        public void WhenISelectUnderResourceTab(string resourceLibrary)
        {
            _homePage.SelectResourceLibrary();
        }

        [Then(@"the default resource content is displayed")]
        public void ThenTheDefaultResourceContentIsDisplayed()
        {
            Assert.IsTrue(GetResourceTypes().Count() > 1);
        }

        private List<string> GetResourceTypes()
        {
            var resourceContent = _webDriver.FindElements(By.CssSelector(ResourcePageConstants.PortfolioItemCssSelector)).ToList();
            var resourceTypes = resourceContent.Select(d => d.Text).Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            return resourceTypes;
        }

        [When(@"I select Media type drop down")]
        public void WhenISelectMediaTypeDropDown()
        {
            _resourcePage.PortforlioFilters.Click();

        }

        [Then(@"media type drop down is displayed")]
        public void ThenMediaTypeDropDownIsDisplayed()
        {
            Assert.IsTrue(_resourcePage.PortforlioFilters.GetAttribute("class").Contains("active"));
        }

        [When(@"I select ""(.*)"" from media type drop down")]
        public void WhenISelectFromMediaTypeDropDown(string reportText)
        {
            var mediaTypes = _webDriver.FindElements(By.CssSelector(ResourcePageConstants.PortfolioCssSelector)).ToList();
            mediaTypes.SingleOrDefault(d => d.Text.Equals(reportText)).Click();
        }

        [Then(@"only ""(.*)"" content is displayed on resource page")]
        public void ThenOnlyContentIsDisplayedOnResourcePage(string reportText)
        {
            WaitUtility.Sleep(5);
            var resources = GetResourceTypes();
            Assert.IsTrue(resources.Count == 1 && resources.FirstOrDefault().Equals(reportText,StringComparison.InvariantCultureIgnoreCase));

        }

        [AfterScenario()]
        public void QuitDriver()
        {
             if(ScenarioContext.TestError != null)
            {
                ScreenshotUtility.TakeScreehShot(_webDriver);
            }
            _webDriver.Quit();
        }

    }
}
