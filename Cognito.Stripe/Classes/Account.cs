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

		[JsonProperty("business_name")]
		public string BusinessName { get; set; }

		[JsonProperty("business_primary_color")]
		public string PrimaryColorCode { get; set; }

		[JsonProperty("business_url")]
		public string URL { get; set; }

		[JsonProperty("charges_enabled")]
		public bool ChargesEnabled { get; set; }

		public Country Country { get; set; }
		
		[JsonProperty("debit_negative_balances")]
		public bool DebitNegativeBalances { get; set; }

		[JsonProperty("decline_charges_on")]
		public ChargeDeclination DeclineChargesOn { get; set; }
		
		[JsonProperty("default_currency")]
		public Currency DefaultCurrency { get; set; }

		[JsonProperty("details_submitted")]
		public bool DetailsSubmitted { get; set; }

		[JsonProperty("display_name")]
		public string DisplayName { get; set; }

		public string Email { get; set; }

		public StripeList<ExternalAccount> ExternalAccounts { get; set; }

		[JsonProperty("legal_entity")]
		public LegalEntity LegalEntity { get; set; }

		public bool Managed { get; set; }

		[JsonProperty("product_description")]
		public string ProductDescription { get; set; }
		
		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }

		[JsonProperty("support_email")]
		public string SupportEmail { get; set; }

		[JsonProperty("support_phone")]
		public string SupportPhone { get; set; }

		[JsonProperty("support_url")]
		public string SupportUrl { get; set; }

		public string Timezone { get; set; }

		[JsonProperty("tos_acceptance")]
		public TermsOfServiceAcceptance TermsOfServiceAcceptance { get; set; }

		[JsonProperty("transfer_scheduled")]
		public TransferSchedule TransferSchedule { get; set; }

		[JsonProperty("transfers_enabled")]
		public bool TransfersEnabled { get; set; }

		public AccountVerification Verification { get; set; }
	}
}
