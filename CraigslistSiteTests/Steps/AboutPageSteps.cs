using CraigslistSiteTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CraigslistSiteTests.Steps
{
    [Binding]
    public class AboutPageSteps
    {
        AboutPage page = ScenarioContext.Current.Get<AboutPage>();

        [Then(@"I expect that page title contains ""(.*)""")]
        public void ThenIExpectThatPageTitleContains(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, page.Title, "Wrong title on about page");
        }

        [Then(@"I expect that the item ""(.*)"" references to url that I have remembered")]
        public void ThenIExpectThatTheItemReferencesToUrlThatIHaveRemembered(string itemName)
        {
            string expectedLink = ScenarioContext.Current.Get<string>();
            Assert.AreEqual(expectedLink, page.GetLinkByItem(itemName), "Wrong link of the item");
        }
    }
}
