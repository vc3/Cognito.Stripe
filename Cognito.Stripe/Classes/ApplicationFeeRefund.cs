using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class ApplicationFeeRefund : BaseObject
	{
		public override string Object { get { return "fee_refund"; } }

		public Currency Currency { get; set; }
		[Cents]
		public decimal? Amount { get; set; }	
		[JsonProperty("balance_transaction")]
		public string BalanceTransactionId { get; set; }
		[JsonProperty("fee")]
		public string ApplicationFeeId { get; set; }
	}
}