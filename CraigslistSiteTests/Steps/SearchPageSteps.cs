using CraigslistSiteTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CraigslistSiteTests.Steps
{
    [Binding]
    public class SearchPageSteps
    {
        SearchPage page = ScenarioContext.Current.Get<SearchPage>();
        int indexTestedElement = 0;

        [When(@"Remember name of the first lot")]
        public void WhenRememberNameOfTheFirstLot()
        {
            string lotName = page.GetLotName(indexTestedElement);
            ScenarioContext.Current.Set(lotName);
        }

        [When(@"Click on it")]
        public void WhenClickOnIt()
        {
            var nextPage = page.ClickOnLotLink(indexTestedElement);
            ScenarioContext.Current.Set(nextPage);
        }

        [Then(@"I expect to be navigated to the page which title contains '(.*)'")]
        public void ThenIExpectToBeNavigatedToThePageWhichTitleContains(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, page.Title);
        }

        [When(@"I enter '(.*)' in search box")]
        public void WhenIEnterInSearchBox(string query)
        {
            page.EnterInSearchBox(query);
        }

        [When(@"press Search button")]
        public void WhenPressSearchButton()
        {
            page.PressSearchButton();
        }

        [Then(@"I expect to see page with the title containing ""(.*)""")]
        public void ThenIExpectToSeePageWithTheTitleContaining(string partTitleText)
        {
            Assert.IsTrue(page.Title.Contains(partTitleText));
        }

        [Then(@"I expect at least (.*) result to be displayed on the page")]
        public void ThenIExpectAtLeastResultToBeDisplayedOnThePage(int minCount)
        {
            Assert.GreaterOrEqual(page.LotsOnPageCount, minCount);
        }
    }
}
