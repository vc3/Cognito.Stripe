using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class BankAccount : PaymentSource
	{
		public override string Object { get { return "bank_account"; } }

		public Account Account { get; set; }

		[JsonProperty("account_holder_name")]
		public string AccountHolderName { get; set; }

		[JsonProperty("account_holder_type")]
		public AccountHolderType AccountHolderType { get; set; }
		
		[JsonProperty("bank_name")]
		public string BankName { get; set; }

		public Country Country { get; set; }

		[JsonProperty("default_for_currency")]
		public bool CurrencyDefault { get; set; }
		
		[JsonProperty("last4")]
		public string LastFourDigits { get; set; }

		[JsonProperty("routing_number")]
		public string RoutingNumber { get; set; }

		public string Status { get; set; }
	}

	public enum BankAccountStatus
	{ 
		New,
		Validated,
		Verified,
		Verification_Failed,
		Errored
	}

	public enum AccountHolderType
	{ 
		Individual,
		Company
	}
}