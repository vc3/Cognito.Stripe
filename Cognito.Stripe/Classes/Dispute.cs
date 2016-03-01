using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class Dispute : BaseObject
	{
		public override string Object { get { return "dispute"; } }

		[Cents]
		public decimal? Amount { get; set; }

		[JsonProperty("charge")]
		public string ChargeId { get; set; }

		public Currency Currency { get; set;}
		public string Reason { get; set; }
		public string Status { get; set; }

		[JsonProperty("balance_transactions")]
		public ICollection<BalanceTransaction> BalanceTransactions { get; set; }
		public DisputeEvidence Evidence { get; set; }
		
		[JsonProperty("evidence_details")]
		public EvidenceDetails Details { get; set; }

		[JsonProperty("is_charge_refundable")]
		public bool IsChargeRefundable { get; set; }

		[JsonProperty("evidence_due_by")]
		public DateTime? EvidenceDueData { get; set; }
	}
}
