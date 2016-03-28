using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class BitcoinReceiver : PaymentSource
	{
		public override string Object { get { return "bitcoin_receiver"; } }

		public bool Active { get; set; }
		
		[Cents]
		public decimal? Amount { get; set; }
		[Cents]
		[JsonProperty("amount_received")]
		public decimal? AmountReceived { get; set; }
		
		[Cents]
		[JsonProperty("bitcoin_amount")]
		public decimal? BitcoinAmount { get; set; }
		[Cents]
		[JsonProperty("bitcoin_amount_received")]
		public decimal? BitcoinAmountReceived { get; set; }

		[JsonProperty("bitcoin_uri")]
		public string BitcoinUri { get; set; }

		public string Description { get; set; }

		public string Email { get; set; }

		public bool Filled { get; set; }

		[JsonProperty("inbound_address")]
		public string InboundAddress { get; set; }

		[JsonProperty("payment")]
		public string PaymentId { get; set; }

		[JsonProperty("refund_address")]
		public string RefundAddress { get; set; }

		public StripeList<BitcoinTransaction> Transaction { get; set; }

		[JsonProperty("uncaptured_funds")]
		public bool UncapturedFunds { get; set; }
	}
}
