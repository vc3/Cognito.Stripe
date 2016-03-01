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
	}

	public class ApplicationFeeSearchArguments : SearchArguments
	{
		[JsonProperty("charge")]
		public string ChargeId { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "application_fees"; } }
	}
}