using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class AuthToken
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }
		[JsonProperty("token_type")]
		public string TokenType { get; set; }
		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }

		public string ClientToken { get; set; }

		public AuthTokenError Error { get; set; }
		public bool LiveMode { get; set; }
		[JsonProperty("stripe_publishable_key")]
		public string PublishableKey { get { return ClientToken; } set { ClientToken = value; } }
		[JsonProperty("stripe_user_id")]
		public string UserId { get; set; }
		public string Scope { get; set; }
	}

	public class AuthTokenError
	{
		[JsonProperty("error")]
		public string Type { get; set; }
		[JsonProperty("error_description")]
		public string Message { get; set; }

		public override string ToString()
		{
			return Type + " Error :: " + Message;
		}
	}
}