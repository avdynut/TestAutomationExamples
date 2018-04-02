using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CraigslistSiteTests.Pages
{
    public class LotDetailsPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "titletextonly")]
        IWebElement titleText { get; set; }

        public string TitleText
        {
            get { return titleText.Text; }
        }

        public SearchPage GoBack()
        {
            Browser.Instance.Navigate().Back();
            return new SearchPage();
        }
    }
}
