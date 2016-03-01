using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class Charge: BaseObject
	{
		public override string Object { get { return "charge"; } }

		[Cents]
		public decimal? Amount { get; set; }
		public bool Captured { get; set; }
		public Currency Currency { get; set;}
		public bool Paid { get; set; }
		public bool Refunded { get; set; }
		public StripeList<Refund> Refunds { get; set; }

		public Source Source { get; set; }

		[JsonIgnore]
		public Card Card { get { return (Card)Source; } }

		[JsonIgnore]
		public BitcoinReceiver BitcoinReceiver { get { return (BitcoinReceiver)Source; } }

		public ChargeStatus Status { get; set; }
		[Cents]
		[JsonProperty("amount_refunded")]
		public decimal? AmountRefunded { get; set; }

		[JsonProperty("balance_transaction")]
		public string BalanceTransactionId { get; set; }
		public string Description { get; set; }
		public Dispute Dispute { get; set; }
		[JsonProperty("failure_code")]
		public string FailureCode { get; set; }
		[JsonProperty("failure_message")]
		public string FailureMessage { get; set; }
		public Invoice Invoice { get; set; }
		[JsonProperty("receipt_email")]
		private string ReceiptEmail { get; set; }
		[JsonProperty("receipt_number")]
		public string ReceiptNumber { get; set; }
		[JsonProperty("fraud_details")]
		public Dictionary<string, string> FraudDetails { get; set; }
		[JsonProperty("shipping")]
		public ShippingInfo ShippingInfo { get; set; }
	}

	public enum ChargeStatus
	{ 
		succeeded,
		failed
	}
}
