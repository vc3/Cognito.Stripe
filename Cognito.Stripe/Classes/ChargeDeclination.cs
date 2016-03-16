using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class ChargeDeclination
	{
		[JsonProperty("avs_failure")]
		public bool AVSFailure { get; set; }

		[JsonProperty("cvc_failure")]
		public bool CVCFailure { get; set; }
	}
}
