using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;
using SpringCMTests.Constants;
using SpringCMTests.Utilities;

namespace SpringCMTests.Pages
{
    class HomePage
    {
        private IWebDriver _webDriver;
        public HomePage(IWebDriver webdriver)
        {
            PageFactory.InitElements(webdriver, this);
            _webDriver = webdriver;
        }

        [FindsBy(How = How.CssSelector, Using = HomePageConstants.SearchIconCssSelector)]
        public IWebElement SearchIcon { get; set; }

        [FindsBy(How = How.CssSelector, Using = HomePageConstants.SearchFieldCssSelector)]
        public IWebElement SearchInputField { get; set; }

        [FindsBy(How = How.Id, Using = HomePageConstants.QueryContentLabelId)]
        public IWebElement QueryContentLabel { get; set; }

        [FindsBy(How = How.Id, Using = HomePageConstants.SearchResultsId)]
        public IWebElement SearchResults { get; set; }

        [FindsBy(How = How.LinkText, Using = HomePageConstants.ResoucreTabText)]
        public IWebElement ResourcesTab { get; set; }

        [FindsBy(How = How.LinkText, Using = HomePageConstants.ResourceLibraryText)]
        public IWebElement ResourcesLibrary { get; set; }

        public void ClickSearchIcon()
        {
            var script = $"$('({HomePageConstants.SearchIconCssSelector}').click();";
            JavaScriptExecutor.ExecuteJsScript(_webDriver, script);
        }

        public void SearchContract(string searchText)
        {
            var script = $"$('{HomePageConstants.SearchFieldCssSelector}').val('{searchText}');";
            JavaScriptExecutor.ExecuteJsScript(_webDriver, script);
            SearchInputField.Submit();
        }

        public string GetQueryContentLabelText()
        {
            WaitUtility.WaitTillElementIsVisible(QueryContentLabel, _webDriver);
            return QueryContentLabel.Text;
        }

        public List<string> GetSearchResults()
        {
            var searchResultLinks = SearchResults.FindElements(By.TagName("a")).ToList();

             return searchResultLinks.Select(d => d.Text).ToList();
        }

        public void ClickOnContractMagementLink(string softwareManagementContractLink)
        {
            var searchResultLinks = SearchResults.FindElements(By.TagName("a")).ToList();

            foreach (var link in searchResultLinks)
            {
                if(link.Text.Contains(softwareManagementContractLink))
                {
                    link.Click();
                    break;
                }
            }
        }

        public void SelectResourceLibrary()
        {
            var action = new OpenQA.Selenium.Interactions.Actions(_webDriver);
            action.MoveToElement(ResourcesTab).Build().Perform();
            ResourcesLibrary.Click();
        }

        private void FindLinkByText()
        {

        }
    }
}
