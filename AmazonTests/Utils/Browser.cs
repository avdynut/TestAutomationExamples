using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AmazonTests.Utils
{
    public class Browser
    {
        private static Lazy<IWebDriver> lazyDriver;
        public static IWebDriver Driver => lazyDriver.Value;

        private static IWebDriver SetUpBrowser()
        {
            return new FirefoxDriver();
        }

        public static void InitDriver()
        {
            lazyDriver = new Lazy<IWebDriver>(SetUpBrowser);
        }
    }
}
