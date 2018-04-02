using ApiTestingSample.Models;
using ApiTestingSample.Utils;
using NUnit.Framework;
using SimpleJson;
using System;
using System.Net;
using static RestSharp.Method;

namespace ApiTestingSample.Tests
{
	public class UserTests
	{
		[Test]
		[TestCase(2)]
		[TestCase(5)]
		public void GetUser(int id)
		{
			var response = Api.User(id).Execute<User>();
			var user = response.Data;
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Wrong status code");
			Assert.That(user.Id, Is.EqualTo(id), "Wrong user id");
			Assert.That(user.FirstName, Is.Not.Empty.And.Not.Null, "Wrong user first name");
			Assert.That(user.LastName, Is.Not.Empty.And.Not.Null, "Wrong user last name");
			Assert.That(user.AvatarLink, Is.Not.Empty.And.Not.Null, "Wrong avatar link");
		}

		[Test]
		public void CreateUser()
		{
			var testUser = new User { FirstName = "Andrei", LastName = "Arekhva" };
			var response = Api.Users.Execute<User>(POST, body: testUser);
			var user = response.Data;
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Wrong status code");
			Assert.That(user.FirstName, Is.EqualTo(testUser.FirstName), "Wrong first name");
			Assert.That(user.Id, Is.TypeOf<uint>().And.Not.Zero, "Wrong user id");
			Assert.That(user.CreatedAt?.Date, Is.EqualTo(DateTime.Today), "Wrong createdAt date");
		}

		[Test]
		[TestCase(2)]
		public void UpdateUser(int id)
		{
			var testUser = new JsonObject { { "first_name", "Andrei" }, { "avatar", "http://bla.com/photo.png" } };
			var response = Api.User(id).Execute<User>(PUT, body: testUser);
			var user = response.Data;
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Wrong status code");
			Assert.That(user.FirstName, Is.EqualTo(testUser["first_name"]), "Wrong first name");
			Assert.That(user.AvatarLink, Is.EqualTo(testUser["avatar"]), "Wrong user job");
			Assert.That(user.UpdatedAt?.Date, Is.EqualTo(DateTime.Today), "Wrong updatedAt date");
		}

		[Test]
		[TestCase(7)]
		public void DeleteUser(int id)
		{
			var response = Api.User(id).Execute(DELETE);
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent), "Wrong status code");
			Assert.That(response.Content, Is.Empty, "Body has to by empty");
		}

		[Test]
		public void GetNotExistingUser()
		{
			var response = Api.User(434435).Execute();
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Wrong status code");
			Assert.That(response.Content, Is.EqualTo("{}"), "Body has to be empty");
		}
	}
}
