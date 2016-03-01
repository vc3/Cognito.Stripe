using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class Transfer : BaseObject
	{
		public override string Object { get { return "transfer"; } }

		public Currency Currency { get; set;}

		[Cents]
		public decimal? Amount { get; set; }

		public DateTime? Date { get; set; }

		public TransferStatus Status { get; set; }
		public TransferType Type { get; set; }
		[JsonProperty("balance_transaction")]
		public string BalanceTransactionId { get; set; }
		public string Description { get; set; }
		[JsonProperty("failure_code")]
		public string FailureCode { get; set; }
		[JsonProperty("failure_message")]
		public string FailureMessage { get; set; }
		[JsonProperty("bank_account")]
		public BankAccount BankAccount { get; set; }
		public Card Card { get; set; }
		[JsonProperty("recipient")]
		public string RecipientId { get; set; }
		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }
	}

	public enum TransferStatus
	{
		Paid,
		Pending,
		Canceled,
		Failed
	}

	public enum TransferType
	{
		Card,
		Bank_Account
	}
}