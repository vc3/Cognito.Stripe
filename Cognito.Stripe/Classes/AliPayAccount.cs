using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class AliPayAccount : PaymentSource
	{
		public override string Object { get { return "alipay_account"; } }

		[Currency]
		[JsonProperty("payment_amount")]
		public decimal Amount { get; set; }

		[JsonProperty("payment_currency")]
		public new Currency Currency { get; set; }

		public bool Reusable { get; set; }
		public bool Used { get; set; }
		public string Username { get; set; }
	}
}
