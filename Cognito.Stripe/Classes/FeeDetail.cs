using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class FeeDetail
	{
		public Currency Currency { get; set; }

		[Currency]
		public decimal? Amount { get; set; }

		public string Description { get; set; }

		[JsonProperty("application")]
		public string ApplicationId { get; set; }

		public FeeType Type { get; set; }
	}

	public enum FeeType
	{
		Application_Fee,
		Stripe_Fee,
		Tax
	}
}
