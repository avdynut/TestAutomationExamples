using TechTalk.SpecFlow;

namespace CraigslistSiteTests
{
    [Binding]
    public static class TestBase
    {
        [BeforeScenario]
        public static void SetUpBrowser()
        {
            Browser.Start();
        }

        [AfterScenario]
        public static void Quit()
        {
            Browser.Instance.Quit();
        }
    }
}
