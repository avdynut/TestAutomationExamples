using CraigslistSiteTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CraigslistSiteTests.Steps
{
    [Binding]
    public class LotDetailsPageSteps
    {
        LotDetailsPage page = ScenarioContext.Current.Get<LotDetailsPage>();

        [Then(@"I expect that name of opened lot is equal to that one that I have remembered")]
        public void ThenIExpectThatNameOfOpenedLotIsEqualToThatOneThatIHaveRemembered()
        {
            string actualTitleText = page.TitleText;
            string lotName = ScenarioContext.Current.Get<string>();
            Assert.AreEqual(lotName, actualTitleText, "Lot name is not equals to actual title text");
        }

        [Then(@"I go back using browser's back button")]
        public void ThenIGoBackUsingBrowserSBackButton()
        {
            ScenarioContext.Current.Set(page.GoBack());
        }
    }
}
