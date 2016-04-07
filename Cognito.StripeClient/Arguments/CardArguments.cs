using Cognito.Stripe;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient.Arguments
{
	public class CardArguments : BaseArguments
	{
		public string Number { get; set; }
		[JsonProperty("exp_month")]
		public int? ExpirationMonth { get; set; }
		[JsonProperty("exp_year")]
		public int? ExpirationYear { get; set; }
		public string CVC { get; set; }
		public string Name { get; set; }
		[JsonProperty("address_line1")]
		public string AddressLine1 { get; set; }
		[JsonProperty("address_line2")]
		public string AddressLine2 { get; set; }
		[JsonProperty("address_city")]
		public string City { get; set; }
		[JsonProperty("address_state")]
		public string State { get; set; }
		[JsonProperty("address_zip")]
		public string ZipCode { get; set; }
		[JsonProperty("address_country")]
		public Country Country { get; set; }
	}

	public class CardCreateArguments : CreateArguments
	{
		private string token;
		private CardArguments card;

		[JsonIgnore]
		public string CustomerId { get; set; }

		[JsonProperty("card")]
		public string Token { get { return token; } set { if (!String.IsNullOrWhiteSpace(value)) card = null; token = value; } }
		public CardArguments Card { get { return card; } set { if (value != null) token = null; card = value; } }

		public override string GetEndpoint()
		{
			return String.Format("customers/{0}/sources", CustomerId);
		}

		public string Source { get; set; }
	}

	public class CardGetArguments : GetArguments
	{
		[JsonIgnore]
		public string CustomerId { get; set; }

		public override string GetEndpoint()
		{
			return String.Format("customers/{0}/sources/{1}", CustomerId, Id);
		}
	}

	public class CardUpdateArguments : UpdateArguments
	{
		[JsonIgnore]
		public string CustomerId { get; set; }

		[JsonProperty("address_line1")]
		public string AddressLine1 { get; set; }
		[JsonProperty("address_line2")]
		public string AddressLine2 { get; set; }
		[JsonProperty("address_city")]
		public string City { get; set; }
		[JsonProperty("address_state")]
		public string State { get; set; }
		[JsonProperty("address_zip")]
		public string AddressZipCode { get; set; }
		[JsonProperty("address_country")]
		public Country AddressCountry { get; set; }
		public string Name { get; set; }
		[JsonProperty("exp_month")]
		public int ExpirationMonth { get; set; }
		[JsonProperty("exp_year")]
		public int ExpirationYear { get; set; }

		public override string GetEndpoint()
		{
			return String.Format("customers/{0}/sources/{1}", CustomerId, Id);
		}
	}

	public class CardDeleteArguments : DeleteArguments
	{
		[JsonIgnore]
		public string CustomerId { get; set; }

		public override string GetEndpoint()
		{
			return String.Format("customers/{0}/sources/{1}", CustomerId, Id);
		}
	}

	public class CardSearchArguments : ListArguments
	{
		[JsonIgnore]
		public string CustomerId { get; set; }

		public override string GetEndpoint()
		{
			return String.Format("customers/{0}/sources?object=card", CustomerId);
		}
	}
}
