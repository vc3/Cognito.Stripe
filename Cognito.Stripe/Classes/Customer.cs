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

		[Cents]
		[JsonProperty("account_balance")]
		public decimal? AccountBalance { get; set; }

		[JsonProperty("default_source")]
		public Source DefaultSource { get; set; }

		public bool Deliquent { get; set; }
		public string Description { get; set; }
		public Discount Discount { get; set; }
		public string Email { get; set; }
		public ShippingInfo Shipping { get; set; }
		public StripeList<Source> Sources { get; set; }
		
		public StripeList<Subscription> Subscriptions { get; set; }

		[JsonIgnore]
		public Card DefaultCard 
		{
			get
			{
				return Sources != null ? Sources.Data.FirstOrDefault(c => c.Id == DefaultSource.Id) : null;
			}		
		}

		[JsonIgnore]
		public BitcoinReceiver DefaultReceiver
		{
			get
			{
				return Sources != null ? Sources.Data.FirstOrDefault(c => c.Id == DefaultSource.Id) : null;
			}
		}
	}
}