using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class Customer : BaseObject
	{
		public override string Object { get { return "customer"; } }

		public Currency Currency { get; set; }

		[Currency]
		[JsonProperty("account_balance")]
		public decimal? AccountBalance { get; set; }

		[JsonProperty("default_source")]
		internal string DefaultSourceId { get; set; }

		[JsonIgnore]
		public PaymentSource DefaultSource { get { return Sources.Data.FirstOrDefault(s => s.Id.Equals(DefaultSourceId, StringComparison.OrdinalIgnoreCase)); } }

		public bool Delinquent { get; set; }
		public string Description { get; set; }
		public Discount Discount { get; set; }
		public string Email { get; set; }
		public ShippingInfo Shipping { get; set; }
		public StripeList<PaymentSource> Sources { get; set; }
		
		public StripeList<Subscription> Subscriptions { get; set; }
	}
}