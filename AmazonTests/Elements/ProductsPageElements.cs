using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AmazonTests.Elements
{
    public class ProductsPageElements : ElementsBase
    {
        private const string ItemLinksCss = "a.s-access-detail-page";

        [FindsBy(How = How.CssSelector, Using = ItemLinksCss)]
        public IList<IWebElement> ItemLinks;
    }
}
