using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class Card : BaseObject
	{
		public override string Object { get { return "card"; } }

		public Account Account { get; set; }

		public string Brand { get; set; }
		public Country Country { get; set; }
		public Currency Currency { get; set; }

		[JsonProperty("cvc_check")]
		public string CVCCheck { get; set; }

		[JsonProperty("default_for_currency")]
		public bool DefaultForCurrency { get; set; }

		[JsonProperty("dynamic_last4")]
		public string LastFourDeviceNumber { get; set; }

		[JsonProperty("exp_month")]
		public int? ExpirationMonth { get; set; }
		[JsonProperty("exp_year")]
		public int? ExpirationYear { get; set; }

		public string Fingerprint { get; set; }

		[JsonProperty("funding")]
		public FundingType FundingType { get; set; }
		
		[JsonProperty("last4")]
		public string LastFourDigits { get; set; }
		public string Name { get; set; }
		public Recipient Recipient { get; set; }

		[JsonProperty("tokenization_method")]
		public string TokenizationMethod { get; set; }

		[JsonProperty("address_line1")]
		public string AddressLine1 { get; set; }
		[JsonProperty("address_line1_check")]
		public string AddressLine1Check { get; set; }
		[JsonProperty("address_line2")]
		public string AddressLine2 { get; set; }
		[JsonProperty("address_city")]
		public string City { get; set; }
		[JsonProperty("address_state")]
		public string State { get; set; }
		[JsonProperty("address_zip")]
		public string AddressZipCode { get; set; }
		[JsonProperty("address_zip_check")]
		public string AddressZipCodeCheck { get; set; }
		[JsonProperty("address_country")]
		public string AddressCountry { get; set; }
	}

	public enum FundingType
	{ 
		Credit,
		Debit,
		Prepaid,
		Unknown
	}
}
