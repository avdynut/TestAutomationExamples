using System.Configuration;

namespace ApiTestingSample.Utils
{
	public static class Settings
	{
		public static readonly string BaseApiUrl = ConfigurationManager.AppSettings["BaseApiUrl"];
		public static readonly string UsersPath = ConfigurationManager.AppSettings["UsersPath"];
		public static readonly string RootElementName = ConfigurationManager.AppSettings["RootElementName"];
	}
}
