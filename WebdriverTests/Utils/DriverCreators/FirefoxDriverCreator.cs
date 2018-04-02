﻿using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace WebdriverTests.Utils.DriverCreators
{
    public class FirefoxDriverCreator : WebDriverCreator
    {
        protected override DesiredCapabilities DesiredCapabilities => DesiredCapabilities.Firefox();
        protected override CustomWebDriver WebDriver => new CustomWebDriver(new FirefoxDriver());
    }
}
