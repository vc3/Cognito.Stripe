using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class BalanceTransaction : BaseObject
	{
		public override string Object { get { return "balance_transaction"; } }

		public Currency Currency { get; set; }

		[Cents]
		public decimal? Amount { get; set; }

		[JsonProperty("available_on")]
		public DateTime? Available { get; set; }

		[Cents]
		[JsonProperty("fee")]
		public decimal? FeeAmount { get; set; }

		[JsonProperty("fee_details")]
		public ICollection<FeeDetail> FeeDetails { get; set; }

		[Cents]
		[JsonProperty("net")]
		public decimal? NetAmount { get; set; }

		public BalanceTransactionStatus Status { get; set; }
		public BalanceTransactionType Type { get; set; }
		public string Description { get; set; }

		[JsonProperty("sourced_transfers")]
		public StripeList<Transfer> SourcedTransfers { get; set; }

		public Transaction Source { get; set; }
	}

	public enum BalanceTransactionType
	{ 
		Adjustment,
		Application_Fee,
		Application_Fee_Refund,
		Charge,
		Payment,
		Refund,
		Transfer,
		Transfer_Cancel,
		Transfer_Failure,
		Transfer_Refund
	}

	public enum BalanceTransactionStatus
	{ 
		Available,
		Pending
	}
}
