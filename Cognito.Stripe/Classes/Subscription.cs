using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class Subscription : BaseObject
	{
		public override string Object { get { return "subscription"; } }

		[JsonProperty("application_fee_percent")]
		public decimal? ApplicationFeePercent { get; set; }

		[JsonProperty("cancel_at_period_end")]
		public bool CancelAtPeriodEnd { get; set; }

		[JsonProperty("canceled_at")]
		public DateTime? CanceledAt { get; set; }

		[JsonProperty("current_period_end")]
		public DateTime? CurrentPeriodEndDate { get; set; }

		[JsonProperty("current_period_start")]
		public DateTime? CurrentPeriodStartDate { get; set; }

		public Discount Discount { get; set; }

		[JsonProperty("ended_at")]
		public DateTime? EndDate { get; set; }

		public Plan Plan { get; set; }
		public int? Quantity { get; set; }
		public DateTime? Start { get; set; }
		public SubscriptionStatus Status { get; set; }

		[JsonProperty("tax_percent")]
		public decimal? TaxPercent { get; set; }
		
		[JsonProperty("trial_start")]
		public DateTime? TrialStartDate { get; set; }

		[JsonProperty("trial_end")]
		public DateTime? TrialEndDate { get; set; }

		[JsonIgnore]
		public bool IsTrialing { get { return TrialEndDate.GetValueOrDefault(DateTime.MinValue) > DateTime.UtcNow; } }
	}

	public enum SubscriptionStatus
	{ 
		trialing,
		active,
		past_due,
		canceled,
		unpaid
	}
}
