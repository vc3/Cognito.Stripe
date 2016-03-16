using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class Recipient : BaseObject
	{
		public override string Object { get { return "recipient"; } }

		[JsonProperty("active_account")]
		public BankAccount ActiveAccount { get; set; }

		public StripeList<Card> Cards { get; set; }

		[JsonProperty("default_card")]
		public Card DefaultCard { get; set; }

		public string Description { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public RecipientType Type { get; set; }

		[JsonProperty("migrated_to")]
		public Account MigratedAccount { get; set; }
	}

	public enum RecipientType
	{ 
		Individual,
		Corporation
	}
}