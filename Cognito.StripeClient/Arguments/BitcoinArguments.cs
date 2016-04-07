using Cognito.Stripe;
using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient.Arguments
{
	public class BitcoinCreateArguments : CreateArguments
	{
		[Currency]
		public decimal? Amount { get; set; }
		public Currency Currency { get; set; }
		public string Description { get; set; }
		public string Email { get; set; }
		[JsonProperty("refund_mispayments")]
		public bool RefundMispayments { get; set; }

		public override string GetEndpoint() { return "bitcoin/receivers"; }
	}

	public class BitcoinGetArguments : GetArguments
	{
		public override string GetEndpoint() { return "bitcoin/receivers"; }
	}

	public class BitcoinSearchArguments : ListArguments
	{
		public bool Active { get; set; }
		public bool Filled { get; set; }
		[JsonProperty("uncaptured_funds")]
		public bool UncapturedFunds { get; set; }

		public override string GetEndpoint() { return "bitcoin/receivers"; }
	}
}
