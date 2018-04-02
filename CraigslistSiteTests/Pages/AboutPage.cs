using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace CraigslistSiteTests.Pages
{
    public class AboutPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#postingbody a")]
        IList<IWebElement> aboutLinks { get; set; }

        public string GetLinkByItem(string itemName)
        {
            var element = FindElementByName(aboutLinks, itemName);
            return GetHrefAttribute(element);
        }
    }
}
