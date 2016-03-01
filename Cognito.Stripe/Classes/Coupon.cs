using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class Coupon : BaseObject
	{
		public override string Object { get { return "coupon"; } }

		public CouponDuration Duration { get; set; }
		public Currency Currency { get; set;}

		[Cents]
		public decimal? Amount { get; set; }
		
		[JsonProperty("duration_in_months")]
		public int? DurationMonths { get; set; }
		[JsonProperty("max_redemptions")]
		public int? MaxRedemptions { get; set; }
		[JsonProperty("percent_off")]
		public int? PercentOff { get; set; }
		[JsonProperty("redeem_by")]
		public DateTime? RedeemByDate { get; set; }
		[JsonProperty("time_redeemed")]
		public int? NumberOfRedemptions { get; set; }
		public bool IsValid { get; set; }
	}

	public enum CouponDuration
	{ 
		forever,
		once,
		repeating
	}
}
