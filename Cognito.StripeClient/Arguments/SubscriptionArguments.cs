using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient.Arguments
{
	public class SubscriptionCreateArguments : CreateArguments
	{
		[JsonIgnore]
		public string CustomerId { get; set; }
		[JsonProperty("plan")]
		public string PlanId { get; set; }
		[JsonProperty("coupon")]
		public string CouponCode { get; set; }
		[JsonProperty("trial_end")]
		public DateTime? TrialEndDate { get; set; }
		[JsonProperty("billing_cycle_anchor")]
		public DateTime? StartDate { get; set; }
		[JsonProperty("card")]
		public string CardToken { get; set; }
		[JsonIgnore]
		public CardArguments CardArgs { get; set; }
		public int? Quantity { get; set; }
		[JsonProperty("application_fee_percent")]
		public decimal? ApplicationFeePercent { get; set; }
		[JsonProperty("tax_percent")]
		public decimal? TaxPercent { get; set; }

		[JsonIgnore]
		public string AccessToken { get; set; }

		public override string GetEndpoint() { return String.Format("customers/{0}/subscriptions", CustomerId); }
	}

	public class SubscriptionGetArguments : GetArguments
	{
		[JsonIgnore]
		public string CustomerId { get; set; }

		public override string GetEndpoint() { return String.Format("customers/{0}/subscriptions/{1}", CustomerId, Id); }
	}

	public class SubscriptionUpdateArguments : UpdateArguments
	{
		public SubscriptionUpdateArguments()
			: base()
		{
			Prorate = true;
		}

		[JsonIgnore]
		public string CustomerId { get; set; }
		public bool Prorate { get; set; }
		[JsonProperty("plan")]
		public string PlanId { get; set; }
		[JsonProperty("coupon")]
		public string CouponCode { get; set; }
		[JsonProperty("trial_end")]
		public DateTime? TrialEndDate { get; set; }
		[JsonProperty("billing_cycle_anchor")]
		public BillingCycleAnchor BillingCycleAnchor { get; set; }
		[JsonProperty("card")]
		public string CardToken { get; set; }
		[JsonIgnore]
		public CardArguments CardArgs { get; set; }
		public int? Quantity { get; set; }
		[JsonProperty("application_fee_percent")]
		public decimal? ApplicationFeePercent { get; set; }
		[JsonProperty("tax_percent")]
		public decimal? TaxPercent { get; set; }

		[JsonProperty("proration_date")]
		public DateTime? ProrationDate { get; set; }

		[JsonIgnore]
		public string AccessToken { get; set; }
		public override string GetEndpoint() { return String.Format("customers/{0}/subscriptions/{1}", CustomerId, Id); }
	}

	public class SubscriptionCancelArguments : DeleteArguments
	{
		[JsonIgnore]
		public string CustomerId { get; set; }

		[JsonProperty("at_period_end")]
		public bool CancelAtPeriodEnd { get; set; }

		public override string GetEndpoint() { return String.Format("customers/{0}/subscriptions/{1}", CustomerId, Id); }
	}

	public class SubscriptionSearchArguments : SearchArguments
	{
		[JsonIgnore]
		public string CustomerId { get; set; }
		public override string GetEndpoint() { return String.Format("customers/{0}/subscriptions", CustomerId); }
	}

	public enum BillingCycleAnchor
	{ 
		now,
		unchanged
	}
}
