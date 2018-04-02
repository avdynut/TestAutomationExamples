using CraigslistSiteTests.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CraigslistSiteTests.Steps
{
    [Binding]
    public class ForsalePageSteps
    {
        ForsalePage page = ScenarioContext.Current.Get<ForsalePage>();

        [Given(@"I see (.*) of submenu links")]
        public void GivenISeeOfSubmenuLinks(int expectedNumber)
        {
            Assert.AreEqual(expectedNumber, page.SubmenuLinksCount, "Number of sumbenu links are not equals");
        }

        [Given(@"first submenu link has name ""(.*)""")]
        public void GivenFirstSubmenuLinkHasName(string firstSubmenu)
        {
            try
            {
                Assert.AreEqual(firstSubmenu, page.GetSubmenuLinkText(0));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [When(@"I click on ""(.*)"" submenu link")]
        public void WhenIClickOnSubmenuLink(string submenuLink)
        {
            try
            {
                var nextPage = page.NavigateTo(submenuLink);
                ScenarioContext.Current.Set(nextPage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Given(@"I click on ""(.*)"" submenu link")]
        public void GivenIClickOnSubmenuLink(string submenuLink)
        {
            WhenIClickOnSubmenuLink(submenuLink);
        }
    }
}
