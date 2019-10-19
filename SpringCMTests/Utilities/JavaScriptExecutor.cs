using OpenQA.Selenium;

namespace SpringCMTests.Utilities
{
    class JavaScriptExecutor
    {
        public static void ExecuteJsScript(IWebDriver webDriver, string script)
        {
            var executor = (IJavaScriptExecutor)webDriver;
            executor.ExecuteScript(script);
        }
    }
}
