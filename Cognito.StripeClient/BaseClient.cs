using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Cognito.Stripe;
using System.Reflection;
using Cognito.Stripe.Classes;
using Cognito.StripeClient.Arguments;
using Cognito.Stripe.Helpers;
using Cognito.StripeClient.Converters;

namespace Cognito.StripeClient
{
	public class BaseClient
	{
		public static string BaseAPIUrl = "https://api.stripe.com";
		public static string BaseConnectUrl = "https://connect.stripe.com";

		protected BaseClient()
		{
			Cookies = new Dictionary<string, string>();
		}

		public BaseClient(string apiKey, string baseUrl = null, APIVersion version = APIVersion.v1)
			: this()
		{
			ApiKey = apiKey;
			APIVersion = version;
			BaseUrl = !String.IsNullOrWhiteSpace(baseUrl) ? baseUrl : BaseAPIUrl;
		}

		protected string BaseUrl { get; set; }
		protected APIVersion APIVersion { get; set; }
		protected string ApiKey { get; set; }
		protected IDictionary<string, string> Cookies;
		protected string TestId { get; set; }

		#region Public Instance API Methods

		public T Create<T>(CreateArguments args, bool throwExceptions = false)
			where T : BaseObject
		{
			return ProcessAPIRequest<T>(args, RequestMethod.Post);
		}

		public T Get<T>(GetArguments args, bool throwExceptions = false)
			where T : BaseObject
		{
			return ProcessAPIRequest<T>(args, RequestMethod.Get, throwExceptions);
		}

		public StripeList<T> List<T>(SearchArguments args, bool throwExceptions = false)
			where T : BaseObject
		{
			return ProcessAPIListRequest<T>(args, RequestMethod.Get, throwExceptions);
		}

		public T Delete<T>(DeleteArguments args, bool throwExceptions = false)
			where T : BaseObject
		{
			return ProcessAPIRequest<T>(args, RequestMethod.Delete, throwExceptions);
		}

		public T Update<T>(UpdateArguments args, bool throwExceptions = false)
			where T : BaseObject
		{
			return ProcessAPIRequest<T>(args, RequestMethod.Post, throwExceptions);
		}

		public string Create(CreateArguments args)
		{
			return ProcessClientRequest(CreateAPIRequest(args.GetEndpoint()).WithQueryStringArgs(args.ParseArguments(this)), RequestMethod.Post).Content;
		}

		public string Get(GetArguments args)
		{
			return ProcessClientRequest(CreateAPIRequest(args.GetEndpoint()).WithQueryStringArgs(args.ParseArguments(this)), RequestMethod.Get).Content;
		}

		public string List(SearchArguments args)
		{
			return ProcessClientRequest(CreateAPIRequest(args.GetEndpoint()).WithQueryStringArgs(args.ParseArguments(this)), RequestMethod.Get).Content;
		}

		public string Delete(DeleteArguments args)
		{
			return ProcessClientRequest(CreateAPIRequest(args.GetEndpoint()).WithQueryStringArgs(args.ParseArguments(this)), RequestMethod.Delete).Content;
		}

		public string Update(UpdateArguments args)
		{
			return ProcessClientRequest(CreateAPIRequest(args.GetEndpoint()).WithQueryStringArgs(args.ParseArguments(this)), RequestMethod.Post).Content;
		}
		#endregion

		StripeList<T> ProcessAPIListRequest<T>(BaseArguments args, RequestMethod method, bool throwExceptions)
			where T : BaseObject
		{
			var result = ProcessClientRequest(CreateAPIRequest(args.GetEndpoint()).WithParameters(args).WithQueryStringArgs(args.ParseArguments(this)), method);
			var List = new StripeList<T> { Data = new List<T>() };

			// ensure the  error object is populated
			if (!result.IsSuccessStatusCode)
			{
				var Obj = JsonUtility.Deserialize<T>(result.Content);

				Obj.Error = Obj.Error ?? new Error();
				Obj.Error.ResponseCode = Obj.Error.ResponseCode.HasValue ? Obj.Error.ResponseCode.Value : (int)result.StatusCode;
				Obj.Error.Message = !String.IsNullOrWhiteSpace(Obj.Error.Message) ? Obj.Error.Message : result.StatusMessage;

				if (throwExceptions)
					throw new ApplicationException(Obj.Error.Message);

				List.Data.Add(Obj);
			}
			else
				List = JsonUtility.Deserialize<StripeList<T>>(result.Content);

			return List;
		}

		T ProcessAPIRequest<T>(BaseArguments args, RequestMethod method, bool throwExceptions = false)
			where T : BaseObject
		{
			var result = ProcessClientRequest(CreateAPIRequest(args.GetEndpoint()).WithParameters(args).WithQueryStringArgs(args.ParseArguments(this)), method);

			T Obj = JsonUtility.Deserialize<T>(result.Content);

			// ensure the  error object is populated
			if (!result.IsSuccessStatusCode)
			{
				Obj.Error = Obj.Error ?? new Error();
				Obj.Error.ResponseCode = Obj.Error.ResponseCode.HasValue ? Obj.Error.ResponseCode.Value : (int)result.StatusCode;
				Obj.Error.Message = !String.IsNullOrWhiteSpace(Obj.Error.Message) ? Obj.Error.Message : result.StatusMessage;

				if (throwExceptions)
					throw new ApplicationException(Obj.Error.Message);
			}
			
			return Obj;
		}

		Request CreateAPIRequest(string endpoint, params object[] parameters)
		{
			return new Request(BaseUrl, (APIVersion.ToString() + "/" + endpoint))
				.WithHeader("Authorization", "Bearer " + ApiKey)
				.WithParameters(parameters);
		}

		Response ProcessClientRequest(Request request, RequestMethod method)
		{
			Response result = null;
			switch (method)
			{
				case RequestMethod.Get:
					result = request.SendAsGet();
					break;
				case RequestMethod.Post:
					result = request.SendAsPost();
					break;
				case RequestMethod.Put:
					result = request.SendAsPut();
					break;
				case RequestMethod.Delete:
					result = request.SendAsDelete();
					break;
			}

			return result;
		}
		
		Request CreateRequest(string url, string endpoint, string mediaType = "application/json")
		{
			var request = new Request(url, (APIVersion.ToString() + "/" + endpoint), mediaType);
			if (!string.IsNullOrWhiteSpace(TestId))
				request.AdditionalCookies.Add("TestId", TestId);

			return request;
		}

		public static T DeserializeObject<T>(string json)
			where T : BaseObject
		{
			return JsonUtility.Deserialize<T>(json);
		}

		public static string SerializeObject(BaseObject obj)
		{
			return JsonUtility.Serialize(obj);
		}

		#region Request & Response

		protected sealed class Response
		{
			public string Content { get; set; }

			public HttpStatusCode StatusCode { get; set; }

			public string StatusMessage { get; set; }

			public bool IsSuccessStatusCode { get { return StatusCode == HttpStatusCode.OK; } }
		}

		protected sealed class Request
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

		#endregion
	}

	public class ConnectClient : BaseClient
	{
		public ConnectClient(string baseUrl)
			: base(String.Empty, baseUrl)
		{
		}

		Request CreateConnectRequest(string endpoint, string mediaType = "application/json")
		{
			return new Request(BaseUrl, endpoint, mediaType);
		}

		public AuthToken GetAuthToken(AuthenticationArguments arguments)
		{
			var request = CreateConnectRequest("oauth/token", "application/x-www-form-urlencoded");
			arguments.GrantType = "authorization_code";

			return ProcessStripeAuthToken(request, data: arguments);
		}

		public AuthToken RefreshToken(AuthenticationArguments arguments)
		{
			var request = CreateConnectRequest("oauth/token", "application/x-www-form-urlencoded");
			arguments.GrantType = "refresh_token";

			return ProcessStripeAuthToken(request, data: arguments);
		}

		public AuthToken Deauthorize(string apiKey, DeauthorizeArguments arguments)
		{
			return ProcessStripeAuthToken(CreateConnectRequest("oauth/deauthorize").WithHeader("Authorization", "Bearer " + apiKey), queryParams: arguments.ParseArguments(this));
		}

		AuthToken ProcessStripeAuthToken(Request request, BaseArguments data = null, NameValueCollection queryParams = null)
		{
			var result = request
				.WithData(GenerateContent(data))
				.WithQueryStringArgs(queryParams)
				.SendAsPost();

			if (result.IsSuccessStatusCode)
				return JsonConvert.DeserializeObject<AuthToken>(result.Content);

			var error = JsonConvert.DeserializeObject<AuthTokenError>(result.Content);

			return new AuthToken { Error = error };
		}

		string GenerateContent(BaseArguments args)
		{
			if (args == null)
				return "";

			NameValueCollection dataCollection = args.ParseArguments(this);

			var data = new StringBuilder();

			foreach (string name in dataCollection.Keys)
			{
				if (data.Length > 0)
					data.Append("&");

				data.AppendFormat("{0}={1}", name, dataCollection[name]);
			}

			return data.ToString();
		}
	}

	public enum APIVersion
	{ 
		v1 = 1
	}

	public enum RequestMethod
	{ 
		Get,
		Post,
		Put,
		Delete
	}
}