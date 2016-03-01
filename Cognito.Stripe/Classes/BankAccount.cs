using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class BankAccount : BaseObject
	{
		[JsonProperty("country")]
		public string CountryCode { get; set; }

		public Currency Currency { get; set;}
		
		[JsonProperty("last4")]
		public string LastFourDigits { get; set; }
		public string Status { get; set; }
		
		[JsonProperty("bank_name")]
		public string BankName { get; set; }
		public string Fingerprint { get; set; }
	}

	public enum BankAccountStatus
	{ 
		New,
		Validated,
		Verified,
		Errored
	}
}