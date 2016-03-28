using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class Transfer : Transaction
	{
		public override string Object { get { return "transfer"; } }

		public DateTime? Date { get; set; }

		public string Description { get; set; }
		
		public BankAccount Destination { get; set; }

		[JsonProperty("destination_payment")]
		public Charge DestinationPayment { get; set; }

		[JsonProperty("failure_code")]
		public string FailureCode { get; set; }

		[JsonProperty("failure_message")]
		public string FailureMessage { get; set; }

		public ICollection<Reversal> Reversals { get; set; }

		public bool Reversed { get; set; }

		[JsonProperty("source_transaction")]
		public Transaction SourceTransaction { get; set; }

		[JsonProperty("source_type")]
		public SourceType SourceType { get; set; }

		public TransferStatus Status { get; set; }

		public TransferType Type { get; set; }
	}

	public enum TransferStatus
	{
		Paid,
		Pending,
		In_Transit,
		Canceled,
		Failed
	}

	public enum TransferType
	{
		Card,
		Bank_Account,
		Stripe_Account
	}
}