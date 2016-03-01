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

		public RecipientType Type { get; set; }
		[JsonProperty("active_account")]
		public Account ActiveAccount { get; set; }
		public string Description { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public StripeList<Card> Cards { get; set; }
		[JsonProperty("default_card")]
		public string DefaultCardId { get; set; }
	}

	public enum RecipientType
	{ 
		Individual,
		Corporation
	}
}