using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class Invoice : BaseObject
	{
		public override string Object { get { return "invoice"; } }

		public Currency Currency { get; set;}

		[Cents]
		[JsonProperty("amount_due")]
		public decimal? AmountDue { get; set; }

		[Cents]
		[JsonProperty("application_fee")]
		public decimal? ApplicationFeeAmount { get; set; }
		
		[JsonProperty("attempt_count")]
		public int? NumberOfAttempts { get; set; }
		
		public bool Attempted { get; set; }		
		public Charge Charge { get; set; }
		public bool Closed { get; set; }
		public DateTime? Date { get; set; }
		public string Description { get; set; }
		public Discount Discount { get; set; }

		[Cents]
		[JsonProperty("ending_balance")]
		public decimal? EndingBalance { get; set; }

		[JsonProperty("forgiven")]
		public bool IsForgiven { get; set; }

		[JsonProperty("lines")]
		public StripeList<LineItem> LineItems { get; set; }

		[JsonProperty("next_payment_attempt")]
		public DateTime? NextPaymentAttemptOn { get; set; }
		
		public bool Paid { get; set; }

		[JsonProperty("period_end")]
		public DateTime? PeriodEndDate { get; set; }
		[JsonProperty("period_start")]
		public DateTime? PeriodStartDate { get; set; }
		
		[JsonProperty("receipt_number")]
		public string ReceiptNumber { get; set; }

		[Cents]
		[JsonProperty("starting_balance")]
		public decimal? StartingBalance { get; set; }

		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }

		public Subscription Subscription { get; set; }

		[JsonProperty("subscription_proration_date")]
		public DateTime? ProrationDate { get; set; }

		[Cents]
		public decimal? SubTotal { get; set; }

		[Cents]
		[JsonProperty("tax")]
		public decimal? TaxAmount { get; set; }

		[JsonProperty("tax_percent")]
		public decimal? TaxPercent { get; set; }

		[Cents]
		public decimal? Total { get; set; }

		[JsonProperty("webhooks_delivered_at")]
		public DateTime? WebhooksDeliveredOn { get; set; }
	}
}