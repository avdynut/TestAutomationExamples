using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AmazonTests.Elements
{
    public class HandleBuyPageElements : ElementsBase
    {
        private const string ConfirmNoticeId = "huc-v2-order-row-confirm-text";

        [FindsBy(How = How.Id, Using = ConfirmNoticeId)]
        public IWebElement ConfirmNotice;
    }
}
