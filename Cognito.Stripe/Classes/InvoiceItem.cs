using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class InvoiceItem : BaseObject
	{
		public override string Object { get { return "invoiceitem"; } }

		public Currency Currency { get; set;}

		[Cents]
		public decimal? Amount { get; set; }

		public DateTime? Date { get; set; }
		
		[JsonProperty("proration")]
		public bool IsProrated { get; set; }
		public string Description { get; set; }
		[JsonProperty("invoice")]
		public string InvoiceId { get; set; }
		public Plan Plan { get; set; }
		public int? Quantity { get; set; }
		[JsonProperty("subscription")]
		public string SubscriptionId { get; set; }
	}
}