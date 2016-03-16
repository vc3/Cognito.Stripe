using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class Discount : BaseObject
	{
		public override string Object { get { return "discount"; } }

		public Coupon Coupon { get; set; }

		[JsonProperty("start")]
		public DateTime? StartDate { get; set; }

		[JsonProperty("end")]
		public DateTime? EndDate { get; set; }

		public Subscription Subscription { get; set; }
	}
}
