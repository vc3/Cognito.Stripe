using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cognito.StripeClient
{
	internal sealed class Request
	{
		private string BaseUrl { get; set; }
		private string Endpoint { get; set; }
		private object Data { get; set; }
		private string MediaType { get; set; }
		private List<object> Parameters { get; set; }
		private RequestMethod Method { get; set; }
		private IDictionary<string, string> AdditionalHeaders;
		public IDictionary<string, string> AdditionalCookies;

		private string Domain
		{
			get { return BaseUrl.Replace("http://", "").Replace("https://", "").Replace("/", ""); }
		}

		public Request(string baseUrl, string endpoint, string mediaType = "application/json")
		{
			BaseUrl = baseUrl;
			Method = RequestMethod.Get;
			AdditionalHeaders = new Dictionary<string, string>();
			AdditionalCookies = new Dictionary<string, string>();
			Endpoint = endpoint;
			MediaType = mediaType;
			Parameters = new List<object>();
		}

		public Response SendAsGet()
		{
			Method = RequestMethod.Get;
			return Send();
		}

		public Response SendAsPost()
		{
			Method = RequestMethod.Post;
			return Send();
		}

		public Response SendAsPut()
		{
			Method = RequestMethod.Put;
			return Send();
		}

		public Response SendAsDelete()
		{
			Method = RequestMethod.Delete;
			return Send();
		}

		public Request WithVerb(RequestMethod verb)
		{
			Method = verb;
			return this;
		}

		public Request WithHeader(string name, string value)
		{
			AdditionalHeaders.Add(name, value);
			return this;
		}

		public Request WithData(object data)
		{
			Data = data;
			return this;
		}

		public Request WithParameters(params object[] parameters)
		{
			foreach (var obj in parameters)
				Parameters.Add(obj);

			return this;
		}

		public Request WithQueryStringArgs(NameValueCollection arguments)
		{
			if (arguments != null && arguments.AllKeys.Any())
			{
				var args = string.Join("&", arguments.AllKeys.Select(k => k + "=" + arguments[k]));
				Endpoint += Endpoint.IndexOf("?") == -1 ? "?" + args : "&" + args;
			}

			return this;
		}

		public Response Send()
		{
			var context = HttpContext.Current;
			Response response = null;

			using (var handler = new HttpClientHandler())
			{
				using (var client = new HttpClient(handler))
				{
					client.BaseAddress = client.BaseAddress ?? new Uri(BaseUrl);
					client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

					StringContent content = null;
					if (Data != null)
						content = new StringContent(Data is string ? (string)Data : JsonUtility.Serialize(Data), Encoding.UTF8, MediaType);

					// Add additional headers to the request
					foreach (var header in AdditionalHeaders)
						client.DefaultRequestHeaders.Add(header.Key, header.Value);

					// Add additional cookies to the request
					if (context == null)
						foreach (var cookie in AdditionalCookies)
							handler.CookieContainer.Add(new Cookie(cookie.Key, cookie.Value, "/", Domain));

					// Set endpoint
					var actualEndpoint = string.Format(Endpoint, Parameters.ToArray());

					// remove trailing /
					actualEndpoint = actualEndpoint.TrimEnd('/');

					HttpResponseMessage httpResponse = null;
					switch (Method)
					{
						case RequestMethod.Get:
							httpResponse = client.GetAsync(actualEndpoint).Result;
							break;
						case RequestMethod.Post:
							httpResponse = client.PostAsync(actualEndpoint, content).Result;
							break;
						case RequestMethod.Put:
							httpResponse = client.PutAsync(actualEndpoint, content).Result;
							break;
						case RequestMethod.Delete:
							httpResponse = client.DeleteAsync(actualEndpoint).Result;
							break;
					}

					response = new Response
					{
						Content = httpResponse.Content.ReadAsStringAsync().Result,
						StatusCode = httpResponse.StatusCode,
						StatusMessage = httpResponse.ReasonPhrase
					};
				}
			}

			return response;
		}
	}
}
