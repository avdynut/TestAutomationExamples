using System.Linq;
using AmazonTests.Elements;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AmazonTests.Actions
{
    [Binding]
    public class CartPageActions
    {
        private CartPageElements cartPage = new CartPageElements();

        [Then(@"I can see '(.*)' product in cart")]
        public void VerifyThatProductIsPresentInCart(string expectedProduct)
        {
            var itemsInCart = cartPage.ProductTitleSpans.Select(span => span.Text);
            Assert.That(itemsInCart.Any(item => item.Contains(expectedProduct)), $"'{expectedProduct}' is not present in shopping cart");
        }

        [Then(@"I can see in cart deal that I have remembered")]
        public void VerifyThatRememberedProductPresentInCart()
        {
            VerifyThatProductIsPresentInCart(ScenarioContext.Current.Get<string>("DealTitle"));
        }
    }
}
