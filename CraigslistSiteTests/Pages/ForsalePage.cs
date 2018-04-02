using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace CraigslistSiteTests.Pages
{
    public class ForsalePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".leftside li a")]
        IList<IWebElement> submenuLinks { get; set; }

        public int SubmenuLinksCount
        {
            get { return submenuLinks.Count; }
        }

        public string GetSubmenuLinkText(int linkIndex)
        {
            return submenuLinks[linkIndex].Text;
        }

        public SearchPage NavigateTo(string linkText)
        {
            var link = submenuLinks.First(l => l.Text == linkText);
            link.Click();
            return new SearchPage();
        }
    }
}
