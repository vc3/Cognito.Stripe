using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class CountrySpecification : BaseObject
	{
		public override string Object { get { return "country_spec"; } }

		[JsonProperty("default_currency")]
		public Currency DefaultCurrency { get; set; }

		[JsonProperty("supported_bank_account_currencies")]
		public DynamicHash<Currency, ICollection<Country>> SupportedBankAccountCurrencies { get; set; }

		[JsonProperty("supported_payment_currencies")]
		public ICollection<Currency> SupportedPaymentCurrencies { get; set; }

		[JsonProperty("supported_payment_methods")]
		public ICollection<PaymentMethod> SupportedPaymentMethods { get; set; }

		[JsonProperty("verification_fields")]
		public CountrySpecificVerificationFields VerificationFields { get; set; }
	}

	public class CountrySpecificVerificationFields
	{
		public VerificationFields Individual { get; set; }
		public VerificationFields Company { get; set; }
	}

	public class DynamicHash<TKey, TValue>
		where TKey : Lookup 
	{
		public IDictionary<TKey, TValue> HashObject { get; set; }
	}

	public enum PaymentMethod
	{ 
		ACH,
		AliPay,
		Bitcoin,
		Card,
		Stripe
	}
}
