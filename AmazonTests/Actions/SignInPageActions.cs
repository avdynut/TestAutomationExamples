using AmazonTests.Elements;
using AmazonTests.Utils;
using TechTalk.SpecFlow;

namespace AmazonTests.Actions
{
    [Binding]
    public class SignInPageActions
    {
        private SignInPageElements signInPage = new SignInPageElements();

        [Given(@"I sign in to Amazon using '(.*)' email and '(.*)' password")]
        public void SignInToAmazonUsingEmailAndPassword(string email, string password)
        {
            new NavigationBarElements().AccountLink.Click();
            signInPage.EmailInput.SendKeys(email);
            signInPage.PasswordInput.SendKeys(password);
            signInPage.SignInButton.Click();

            Browser.Driver.WaitUntilPageLoad();
            new CommonActions().VerifyThatTitleOfPageContains("Amazon.com");
        }
    }
}
