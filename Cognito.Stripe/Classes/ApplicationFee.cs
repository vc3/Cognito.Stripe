using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class ApplicationFee : Transaction
	{	
		public override string Object { get { return "application_fee"; } }

		[JsonProperty("account")]
		public string AccountId { get; set; }

		public Application Application { get; set; }

		public Charge Charge { get; set; }

		[JsonProperty("originating_transaction")]
		public Charge OriginatingTransaction { get; set; }
		
		public bool Refunded { get; set; }
		
		[JsonProperty("refunds")]
		public StripeList<Refund> RefundList { get; set; }
	}
}