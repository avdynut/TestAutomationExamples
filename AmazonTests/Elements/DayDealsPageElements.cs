using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AmazonTests.Elements
{
    public class DayDealsPageElements : ElementsBase
    {
        private const string DealsLinksXpath = "//span[@data-action='gbdeal-addtocart']/../../..//a//span[@id='dealTitle']/../..";

        [FindsBy(How = How.XPath, Using = DealsLinksXpath)]
        public IList<IWebElement> DealsLinks;
    }
}
