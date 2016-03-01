using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.StripeClient.Arguments
{
	public class AuthenticationArguments : BaseArguments
	{
		[JsonProperty("client_secret")]
		public string ClientSecret { get; set; }
		public string Code { get; set; }
		[JsonProperty("grant_type")]
		public string GrantType { get; set; }
		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }
	}

	public class DeauthorizeArguments : BaseArguments
	{
		[JsonProperty("client_id")]
		public string ClientId { get; set; }
		[JsonProperty("_user_id")]
		public string AccountId { get; set; }
	}
}
