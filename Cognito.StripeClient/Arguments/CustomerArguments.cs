using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cognito.Stripe;
using Cognito.Stripe.Helpers;
using System.Collections.Specialized;
using Cognito.Stripe.Classes;

namespace Cognito.StripeClient.Arguments
{
	public interface ISourceProvider
	{
		string Source { get; set; }

		CardArguments Card { get; set; }
		string CardToken { get; set; }

		BitcoinCreateArguments BitcoinArguments { get; set; }
		string BitcoinToken { get; set; }

		BankAccountTokenCreateArguments BankAccount { get; set; }
		string BankAccountToken { get; set; }
	}

	public class CustomerArguments
	{
		public static void CreateSourceToken(BaseClient client, ISourceProvider args)
		{
			if (args.Card != null)
			{
				var cardToken = client.Create<Token>(new CardTokenCreateArguments { Card = args.Card });
				args.Card = null;

				if (cardToken.Error == null)
					args.Source = cardToken.Id;
			}
			else if (args.BitcoinArguments != null)
			{
				var bcToken = client.Create<Token>(args.BitcoinArguments);
				args.BitcoinArguments = null;

				if (bcToken.Error == null)
					args.Source = bcToken.Id;
			}
			else if (!String.IsNullOrWhiteSpace(args.CardToken))
				args.Source = args.CardToken;
			else if (!String.IsNullOrWhiteSpace(args.BitcoinToken))
				args.Source = args.BitcoinToken;
			else if (!String.IsNullOrWhiteSpace(args.BankAccountToken))
				args.Source = args.BankAccountToken;
		}
	}

	public class CustomerCreateArguments : CreateArguments, ISourceProvider
	{
		[JsonProperty("plan")]
		public string PlanId { get; set; }
		public int? Quantity { get; set; }
		[JsonProperty("trial_end")]
		public DateTime? TrialEndDate { get; set; }

		[JsonIgnore]
		public Currency Currency { get; set; }

		[Currency]
		[JsonProperty("account_balance")]
		public decimal? AccountBalance { get; set; }

		public string Source { get; set; }

		[JsonProperty("coupon")]
		public string CouponCode { get; set; }
		public string Description { get; set; }
		public string Email { get; set; }

		[JsonIgnore]
		public CardArguments Card { get; set; }

		[JsonIgnore]
		public string CardToken { get; set; }

		[JsonIgnore]
		public BitcoinCreateArguments BitcoinArguments { get; set; }

		[JsonIgnore]
		public string BitcoinToken { get; set; }

		[JsonIgnore]
		public BankAccountTokenCreateArguments BankAccount { get; set; }

		[JsonIgnore]
		public string BankAccountToken { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "customers"; } }

		public override NameValueCollection ParseArguments(BaseClient client, NameValueCollection collection = null, string prefix = null)
		{
			CustomerArguments.CreateSourceToken(client, this);

			return base.ParseArguments(client, collection, prefix);
		}
	}

	public class CustomerGetArguments : GetArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "customers"; } }
	}

	public class CustomerUpdateArguments : UpdateArguments, ISourceProvider
	{
		[JsonProperty("default_source")]
		public string DefaultSourceId { get; set; }

		[JsonIgnore]
		public Currency Currency { get; set; }

		[Currency]
		[JsonProperty("account_balance")]
		public decimal? AccountBalance { get; set; }

		public string Source { get; set; }

		[JsonProperty("coupon")]
		public string CouponCode { get; set; }
		public string Description { get; set; }
		public string Email { get; set; }

		[JsonIgnore]
		public CardArguments Card { get; set; }

		[JsonIgnore]
		public string CardToken { get; set; }

		[JsonIgnore]
		public BitcoinCreateArguments BitcoinArguments { get; set; }

		[JsonIgnore]
		public string BitcoinToken { get; set; }

		[JsonIgnore]
		public BankAccountTokenCreateArguments BankAccount { get; set; }

		[JsonIgnore]
		public string BankAccountToken { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "customers"; } }

		public override NameValueCollection ParseArguments(BaseClient client, NameValueCollection collection = null, string prefix = null)
		{
			CustomerArguments.CreateSourceToken(client, this);

			return base.ParseArguments(client, collection, prefix);
		}
	}

	public class CustomerDeleteArguments : DeleteArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "customers"; } }
	}

	public class CustomerSearchArguments : SearchArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "customers"; } }
	}
}