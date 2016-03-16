using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class BitcoinTransaction : BaseObject
	{
		public override string Object { get { return "bitcoin.transaction" ; } }

		public Currency Currency { get; set; }

		[Cents]
		public decimal? Amount { get; set; }

		[Cents]
		[JsonProperty("bitcoin_amount")]
		public decimal? BitcoinAmount { get; set; }

		public BitcoinReceiver Receiver { get; set; }
	}
}
