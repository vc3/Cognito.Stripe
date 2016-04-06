using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class ShippingMethod
	{
		public string Id { get; set; }

		public Currency Currency { get; set; }

		[Currency]
		public decimal? Amount { get; set; }

		[JsonProperty("delivery_estimate")]
		public DeliveryEstimate DeliveryEstimate { get; set; }

		public string Description { get; set; }
	}
}
