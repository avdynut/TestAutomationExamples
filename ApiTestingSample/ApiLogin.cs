using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ApiTestingSample
{
	public class ApiLogin
	{
		private const string Username = "59jlc9pcryw5pby1@my10minutemail.com";
		private const string Password = "Qwqw3211";
		private const string TokenName = "ltoken";
		private const string BaseUrl = "https://www.myfonts.com/";
		private const string LoginUrl = BaseUrl + "widgets/dropdown_login/login.php";
		private const string FavoritesPageUrl = BaseUrl + "users/rg2bcjxi10/favorites";
		private const string CartPageUrl = BaseUrl + "cart";

		private IWebDriver _driver;

		[OneTimeSetUp]
		public void InitDriver()
		{
			_driver = new ChromeDriver();
			_driver.Navigate().GoToUrl(BaseUrl + "notExistingPage");
			SetAuthTokenCookie();
		}

		private void SetAuthTokenCookie()
		{
			var client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
			var content = new FormUrlEncodedContent(new Dictionary<string, string>
				{ { "https", "1" }, { "username", Username }, { "password", Password } });
			var response = client.PostAsync(LoginUrl, content).Result;
			var cookies = response.Headers.GetValues("Set-Cookie").First(x => x.Contains(TokenName));
			var token = cookies.Split(';').First(x => x.StartsWith(TokenName)).Split('=')[1];
			_driver.Manage().Cookies.AddCookie(new Cookie(TokenName, token));
		}

		[Test]
		public void OpenFavoritesPage()
		{
			_driver.Navigate().GoToUrl(FavoritesPageUrl);
			Assert.That(_driver.Title, Is.EqualTo("Favorites « MyFonts"), "Incorrect page title");
		}

		[Test]
		public void OpenCart()
		{
			_driver.Navigate().GoToUrl(CartPageUrl);
			Assert.That(_driver.Title, Is.EqualTo("Shopping Cart « MyFonts"), "Incorrect page title");
		}

		[OneTimeTearDown]
		public void CloseBrowser()
		{
			_driver.Quit();
		}
	}
}
