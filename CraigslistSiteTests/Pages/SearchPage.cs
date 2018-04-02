using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace CraigslistSiteTests.Pages
{
    public class SearchPage : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "hdrlnk")]
        IList<IWebElement> lotsLinks { get; set; }

        [FindsBy(How = How.Id, Using = "query")]
        IWebElement searchBox { get; set; }

        public int LotsOnPageCount
        {
            get { return lotsLinks.Count; }
        }

        public string GetLotName(int index)
        {
            return lotsLinks[index].Text;
        }

        public LotDetailsPage ClickOnLotLink(int index)
        {
            lotsLinks[index].Click();
            return new LotDetailsPage();
        }

        public void EnterInSearchBox(string query)
        {
            searchBox.SendKeys(query);
        }

        public SearchPage PressSearchButton()
        {
            searchBox.Submit();
            return this;
        }
    }
}
