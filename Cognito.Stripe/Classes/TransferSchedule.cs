using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class TransferSchedule
	{
		[JsonProperty("delay_days")]
		public int DelayDays { get; set; }

		public TransferInterval Interval { get; set; }

		[JsonProperty("monthly_anchor")]
		public int MonthlyAnchor { get; set; }

		[JsonProperty("weekly_anchor")]
		public string WeeklyAnchor { get; set; }
	}

	public enum TransferInterval
	{ 
		Manual,
		Daily,
		Weekly,
		Monthly
	}
}
