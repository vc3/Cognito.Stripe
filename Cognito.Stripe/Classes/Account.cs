using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class Account : BaseObject
	{
		public override string Object { get { return "account"; } }

		[JsonProperty("charges_enabled")]
		public bool ChargesEnabled { get; set; }
		public Country Country { get; set; }
		[JsonProperty("currencies_supported")]
		public ICollection<Currency> Currencies { get; set; }
		[JsonProperty("default_currency")]
		public Currency DefaultCurrency { get; set; }
		[JsonProperty("details_submitted")]
		public bool DetailsSubmitted { get; set; }
		[JsonProperty("transfers_enabled")]
		public bool TransfersEnabled { get; set; }
		[JsonProperty("display_name")]
		public string DisplayName { get; set; }
		public string Email { get; set; }
		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }
		public string Timezone { get; set; }
	}
}
