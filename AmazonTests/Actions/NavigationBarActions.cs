using AmazonTests.Elements;
using AmazonTests.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AmazonTests.Actions
{
    [Binding]
    public class NavigationBarActions
    {
        private readonly NavigationBarElements navigationBar = new NavigationBarElements();

        [StepDefinition(@"I enter '(.*)' in search textbox")]
        public void EnterInSearchTextbox(string request)
        {
            navigationBar.SearchTextBox.SendKeys(request);
        }

        [Given(@"click search button")]
        public void ClickSearchButton()
        {
            navigationBar.SearchButton.Click();
            Browser.Driver.WaitUntilPageLoad();
        }

        [Given(@"I click ""(.*)"" link in the Navigation Menu")]
        public void ClickLinkInTheNavigationMenu(string linkText)
        {
            navigationBar.LinkInNavigationMenu(linkText).Click();
        }

        [Then(@"I open shopping cart")]
        public void OpenShoppingCart()
        {
            navigationBar.CartLink.Click();
        }

        [When(@"I remember count of goods in cart")]
        public void RememberCountOfGoodsInCart()
        {
            string countOfGoods = navigationBar.CountOfGoodsInCartSpan.Text;
            ScenarioContext.Current.Set(int.Parse(countOfGoods), "CountOfGoodsInCart");
        }

        [Then(@"I can see that count of goods in cart increased on appropriate quantity")]
        public void VerifyThatCountOfGoodsInCartIncreasedOnAppropriateQuantity()
        {
            var currentCount = int.Parse(navigationBar.CountOfGoodsInCartSpan.Text);
            var previousCount = ScenarioContext.Current.Get<int>("CountOfGoodsInCart");
            var quantity = ScenarioContext.Current.Get<int>("Quantity");
            Assert.That(currentCount, Is.EqualTo(previousCount + quantity), "Count of goods in cart not encreased on appropriate quantity");
        }
    }
}
