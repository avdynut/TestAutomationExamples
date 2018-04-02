using System.Linq;
using AmazonTests.Elements;
using TechTalk.SpecFlow;

namespace AmazonTests.Actions
{
    [Binding]
    public class ProductsPageActions
    {
        private ProductsPageElements productsPage = new ProductsPageElements();

        [When(@"I click on the first link which contains '(.*)'")]
        public void ClickOnTheFirstLinkWhichContains(string expectedText)
        {
            productsPage.ItemLinks.First(link => link.Text.Contains(expectedText)).Click();
        }
    }
}
