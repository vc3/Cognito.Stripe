using Cognito.Stripe.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class TermsOfServiceAcceptance
	{
		[JsonConverter(typeof(DateTimeConverter))]
		public DateTime? Date { get; set; }

		[JsonProperty("ip")]
		public string IPAddress { get; set; }

		[JsonProperty("user_agent")]
		public string UserAgent { get; set; }
	}
}
