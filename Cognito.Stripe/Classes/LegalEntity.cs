using Cognito.Stripe.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class LegalEntity
	{
		[JsonProperty("additional_owners")]
		public ICollection<EntityOwner> AdditionalOwners { get; set; }

		public Address Address { get; set; }
		
		[JsonProperty("address_kana")]
		public AddressVariation AddressKana { get; set; }

		[JsonProperty("address_kanji")]
		public AddressVariation AddressKanji { get; set; }

		[JsonProperty("business_name")]
		public string BusinessName { get; set; }

		[JsonProperty("business_name_kana")]
		public string BusinessNameKana { get; set; }

		[JsonProperty("business_name_kanji")]
		public string BusinessNameKanji { get; set; }

		[JsonProperty("business_tax_id_provided")]
		public bool BusinessTaxIdProvided { get; set; }

		[JsonProperty("dob")]
		[JsonConverter(typeof(DateOfBirthConverter))]
		public DateTime DateOfBirth { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("first_name_kana")]
		public string FirstNameKana { get; set; }

		[JsonProperty("first_name_kanji")]
		public string FirstNameKanji { get; set; }

		public string Gender { get; set; }

		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("last_name_kana")]
		public string LastNameKana { get; set; }

		[JsonProperty("last_name_kanji")]
		public string LastNameKanji { get; set; }

		[JsonProperty("maiden_name")]
		public string MaidenName { get; set; }

		[JsonProperty("personal_address_kana")]
		public Address PersonalAddress { get; set; }

		[JsonProperty("personal_address_kana")]
		public AddressVariation PersonalAddressKana { get; set; }

		[JsonProperty("personal_address_kanji")]
		public AddressVariation PersonalAddressKanji { get; set; }

		[JsonProperty("personal_id_number_provided")]
		public bool PersonalIdNumberProvided { get; set; }

		[JsonProperty("phone_number")]
		public string PhoneNumber { get; set; }

		[JsonProperty("ssn_last_4_provided")]
		public bool SSNLast4Provided { get; set; }

		public string Type { get; set; }

		public Verification Verification { get; set; }
	}
}
