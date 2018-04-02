using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Support.Extensions;

namespace AmazonTests.Utils
{
    public static class WebDriverExtensions
    {
        private static WebDriverWait Wait(this IWebDriver driver, int seconds)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        }

        public static void ImplicitlyWait(this IWebDriver driver, int seconds)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }

        public static void WaitUntilPageLoad(this IWebDriver driver, int seconds = 10)
        {
            driver.Wait(seconds).Until(drv => drv.ExecuteJavaScript<string>("return document.readyState").ToLower() == "complete");
        }

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                return driver.Wait(timeoutInSeconds).Until(ExpectedConditions.ElementExists(by));
            }
            catch
            {
                return null;
            }
        }
    }
}
