using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;
using SpringCMTests.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringCMTests.Utilities;

namespace SpringCMTests.Actions
{
    class SpringCMLauncher
    {
        private string _driverPath = Path.Combine(Directory.GetCurrentDirectory(), @"Drivers");
        public IWebDriver GetWebDriverObject(string browserName)
        {
            var browserEnum = browserName.ParseToEnum();

            switch (browserEnum)
            {
                case BrowserName.Chrome:
                    // Steps to enable chrome driver logging.
                    var service = ChromeDriverService.CreateDefaultService(_driverPath);
                    service.EnableVerboseLogging = true;
                    service.LogPath = Path.Combine(@"C:\Temp", "chromedriver.log");
                    return new ChromeDriver(service);
                   // return new ChromeDriver(_driverPath);
                case BrowserName.IE:
                    return new InternetExplorerDriver(_driverPath);
                case BrowserName.Firefox:
                    return new FirefoxDriver(_driverPath);
                case BrowserName.Edge:
                    return new EdgeDriver(_driverPath);
                default:
                    Assert.Fail("BrowserName should be " + Enum.GetValues(typeof(BrowserName)));
                    return null;
            }
        }

        public void LaunchSprintCM(IWebDriver webDriver, string browserName, string url)
        {
            webDriver.Navigate().GoToUrl(url);
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            webDriver.SwitchTo().DefaultContent();
        }
    }
}
