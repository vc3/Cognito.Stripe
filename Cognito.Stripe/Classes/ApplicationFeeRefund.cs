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

		[Currency]
		public decimal? Amount { get; set; }	
		
		[JsonProperty("balance_transaction")]
		public BalanceTransaction BalanceTransaction { get; set; }
		
		public ApplicationFee Fee { get; set; }
	}
}