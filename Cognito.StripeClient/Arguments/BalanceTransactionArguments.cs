using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe;
using Cognito.Stripe.Classes;

namespace Cognito.StripeClient.Arguments
{
	public class BalanceGetArguments : GetArguments
	{
		public override string GetEndpoint() { return "balance"; }
	}

	public class BalanceTransactionGetArguments : GetArguments
	{
		public override string GetEndpoint() { return String.Format("balance/history/{0}", Id); }
	}

	public class BalanceTransactionSearchArguments : SearchArguments
	{
		[JsonProperty("available_on[gt]")]
		public DateTime? AvailableAfter { get; set; }
		[JsonProperty("available_on[gte]")]
		public DateTime? AvailableOnOrAfter { get; set; }
		[JsonProperty("available_on[lt]")]
		public DateTime? AvailableBefore { get; set; }
		[JsonProperty("available_on[lte]")]
		public DateTime? AvailableOnOrBefore { get; set; }

		public Currency Currency { get; set; }

		[JsonProperty("source")]
		public string SourceId { get; set; }
		[JsonProperty("transfer")]
		public string TransferId { get; set; }
		public BalanceTransactionType Type { get; set; }

		public override string GetEndpoint() { return "balance/history"; }
	}
}
