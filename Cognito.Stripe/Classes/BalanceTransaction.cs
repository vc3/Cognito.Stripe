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
		public List<FeeDetail> FeeDetails { get; set; }

		[Cents]
		[JsonProperty("net")]
		public decimal? NetAmount { get; set; }

		public BalanceTransactionStatus Status { get; set; }

		public BalanceTransactionType Type { get; set; }

		public string Description { get; set; }

		[JsonProperty("source")]
		public string SourceId { get; set; }
	}

	public enum BalanceTransactionType
	{ 
		Charge,
		Refund,
		Adjustment,
		Application_Fee,
		Application_Fee_Refund,
		Transfer,
		Transfer_Failure
	}

	public enum BalanceTransactionStatus
	{ 
		Available,
		Pending
	}
}
