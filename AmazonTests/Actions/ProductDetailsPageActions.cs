using AmazonTests.Elements;
using AmazonTests.Utils;
using TechTalk.SpecFlow;

namespace AmazonTests.Actions
{
    [Binding]
    public class ProductDetailsPageActions
    {
        private ProductDetailsPageElements productDetailsPage = new ProductDetailsPageElements();

        [When(@"I remember title of the product")]
        public void RememberTitleOfTheProduct()
        {
            string dealTitle = productDetailsPage.ProductTitle.Text;
            ScenarioContext.Current.Set(dealTitle, "DealTitle");
        }

        [When(@"I select size as '(.*)'")]
        public void SelectSizeAs(string sizeName)
        {
            productDetailsPage.SizeDropdown.SelectByText(sizeName);
        }

        [When(@"add '(.*)' pieces? to cart")]
        public void AddFewPiecesToCart(int quantity)
        {
            productDetailsPage.QantityDropdown.SelectByValue(quantity.ToString());
            AddProductToCart();
            ScenarioContext.Current.Set(quantity, "Quantity");
        }

        [When(@"add product to cart")]
        public void AddProductToCart()
        {
            Browser.Driver.ImplicitlyWait(5);
            productDetailsPage.AddToCartButton.Click();
            productDetailsPage.CloseButtonOnPopupWindow?.Click();
        }
    }
}
