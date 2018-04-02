using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace CraigslistSiteTests
{
    public class Browser
    {
        private static Lazy<IWebDriver> lazy;

        public static IWebDriver Instance { get { return lazy.Value; } }

        private Browser()
        {
            Start();
        }

        private static IWebDriver SetUpBrowser()
        {
            switch (Properties.Resources.WebDriver)
            {
                case "Firefox":
                    return new FirefoxDriver();
                case "Chrome":
                    return new ChromeDriver();
                default:
                    throw new ArgumentException("Incorrect value of WebDriver");
            }
        }

        public static void Start()
        {
            lazy = new Lazy<IWebDriver>(() => SetUpBrowser());
        }
    }
}
