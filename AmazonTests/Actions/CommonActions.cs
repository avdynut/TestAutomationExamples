using AmazonTests.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AmazonTests.Actions
{
    [Binding]
    public class CommonActions
    {
        [BeforeScenario]
        public static void InitDriver()
        {
            Browser.InitDriver();
        }

        [AfterScenario]
        public static void Quit()
        {
            Browser.Driver.Quit();
        }

        [Given(@"I (?:open|navigate to) '(.*)' page")]
        public void OpenPage(string url)
        {
            Browser.Driver.Navigate().GoToUrl(url);
        }

        [StepDefinition(@"the title of page contains '(.*)'")]
        public void VerifyThatTitleOfPageContains(string expectedTitleChunk)
        {
            Assert.That(Browser.Driver.Title, Does.Contain(expectedTitleChunk), "Incorrect page title or the page is not opened");
        }
    }
}
