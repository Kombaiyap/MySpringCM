using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpringCMTests.Constants;

namespace SpringCMTests.Pages
{
    class ResourcePage
    {

        private IWebDriver _webDriver;
        public ResourcePage(IWebDriver webdriver)
        {
            PageFactory.InitElements(webdriver, this);
            _webDriver = webdriver;
        }

        [FindsBy(How = How.CssSelector, Using = ResourcePageConstants.ProfolioFilterClassName)]
        public IWebElement PortforlioFilters { get; set; }

        [FindsBy(How = How.CssSelector, Using = ResourcePageConstants.MediaTypeCssSelector)]
        public IWebElement MediaTypeDropDown { get; set; }

        //[FindsBy(How = How.CssSelector, Using = ResourcePageConstants.SearchFieldCssSelector)]
        //public IWebElement SearchInputField { get; set; }

        //[FindsBy(How = How.Id, Using = ResourcePageConstants.QueryContentLabelId)]
        //public IWebElement QueryContentLabel { get; set; }

        //[FindsBy(How = How.Id, Using = ResourcePageConstants.SearchResultsId)]
        //public IWebElement SearchResults { get; set; }


    }
}
