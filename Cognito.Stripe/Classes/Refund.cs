using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class Refund : BaseObject
	{
		public override string Object { get { return "refund"; } }

		public Currency Currency { get; set;}

		[Cents]
		public decimal? Amount { get; set; }

		public Charge Charge { get; set; }

		[JsonProperty("balance_transaction")]
		public string BalanceTransactionId { get; set; }
		public RefundReason Reason { get; set; }
		[JsonProperty("receipt_number")]
		public string ReceiptNumber { get; set; }
		public string Description { get; set; }
	}

	public enum RefundReason
	{ 
		unknown,
		duplicate,
		fraudulent,
		requested_by_customer
	}
}
