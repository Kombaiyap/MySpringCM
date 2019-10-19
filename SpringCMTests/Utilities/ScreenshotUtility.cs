using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringCMTests.Utilities
{
    class ScreenshotUtility
    {

        public static void TakeScreehShot(IWebDriver webdriver)
        {
            try
            {
                Screenshot image = ((ITakesScreenshot)webdriver).GetScreenshot();
                image.SaveAsFile($"C:/temp/Screenshot_{DateTime.Now.ToString("MM-dd-yy")}.png", ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Assert.Fail("Failed with Exception: " + e);
            }
        }
    }
}
