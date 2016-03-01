using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe;
using Cognito.Stripe.Helpers;

namespace Cognito.StripeClient.Arguments
{
	public class InvoiceItemCreateArguments : CreateArguments
	{
		[JsonProperty("customer")]
		public string CustomerId { get; set; }

		public Currency Currency { get; set; }

		[Cents]
		public decimal? Amount { get; set; }

		[JsonProperty("invoice")]
		public string InvoiceId { get; set; }
		[JsonProperty("subscription")]
		public string SubscriptionId { get; set; }
		public string Description { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "invoiceitems"; } }
	}

	public class InvoiceItemGetArguments : GetArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "invoiceitems"; } }
	}

	public class InvoiceItemUpdateArguments : UpdateArguments
	{
		[JsonIgnore]
		public Currency Currency { get; set; }

		[Cents]
		public decimal? Amount { get; set; }

		public string Description { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "invoiceitems"; } }
	}

	public class InvoiceItemDeleteArguments : DeleteArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "invoiceitems"; } }
	}

	public class InvoiceItemSearchArguments : SearchArguments
	{ 
		[JsonProperty("customer")]
		public string CustomerId { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "invoiceitems"; } }
	}
}
