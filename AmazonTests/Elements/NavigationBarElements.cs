using AmazonTests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AmazonTests.Elements
{
    public class NavigationBarElements : ElementsBase
    {
        private const string SearchTextBoxId = "twotabsearchtextbox";
        private const string SearchButtonCss = "input[type='submit']";
        private const string LinkWithTextInNavigationMenuXpath = "//div[@id='nav-main']//a[text()=\"{0}\"]";
        private const string AccountLinkId = "nav-link-yourAccount";
        private const string CartLinkId = "nav-cart";
        private const string CountOfGoodsInCartSpanId = "nav-cart-count";

        [FindsBy(How = How.Id, Using = SearchTextBoxId)]
        public IWebElement SearchTextBox;

        [FindsBy(How = How.CssSelector, Using = SearchButtonCss)]
        public IWebElement SearchButton;

        public IWebElement LinkInNavigationMenu(string linkText)
        {
            return Browser.Driver.FindElement(By.XPath(string.Format(LinkWithTextInNavigationMenuXpath, linkText)));
        }

        [FindsBy(How = How.Id, Using = AccountLinkId)]
        public IWebElement AccountLink;

        [FindsBy(How = How.Id, Using = CartLinkId)]
        public IWebElement CartLink;

        [FindsBy(How = How.Id, Using = CountOfGoodsInCartSpanId)]
        public IWebElement CountOfGoodsInCartSpan;
    }
}
