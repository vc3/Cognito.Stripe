using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe;
using Cognito.Stripe.Helpers;
using System.Collections.Specialized;
using Cognito.Stripe.Classes;

namespace Cognito.StripeClient.Arguments
{
	public class ChargeCreateArguments : CreateArguments
	{
		private string token;
		private CardArguments card;
		private BitcoinCreateArguments bitcoinReceiver;
		
		[Currency]
		public decimal? Amount { get; set; }
		public Currency Currency { get; set; }
		[JsonProperty("customer")]
		public string CustomerId { get; set; }
		public string Source { get { return token; } set { if (!String.IsNullOrWhiteSpace(value)) { card = null; bitcoinReceiver = null; } token = value; } }
		[JsonIgnore]
		public CardArguments Card { get { return card; } set { if (value != null) token = null; card = value; } }
		[JsonIgnore]
		public BitcoinCreateArguments BitcoinReceiver { get { return bitcoinReceiver; } set { if (value != null) token = null; bitcoinReceiver = value; } }		
		public string Description { get; set; }
		public bool Capture { get; set; }
		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }
		[JsonProperty("receipt_email")]
		public string ReceiptEmail { get; set; }

		[Currency]
		[JsonProperty("application_fee")]
		public decimal? ApplicationFee { get; set; }
		
		public ShippingArguments Shipping { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "charges"; } }

		public override NameValueCollection ParseArguments(BaseClient client, NameValueCollection collection = null, string prefix = null)
		{
			if (Card != null)
			{
				var cardToken = client.Create<Token>(new CardTokenCreateArguments { Card = Card });
				Card = null;

				if (cardToken.Error == null)
					Source = cardToken.Id;
			}
			else if (BitcoinReceiver != null)
			{
				var bcToken = client.Create<Token>(BitcoinReceiver);
				BitcoinReceiver = null;

				if (bcToken.Error == null)
					Source = bcToken.Id;
			}

			return base.ParseArguments(client, collection, prefix);
		}
	}

	public class ChargeCaptureArguments : CreateArguments
	{
		[JsonIgnore]
		public string ChargeId { get; set; }
		[JsonIgnore]
		public Currency Currency { get; set; }
		[Currency]
		public decimal? Amount { get; set; }
		[JsonProperty("receipt_email")]
		public string ReceiptEmail { get; set; }
		[Currency]
		[JsonProperty("application_fee")]
		public decimal? ApplicationFee { get; set; }

		public override string GetEndpoint()
		{
			return String.Format("charges/{0}/capture", ChargeId);
		}
	}

	public class ChargeUpdateArguments : UpdateArguments
	{
		public string Description { get; set; }

		[JsonProperty("fraud_details")]
		public Dictionary<string, string> FraudDetails { get; set; }

		[JsonProperty("receipt_email")]
		public string ReceiptEmail { get; set; }
		
		public ShippingArguments Shipping { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "charges"; } }
	}

	public class ChargeGetArguments : GetArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "charges"; } }

		[JsonIgnore]
		public bool ExpandInvoice { set { ToggleExpandedProperty(value, "invoice"); } }

		[JsonIgnore]
		public bool ExpandInvoiceCharge { set { ToggleExpandedProperty(value, "invoice.charge"); } }

		[JsonIgnore]
		public bool ExpandCustomer { set { ToggleExpandedProperty(value, "customer"); } }

		[JsonIgnore]
		public bool ExpandApplicationFee { set { ToggleExpandedProperty(value, "application_fee"); } }

		[JsonIgnore]
		public bool ExpandBalanceTransaction { set { ToggleExpandedProperty(value, "balance_transaction"); } }

		[JsonIgnore]
		public bool ExpandDestination { set { ToggleExpandedProperty(value, "destination"); } }

		[JsonIgnore]
		public bool ExpandOrder { set { ToggleExpandedProperty(value, "order"); } }

		[JsonIgnore]
		public bool ExpandTransfer { set { ToggleExpandedProperty(value, "transfer"); } }
	}

	public class ChargeSearchArguments : SearchArguments
	{
		[JsonProperty("customer")]
		public string CustomerId { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "charges"; } }

		[JsonIgnore]
		public bool ExpandInvoice { set { ToggleExpandedProperty(value, "data.invoice"); } }

		[JsonIgnore]
		public bool ExpandInvoiceCharge { set { ToggleExpandedProperty(value, "data.invoice.charge"); } }

		[JsonIgnore]
		public bool ExpandCustomer { set { ToggleExpandedProperty(value, "data.customer"); } }

		[JsonIgnore]
		public bool ExpandApplicationFee { set { ToggleExpandedProperty(value, "data.application_fee"); } }

		[JsonIgnore]
		public bool ExpandBalanceTransaction { set { ToggleExpandedProperty(value, "data.balance_transaction"); } }

		[JsonIgnore]
		public bool ExpandDestination { set { ToggleExpandedProperty(value, "data.destination"); } }

		[JsonIgnore]
		public bool ExpandOrder { set { ToggleExpandedProperty(value, "data.order"); } }

		[JsonIgnore]
		public bool ExpandTransfer { set { ToggleExpandedProperty(value, "data.transfer"); } }
	}
}
