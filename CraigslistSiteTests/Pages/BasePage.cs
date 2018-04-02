using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace CraigslistSiteTests.Pages
{
    public abstract class BasePage
    {
        public string Title
        {
            get { return Browser.Instance.Title; }
        }

        public BasePage()
        {
            PageFactory.InitElements(Browser.Instance, this);
        }

        protected string GetHrefAttribute(IWebElement element)
        {
            return element.GetAttribute("href");
        }

        protected IWebElement FindElementByName(IList<IWebElement> list, string name)
        {
            return list.First(x => x.Text == name);
        }
    }
}
