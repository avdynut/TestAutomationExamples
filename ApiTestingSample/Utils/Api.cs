using RestSharp;

namespace ApiTestingSample.Utils
{
	public static class Api
	{
		public static Request Users => new Request(Settings.UsersPath, Settings.RootElementName);
		public static Request User(int id) => new Request($"{Settings.UsersPath}/{id}", Settings.RootElementName);
	}
}
