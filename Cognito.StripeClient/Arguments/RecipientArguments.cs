using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe.Classes;
using System.Collections.Specialized;

namespace Cognito.StripeClient.Arguments
{
	public class RecipientArguments
	{ 
		public static void CreateToken(BaseClient client, ISourceProvider args)
		{			
			if (args.Card != null)
			{
				var cardToken = client.Create<Token>(new CardTokenCreateArguments { Card = args.Card });
				args.Card = null;

				if (cardToken.Error == null)
					args.CardToken = cardToken.Id;
			}

			if (args.BankAccount != null)
			{
				var accountToken = client.Create<Token>(args.BankAccount);
				args.BankAccount = null;

				if (accountToken.Error == null)
					args.BankAccountToken = accountToken.Id;
			}
		}
	}

	public class RecipientCreateArguments : CreateArguments, ISourceProvider
	{
		public string Name { get; set; }
		[JsonProperty("tax_id")]
		public string TaxId { get; set; }

		public string Email { get; set; }
		public string Description { get; set; }	
		public RecipientType Type { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "recipients"; } }

		[JsonIgnore]
		public string Source { get; set; }

		[JsonIgnore]
		public CardArguments Card { get; set; }

		[JsonProperty("card")]
		public string CardToken { get; set; }

		[JsonIgnore]
		public BitcoinCreateArguments BitcoinArguments { get; set; }

		[JsonIgnore]
		public string BitcoinToken { get; set; }

		[JsonIgnore]
		public BankAccountTokenCreateArguments BankAccount { get; set; }

		[JsonProperty("bank_account")]
		public string BankAccountToken { get; set; }

		public override NameValueCollection ParseArguments(BaseClient client, NameValueCollection collection = null, string prefix = null)
		{
			RecipientArguments.CreateToken(client, this);

			return base.ParseArguments(client, collection, prefix);
		}
	}

	public class RecipientGetArguments : GetArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "recipients"; } }
	}

	public class RecipientUpdateArguments : UpdateArguments, ISourceProvider
	{
		public string Name { get; set; }
		[JsonProperty("tax_id")]
		public string TaxId { get; set; }

		public string Email { get; set; }
		public string Description { get; set; }	
		[JsonProperty("default_card")]
		public string DefaultCardId { get; set; }

		[JsonIgnore]
		public string Source { get; set; }

		[JsonIgnore]
		public CardArguments Card { get; set; }

		[JsonProperty("card")]
		public string CardToken { get; set; }

		[JsonIgnore]
		public BitcoinCreateArguments BitcoinArguments { get; set; }

		[JsonIgnore]
		public string BitcoinToken { get; set; }

		[JsonIgnore]
		public BankAccountTokenCreateArguments BankAccount { get; set; }

		[JsonProperty("bank_account")]
		public string BankAccountToken { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "recipients"; } }

		public override NameValueCollection ParseArguments(BaseClient client, NameValueCollection collection = null, string prefix = null)
		{
			RecipientArguments.CreateToken(client, this);

			return base.ParseArguments(client, collection, prefix);
		}
	}

	public class RecipientDeleteArguments : DeleteArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "recipients"; } }
	}

	public class RecipientSearchArguments : SearchArguments
	{
		public RecipientType Type { get; set; }
		public bool? Verified { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "recipients"; } }
	}
}
