using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class Token : BaseObject
	{
		public override string Object { get { return "token"; } }

		public TokenType Type { get; set; }
		public bool Used { get; set; }
		public Card Card { get; set; }
		[JsonProperty("bank_account")]
		public BankAccount BankAccount { get; set; }
	}

	public enum TokenType
	{ 
		card,
		bank_account
	}
}