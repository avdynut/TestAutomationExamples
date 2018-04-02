using RestSharp.Deserializers;
using System;

namespace ApiTestingSample.Models
{
	public class User
	{
		[DeserializeAs(Name = "id")]
		public uint Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		[DeserializeAs(Name = "avatar")]
		public string AvatarLink { get; set; }

		[DeserializeAs(Name = "createdAt")]
		public DateTime? CreatedAt { get; set; } = null;

		[DeserializeAs(Name = "updatedAt")]
		public DateTime? UpdatedAt { get; set; } = null;
	}
}
