using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class DeliveryEstimate
	{
		public string Date { get; set; }
		public string Earliest { get; set; }
		public string Latest { get; set; }
	}

	public enum DeliveryEstimateType
	{
		Range,
		Exact
	}
}
