using System;
using AmazonTests.Elements;
using TechTalk.SpecFlow;

namespace AmazonTests.Actions
{
    [Binding]
    public class DayDealsPageActions
    {
        private DayDealsPageElements dayDealsPage = new DayDealsPageElements();

        [When(@"I click on random deal on the page")]
        public void ClickOnRandomDealOnThePage()
        {
            int dealIndex = new Random().Next(dayDealsPage.DealsLinks.Count);
            dayDealsPage.DealsLinks[dealIndex].Click();
        }
    }
}
