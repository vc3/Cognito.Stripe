using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class EntityOwner
	{
		public Address Address { get; set; }

		[JsonProperty("dob")]
		public DateTime? DateofBirth { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("last_name")]
		public string LastName { get; set; }

		public Verification Verification { get; set; }
	}
}
