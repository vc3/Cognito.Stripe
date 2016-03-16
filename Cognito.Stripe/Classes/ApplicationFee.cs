using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class ApplicationFee : BaseObject
	{	
		public override string Object { get { return "application_fee"; } }

		public Currency Currency { get; set;}

		[JsonProperty("account")]
		public string AccountId { get; set; }

		[Cents]
		public decimal? Amount { get; set; }	

		[Cents]
		[JsonProperty("amount_refunded")]
		public decimal? AmountRefunded { get; set; }

		public Application Application { get; set; }

		[JsonProperty("balance_transaction")]
		public BalanceTransaction BalanceTransaction { get; set; }

		public Charge Charge { get; set; }

		[JsonProperty("originating_transaction")]
		public Charge OriginatingTransaction { get; set; }
		
		public bool Refunded { get; set; }
		
		[JsonProperty("refunds")]
		public StripeList<Refund> RefundList { get; set; }
	}
}