using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpringCMTests.Constants;
using SpringCMTests.Utilities;

namespace SpringCMTests.Pages
{
    class DemoPage
    {

        private IWebDriver _webDriver;
        public DemoPage(IWebDriver webdriver)
        {
            PageFactory.InitElements(webdriver, this);
            _webDriver = webdriver;
        }

        [FindsBy(How = How.CssSelector, Using = DemoPageConstants.PageHeaderCssSelector)]
        public IWebElement PageHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = DemoPageConstants.ValidationMessageClassName)]
        public IWebElement ValidationMessages { get; set; }


        [FindsBy(How = How.CssSelector, Using = DemoPageConstants.FirstNameCssSelector)]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.CssSelector, Using = DemoPageConstants.LastNameCssSelector)]
        public IWebElement LastName { get; set; }


        [FindsBy(How = How.CssSelector, Using = DemoPageConstants.EmailIdCssSelector)]
        public IWebElement EmailId { get; set; }

        [FindsBy(How = How.CssSelector, Using = DemoPageConstants.PhoneNumberCssSelector)]
        public IWebElement PhoneNumber { get; set; }


        [FindsBy(How = How.CssSelector, Using = DemoPageConstants.CompanyNameCssSelector)]
        public IWebElement CompanyName { get; set; }

        [FindsBy(How = How.CssSelector, Using = DemoPageConstants.CountryNameCssSelector)]
        public IWebElement Country { get; set; }


        [FindsBy(How = How.Id, Using = DemoPageConstants.DeclineCookieId)]
        public IWebElement DeclineCookies { get; set; }

        [FindsBy(How = How.Id, Using = DemoPageConstants.VideoContainerId)]
        public IWebElement VideoContainer { get; set; }

        public bool AreValidationMessageDisplayed()
        {
            return ValidationMessages.Displayed;
        }

        public void ClickPlayVideoButton(string playVideoButtonText)
        {
            DeclineCookie();
            var playVideoButton = _webDriver.FindElement(By.CssSelector($"input[value='{playVideoButtonText.ToUpper()}']"));
            WaitUtility.WaitTillElementIsVisible(playVideoButton, _webDriver);
            playVideoButton.Click();
        }

        public void DeclineCookie()
        {
            if (DeclineCookies != null && DeclineCookies.Displayed)
                DeclineCookies.Click();
        }

    }
}
