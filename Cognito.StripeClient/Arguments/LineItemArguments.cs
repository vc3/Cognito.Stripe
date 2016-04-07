using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient.Arguments
{
	public class LineItemSearchArguments : ListArguments
	{
		[JsonProperty("id")]
		public string InvoiceId { get; set; }

		[JsonProperty("customer")]
		public string CustomerId { get; set; }

		[JsonProperty("subscription")]
		public string SubscriptionId { get; set; }

		public override string GetEndpoint() { return String.Format("invoices{0}/lines", InvoiceId); }
	}
}
