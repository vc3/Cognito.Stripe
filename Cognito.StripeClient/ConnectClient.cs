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
using System.Collections;

namespace Cognito.StripeClient
{
	public class ConnectClient
	{
		protected string BaseUrl { get; set; }

		public static string BaseConnectUrl = "https://connect.stripe.com";

		public ConnectClient(string baseUrl)
		{
			BaseUrl = !String.IsNullOrWhiteSpace(baseUrl) ? baseUrl : BaseConnectUrl;
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
			return ProcessStripeAuthToken(CreateConnectRequest("oauth/deauthorize").WithHeader("Authorization", "Bearer " + apiKey), queryParams: arguments.Parse(null));
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

			NameValueCollection dataCollection = args.Parse(null);

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
}
