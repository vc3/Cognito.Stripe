using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe;
using Cognito.Stripe.Classes;
using Cognito.Stripe.Helpers;

namespace Cognito.StripeClient.Arguments
{
	public class CouponCreateArguments : CreateArguments
	{
		public string Id { get; set; }
		public CouponDuration Duration { get; set; }

		[Currency]
		public decimal? Amount { get; set; }

		public Currency Currency { get; set; }
		[JsonProperty("duration_in_months")]
		public int? DurationMonths { get; set; }
		[JsonProperty("max_redemptions")]
		public int? MaxRedemptions { get; set; }
		[JsonProperty("percent_off")]
		public int? PercentOff { get; set; }
		[JsonProperty("redeem_by")]
		public DateTime? RedeemByDate { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "coupons"; } }
	}

	public class CouponGetArguments : GetArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "coupons"; } }
	}

	public class CouponUpdateArguments : UpdateArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "coupons"; } }
	}

	public class CouponDeleteArguments : DeleteArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "coupons"; } }
	}

	public class CouponSearchArguments : ListArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "coupons"; } }
	}
}
