using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AmazonTests.Elements
{
    public class CartPageElements : ElementsBase
    {
        private const string ProductTitleSpanCss = ".a-list-item span.sc-product-title";

        [FindsBy(How = How.CssSelector, Using = ProductTitleSpanCss)]
        public IList<IWebElement> ProductTitleSpans;
    }
}
