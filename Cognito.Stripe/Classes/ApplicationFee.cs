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

		[JsonProperty("account")]
		public string AccountId { get; set; }
		[JsonProperty("application")]
		public string ApplicationId { get; set; }
		[JsonProperty("balance_transaction")]
		public string BalanceTransactionId { get; set; }
		[JsonProperty("charge")]
		public string ChargeId { get; set; }
		public Currency Currency { get; set;}
		public bool Refunded { get; set; }

		[Cents]
		[JsonProperty("amount_refunded")]
		public decimal? AmountRefunded { get; set; }

		[Cents]
		public decimal? Amount { get; set; }	
		
		[JsonProperty("refunds")]
		public StripeList<Refund> RefundList { get; set; }
	}
}