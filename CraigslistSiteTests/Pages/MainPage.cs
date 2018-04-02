using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace CraigslistSiteTests.Pages
{
    public class MainPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "topban")]
        IWebElement topban { get; set; }

        public string TopbanText
        {
            get { return topban.Text; }
        }

        [FindsBy(How = How.CssSelector, Using = "#logo a")]
        IWebElement logoLink { get; set; }

        public string LogoLink
        {
            get { return GetHrefAttribute(logoLink); }
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='sss']//*")]
        IList<IWebElement> sectionSale { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".clfooter a")]
        IList<IWebElement> footerLinks { get; set; }

        public MainPage Open()
        {
            Browser.Instance.Navigate().GoToUrl(Properties.Resources.Url);
            return this;
        }

        public ForsalePage NavigateTo(string menuItem)
        {
            FindElementByName(sectionSale, menuItem).Click();
            return new ForsalePage();
        }

        public string GetFooterLinkName(int index)
        {
            return footerLinks[index].Text;
        }

        public string GetFooterLink(int index)
        {
            return GetHrefAttribute(footerLinks[index]);
        }

        public AboutPage ClickOnFooterLink(string linkName)
        {
            FindElementByName(footerLinks, linkName).Click();
            return new AboutPage();
        }
    }
}
