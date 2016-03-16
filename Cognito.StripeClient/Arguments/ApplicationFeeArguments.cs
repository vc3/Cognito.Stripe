using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.StripeClient.Arguments
{
	public class ApplicationFeeGetArgments : GetArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "application_fees"; } }

		[JsonIgnore]
		public bool ExpandCharge
		{
			set
			{
				ToggleExpandedProperty(value, "charge");
			}
		}

		[JsonIgnore]
		public bool ExpandBalanceTransaction
		{
			set
			{
				ToggleExpandedProperty(value, "balance_transaction");
			}
		}
	}

	public class ApplicationFeeSearchArguments : SearchArguments
	{
		[JsonProperty("charge")]
		public string ChargeId { get; set; }

		[JsonIgnore]
		public bool ExpandCharge
		{
			set
			{
				ToggleExpandedProperty(value, "data.charge");
			}
		}

		[JsonIgnore]
		public bool ExpandBalanceTransaction
		{
			set
			{
				ToggleExpandedProperty(value, "data.balance_transaction");
			}
		}

		[JsonIgnore]
		public override string ObjectName { get { return "application_fees"; } }
	}
}