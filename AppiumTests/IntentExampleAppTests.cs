using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;

namespace AppiumTests
{
    public class IntentExampleAppTests
    {
        private AndroidDriver<AndroidElement> driver;

        private const string TitleTextviewId = "title";
        private const string NameEdittextId = "editText1";
        private const string NextScreenButtonClass = "android.widget.Button";
        private const string WelcomeTextviewId = "textView1";

        [OneTimeSetUp]
        public void SetUp()
        {
            var caps = new DesiredCapabilities();
            caps.SetCapability(MobileCapabilityType.App, AppDomain.CurrentDomain.BaseDirectory + @Properties.Resources.RelativePathToApp);
            caps.SetCapability(MobileCapabilityType.DeviceName, Properties.Resources.DeviceName);
            caps.SetCapability(MobileCapabilityType.PlatformName, Properties.Resources.PlatformName);
            driver = new AndroidDriver<AndroidElement>(new Uri(Properties.Resources.HubUrl), caps);
        }

        [SetUp]
        public void Reset()
        {
            driver.ResetApp();
        }

        [TestCase("Andrey")]
        [TestCase(null)]
        public void EnterAs(string name)
        {
            if (name != null)
            {
                AndroidElement nameTextbox = driver.FindElementById(NameEdittextId);
                nameTextbox.SendKeys(name);
            }
            else
                name = "Guest";

            AndroidElement nextScreenButton = driver.FindElementByClassName(NextScreenButtonClass);
            nextScreenButton.Click();

            AndroidElement welcomeTextview = driver.FindElementById(WelcomeTextviewId);
            Assert.That(welcomeTextview.Text, Is.EqualTo("Welcome " + name), "Incorrect welcome text");
        }

        [Test]
        public void CheckTitle()
        {
            AndroidElement titleTextview = driver.FindElementById(TitleTextviewId);
            Assert.That(titleTextview.Text, Is.EqualTo("IntentExample"), "Incorrect aplication's title");
        }

        [Test]  // Test from AppiumDotNetSample project
        public void StartActivityWithDefaultIntentAndDefaultCategoryWithOptionalArgs()
        {
            driver.StartActivityWithIntent("com.prgguru.android", ".GreetingActivity", "android.intent.action.MAIN",
                null, null, "android.intent.category.DEFAULT", "0x4000000", "--es \"USERNAME\" \"AppiumIntentTest\" -t \"text/plain\"");
            AndroidElement welcomeTextview = driver.FindElementById(WelcomeTextviewId);
            Assert.AreEqual(welcomeTextview.Text, "Welcome AppiumIntentTest");
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
