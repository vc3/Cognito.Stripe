using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class Refund : Transaction
	{
		public override string Object { get { return "refund"; } }

		public Charge Charge { get; set; }

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
