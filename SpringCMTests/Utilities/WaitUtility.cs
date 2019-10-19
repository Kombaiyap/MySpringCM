using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SpringCMTests.Utilities
{
    class WaitUtility
    {
        public static void WaitTillElementIsVisible(IWebElement webElement,IWebDriver webDriver)
        {
            var webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            webDriverWait.Until(d => webElement.Displayed);
        }
        

        public static void Sleep(int seconds)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }
}
