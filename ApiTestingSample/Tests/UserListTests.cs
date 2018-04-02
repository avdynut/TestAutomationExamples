using ApiTestingSample.Models;
using ApiTestingSample.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace ApiTestingSample.Tests
{
	public class UserListTests
	{
		[Test]
		public void GetUserList()
		{
			var response = Api.Users.Execute<List<User>>();
			dynamic body = SimpleJson.SimpleJson.DeserializeObject(response.Content);
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Wrong status code");
			Assert.That(body["total"], Is.TypeOf<long>().And.Positive, "'total' key has to be a positive number");
		}

		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(1034)]
		public void UserListPagination(int pageNumber)
		{
			var response = Api.Users.Execute<List<User>>(queryParams: new Dictionary<string, string> { { "page", pageNumber.ToString() } });
			var users = response.Data;
			dynamic body = SimpleJson.SimpleJson.DeserializeObject(response.Content);
			var expectedCount = pageNumber > body["total_pages"] ? 0 : body["per_page"];
			Assert.That(users.Count, Is.LessThanOrEqualTo(expectedCount), "Wrong count of users per page");
		}
	}
}
