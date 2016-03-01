using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class ShippingInfo : BaseObject
	{
		[JsonProperty("name")]
		public string RecipientName { get; set; }
		[JsonProperty("phone")]
		public string PhoneNumber { get; set; }
		public Address Address { get; set; }
	}
}
