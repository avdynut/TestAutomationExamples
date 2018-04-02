using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AmazonTests.Elements
{
    public class SignInPageElements : ElementsBase
    {
        private const string EmailInputId = "ap_email";
        private const string PasswordInputId = "ap_password";
        private const string SignInInputId = "signInSubmit";

        [FindsBy(How = How.Id, Using = EmailInputId)]
        public IWebElement EmailInput;

        [FindsBy(How = How.Id, Using = PasswordInputId)]
        public IWebElement PasswordInput;

        [FindsBy(How = How.Id, Using = SignInInputId)]
        public IWebElement SignInButton;
    }
}
