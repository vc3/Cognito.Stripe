using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class Charge : Transaction
	{
		public override string Object { get { return "charge"; } }

		public bool Captured { get; set; }
		public string Description { get; set; }
		public Account Destination { get; set; }
		public Dispute Dispute { get; set; }

		[JsonProperty("failure_code")]
		public string FailureCode { get; set; }

		[JsonProperty("failure_message")]
		public string FailureMessage { get; set; }

		[JsonProperty("fraud_details")]
		public Dictionary<string, string> FraudDetails { get; set; }

		public Invoice Invoice { get; set; }
		public Order Order { get; set; }
		public bool Paid { get; set; }

		[JsonProperty("receipt_email")]
		private string ReceiptEmail { get; set; }

		[JsonProperty("receipt_number")]
		public string ReceiptNumber { get; set; }

		public bool Refunded { get; set; }
		public StripeList<Refund> Refunds { get; set; }

		[JsonProperty("shipping")]
		public ShippingInfo ShippingInfo { get; set; }

		public PaymentSource Source { get; set; }

		public ChargeStatus Status { get; set; }

		public Transfer Transfer { get; set; }
	}

	public enum ChargeStatus
	{
		Succeeded,
		Failed
	}
}
