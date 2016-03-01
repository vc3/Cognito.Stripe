using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe;

namespace Cognito.StripeClient.Arguments
{
	public class AddressArguments : BaseArguments
	{
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		[JsonProperty("postal_code")]
		public string PostalCode { get; set; }
		public Country Country { get; set;  }
	}
}
