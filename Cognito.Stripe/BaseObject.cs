using Cognito.Stripe.Classes;
using Cognito.Stripe.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe
{
	public class BaseObject
	{
		public BaseObject() { Metadata = new Dictionary<string, string>(); }

		public string Id { get; set; }
		public virtual string Object { get { return ""; } }
		public bool LiveMode { get; set; }
		public Dictionary<string, string> Metadata { get; set; }
		public Error Error { get; set; }
		public bool Deleted { get; set; }
		public Customer Customer { get; set; }

		public bool HasError { get { return Error != null; } }

		public string ErrorMessage { get { return Error != null ? Error.Message : String.Empty; } }

		/// <summary>
		/// Gets or sets a flag indicating the object was fully loaded from the request.
		/// </summary>
		[JsonIgnore]
		public bool Loaded { get; set; }
	
		/// <summary>
		/// Gets or sets the DateTime representation of the date created
		/// This is used when serializing the object for use in a <see cref="StripeClient"/> call
		/// </summary>
		[JsonProperty("created")]
		[JsonConverter(typeof(DateTimeConverter))]
		public DateTime? DateCreated { get; set; }

		public static decimal GetDecimalFactor(Currency currency)
		{
			if (currency == null)
				return 2M;

			return Convert.ToDecimal(Math.Pow(10, currency.NumberOfDecimals));
		}

		public static decimal? GetAmount(decimal? amountNoDecimal, Currency currency)
		{
			return amountNoDecimal / BaseObject.GetDecimalFactor(currency);
		}

		public static int? GetAmountNoDecimal(decimal? amount, Currency currency)
		{
			return Decimal.ToInt32(amount.GetValueOrDefault(0M) * Convert.ToDecimal(Math.Pow(10, currency.NumberOfDecimals)));
		}

		internal static void ConvertAmounts(BaseObject baseObject)
		{
			throw new NotImplementedException();
		}
	}

	public class StripeList<T>
		where T : BaseObject
	{
		public string Object { get { return "list"; } }
		public string Url { get; set; }
		[JsonProperty("has_more")]
		public bool HasMore { get; set; }
		[JsonProperty("total_count")]
		public int TotalCount { get; set; }
		public ICollection<T> Data { get; set; }
	}
}
