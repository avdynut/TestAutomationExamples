using AmazonTests.Utils;
using OpenQA.Selenium.Support.PageObjects;

namespace AmazonTests.Elements
{
    public abstract class ElementsBase
    {
        protected ElementsBase()
        {
            PageFactory.InitElements(Browser.Driver, this);
        }
    }
}
