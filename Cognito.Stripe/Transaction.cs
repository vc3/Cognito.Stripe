using Cognito.Stripe.Classes;
using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe
{
	public class Transaction : BaseObject
	{
		public Currency Currency { get; set; }

		[Currency]
		public decimal? Amount { get; set; }

		[Currency]
		[JsonProperty("amount_refunded")]
		public decimal? AmountRefunded { get; set; }

		[JsonProperty("application_fee")]
		public ApplicationFee ApplicationFee { get; set; }

		[JsonProperty("balance_transaction")]
		public BalanceTransaction BalanceTransaction { get; set; }

		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }
	}
}
