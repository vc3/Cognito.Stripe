using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class Plan : BaseObject
	{
		public override string Object { get { return "plan"; } }

		public Currency Currency { get; set;}

		[Cents]
		public decimal? Amount { get; set; }

		public PlanInterval Interval { get; set; }
		[JsonProperty("interval_count")]
		public int? IntervalCount { get; set; }
		public string Name { get; set; }
		[JsonProperty("trial_period_days")]
		public int? TrialPeriodDays { get; set; }
		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }
	}

	public enum PlanInterval
	{ 
		day,
		week,
		month,
		year
	}
}
