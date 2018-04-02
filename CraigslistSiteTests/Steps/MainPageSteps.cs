using CraigslistSiteTests.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CraigslistSiteTests.Steps
{
    [Binding]
    public class MainPageSteps
    {
        MainPage page;

        [Given(@"I open https://denver.craigslist.org/ page")]
        public void GivenIOpenHttpsDenver_Craigslist_OrgPage()
        {
            page = new MainPage().Open();
        }

        [Given(@"I can see ""(.*)"" text at the top")]
        public void GivenICanSeeTextAtTheTop(string expectedText)
        {
            string textTop = page.TopbanText;
            Assert.IsTrue(textTop.Contains(expectedText), "Text at the top: " + textTop);
        }

        [Given(@"there is ""(.*)"" link which navigates to ""(.*)"" page")]
        public void GivenThereIsLinkWhichNavigatesToOrgAboutSitesPage(string text, string expectedLink)
        {
            string actualLink = page.LogoLink;
            Assert.IsTrue(actualLink.Contains(expectedLink), "Actual link: " + actualLink);
        }

        [Given(@"I click on ""(.*)"" link under ""(.*)"" section")]
        public void GivenIClickOnLinkUnderSection(string menuItem, string sectionName)
        {
            try
            {
                var nextPage = page.NavigateTo(menuItem);
                ScenarioContext.Current.Set(nextPage);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Given(@"Footer link on the (.*) place has name ""(.*)""")]
        public void GivenFooterLinkOnThePlaceHasName(int index, string expectedName)
        {
            ScenarioContext.Current.Set(index);
            string actualName = page.GetFooterLinkName(index);
            Assert.AreEqual(expectedName, actualName, "Names of the link are not match");
        }

        [Given(@"I remember link address of ""(.*)""")]
        public void GivenIRememberLinkAddressOf(string linkName)
        {
            int index = ScenarioContext.Current.Get<int>();
            string url = page.GetFooterLink(index).TrimEnd('/');
            ScenarioContext.Current.Set(url);
        }

        [When(@"I click on ""(.*)"" link")]
        public void WhenIClickOnLink(string linkName)
        {
            try
            {
                var nextPage = page.ClickOnFooterLink(linkName);
                ScenarioContext.Current.Set(nextPage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
