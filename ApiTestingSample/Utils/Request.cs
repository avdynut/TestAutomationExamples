using RestSharp;
using System;
using System.Collections.Generic;

namespace ApiTestingSample.Utils
{
	public class Request
	{
		private static readonly Lazy<RestClient> Client = new Lazy<RestClient>(() => new RestClient(Settings.BaseApiUrl));
		private readonly RestRequest _request;

		public Request(string path, string rootElement = null)
		{
			_request = new RestRequest(path);
			if (!string.IsNullOrEmpty(rootElement))
				_request.RootElement = rootElement;
		}

		public IRestResponse<T> Execute<T>(Method method = Method.GET, Dictionary<string, string> queryParams = null, object body = null) where T : new()
		{
			_request.Method = method;
			if (queryParams != null)
				foreach (var param in queryParams)
					_request.AddQueryParameter(param.Key, param.Value);
			if (body != null && _request.Method != Method.GET)
				_request.AddJsonBody(body);

			var response = Client.Value.Execute<T>(_request);
			Console.WriteLine($"Executed request: {_request.Method} {response.ResponseUri}");
			Console.WriteLine($"Response status: {response.ResponseStatus}, status description: {response.StatusDescription}");
			return response;
		}

		public IRestResponse Execute(Method method = Method.GET)
		{
			_request.Method = method;
			return Client.Value.Execute(_request);
		}
	}
}
