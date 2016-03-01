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
	public class PlanCreateArguments : CreateArguments
	{
		public string Id { get; set; }
		public Currency Currency { get; set; }
		[Cents]
		public decimal? Amount { get; set; }
		public PlanInterval Interval { get; set; }
		[JsonProperty("interval_count")]
		public int IntervalCount { get; set; }
		[JsonProperty("trial_period_days")]
		public int TrialPeriodDays { get; set; }
		public string Name { get; set; }
		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }
		[JsonIgnore]
		public override string ObjectName { get { return "plans"; } }
	}

	public class PlanGetArguments : GetArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "plans"; } }
	}

	public class PlanUpdateArguments : UpdateArguments
	{
		public string Name { get; set; }
		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }
		[JsonIgnore]
		public override string ObjectName { get { return "plans"; } }
	}

	public class PlanDeleteArguments : DeleteArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "plans"; } }
	}

	public class PlanSearchArguments : SearchArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "plans"; } }
	}
}
