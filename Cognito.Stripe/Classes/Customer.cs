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

		public StripeList<Source> Sources { get; set; }

		[Cents]
		[JsonProperty("account_balance")]
		public decimal? AccountBalance { get; set; }
		
		public Currency Currency { get; set;}
		[JsonProperty("default_source")]
		public string DefaultSourceId { get; set; }
		public bool Deliquent { get; set; }
		public string Description { get; set; }
		public Discount Discount { get; set; }
		public string Email { get; set; }
		public StripeList<Subscription> Subscriptions { get; set; }

		[JsonIgnore]
		public Card DefaultCard 
		{
			get
			{
				return Sources != null ? Sources.Data.FirstOrDefault(c => c.Id == DefaultSourceId) : null;
			}		
		}

		[JsonIgnore]
		public BitcoinReceiver DefaultReceiver
		{
			get
			{
				return Sources != null ? Sources.Data.FirstOrDefault(c => c.Id == DefaultSourceId) : null;
			}
		}
	}
}