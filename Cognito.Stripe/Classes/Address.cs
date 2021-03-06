﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class Address
	{
		public string City { get; set; }
		public Country Country { get; set; }
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		[JsonProperty("postal_code")]
		public string PostalCode { get; set; }
		public string State { get; set; }
	}

	public class AddressVariation : Address
	{
		public string Town { get; set; }
	}
}
