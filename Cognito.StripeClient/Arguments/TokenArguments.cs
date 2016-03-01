using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.StripeClient.Arguments
{
	public class CardTokenCreateArguments : CreateArguments
	{
		public CardArguments Card { get; set; }
		public string Customer { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "tokens"; } }
	}

	public class BankAccountTokenCreateArguments : CreateArguments
	{
		public string Country { get; set; }
		[JsonProperty("routing_number")]
		public string RoutingNumber { get; set; }
		[JsonProperty("account_number")]
		public string AccountNumber { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "tokens"; } }
	}
}