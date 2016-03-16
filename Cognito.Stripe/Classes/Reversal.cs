using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class Reversal : BaseObject
	{
		public override string Object { get { return "transfer_reversal"; } }

		public Currency Currency { get; set; }

		[Cents]
		public decimal? Amount { get; set; }

		[JsonProperty("balance_transaction")]
		public BalanceTransaction BalanceTransaction { get; set; }

		public Transfer Transfer { get; set; }
	}
}
