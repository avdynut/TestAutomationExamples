using AmazonTests.Elements;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AmazonTests.Actions
{
    [Binding]
    public class HandleBuyPageActions
    {
        private HandleBuyPageElements handleBuyPage = new HandleBuyPageElements();

        [Then(@"I can see on the page notice with text '(.*)'")]
        public void VerifyThatNoticeWithTextIsPresent(string expectedText)
        {
            string confirmText = handleBuyPage.ConfirmNotice.Text;
            Assert.That(confirmText, Does.Contain(expectedText), "The product has not been added to cart");
        }
    }
}
