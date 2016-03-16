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

		public string Description { get; set; }
		public bool Discountable { get; set; }
		public Invoice Invoice { get; set; }
		public Period Period { get; set; }
		public Plan Plan { get; set; }
		
		[JsonProperty("proration")]
		public bool IsProrated { get; set; }

		public int? Quantity { get; set; }
		public Subscription Subscription { get; set; }
	}
}