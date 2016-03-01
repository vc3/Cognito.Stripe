using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe;

namespace Cognito.StripeClient.Arguments
{
	public class ShippingArguments : BaseArguments
	{
		public AddressArguments Address { get; set; }
		[JsonProperty("name")]
		public string RecipientName { get; set; }
		[JsonProperty("phone")]
		public string PhoneNumber { get; set; }
		[JsonProperty("tracking_number")]
		public string TrackingNumber { get; set; }
		public string Carrier { get; set; }
	}
}
