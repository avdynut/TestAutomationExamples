using AmazonTests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AmazonTests.Elements
{
    public class ProductDetailsPageElements : ElementsBase
    {
        private const string ProductTitleSpanId = "productTitle";
        private const string SizeSelectId = "native_dropdown_selected_size_name";
        private const string QuantitySelectId = "quantity";
        private const string AddToCartInputCss = "input[id*='add-to-cart-button']";
        private const string CloseButtonOnPopoverCss = "button[data-action='a-popover-close']";

        [FindsBy(How = How.Id, Using = ProductTitleSpanId)]
        public IWebElement ProductTitle;

        [FindsBy(How = How.Id, Using = SizeSelectId)]
        private IWebElement sizeSelect;
        public SelectElement SizeDropdown => new SelectElement(sizeSelect);

        [FindsBy(How = How.Id, Using = QuantitySelectId)]
        private IWebElement quantitySelect;
        public SelectElement QantityDropdown => new SelectElement(quantitySelect);

        [FindsBy(How = How.CssSelector, Using = AddToCartInputCss)]
        public IWebElement AddToCartButton;

        public IWebElement CloseButtonOnPopupWindow => Browser.Driver.FindElement(By.CssSelector(CloseButtonOnPopoverCss), 1);
    }
}
