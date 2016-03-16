using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	/// <summary>
	/// Represents all properties that could be provided by Stripe in the Source property of a customer or charge
	/// Combines properties for <see cref="Card"/> and <see cref="BitcoinReceiver"/>
	/// </summary>
	public class Source : BaseObject
	{
		[JsonIgnore]
		public override string Object { get { return base.Object; } }

		public Currency Currency { get; set; }

		public string Fingerprint { get; set; }
		
		[JsonProperty("last4")]
		public string LastFourDigits { get; set; }

		public Country Country { get; set; }

		[JsonProperty("object")]
		public string ObjectType { get; set; }

		public string Name { get; set; }

		public Account Account { get; set; }

		#region Card Properties

		public string Brand { get; set; }

		[JsonProperty("cvc_check")]
		public string CVCCheck { get; set; }

		[JsonProperty("dynamic_last4")]
		public string LastFourDeviceNumber { get; set; }

		[JsonProperty("exp_month")]
		public int? ExpirationMonth { get; set; }
		[JsonProperty("exp_year")]
		public int? ExpirationYear { get; set; }
		
		[JsonProperty("funding")]
		public FundingType FundingType { get; set; }

		public Recipient Recipient { get; set; }

		[JsonProperty("tokenization_method")]
		public string TokenizationMethod { get; set; }

		[JsonProperty("address_line1")]
		public string AddressLine1 { get; set; }
		[JsonProperty("address_line1_check")]
		public string AddressLine1Check { get; set; }
		[JsonProperty("address_line2")]
		public string AddressLine2 { get; set; }
		[JsonProperty("address_city")]
		public string City { get; set; }
		[JsonProperty("address_state")]
		public string State { get; set; }
		[JsonProperty("address_zip")]
		public string AddressZipCode { get; set; }
		[JsonProperty("address_zip_check")]
		public string AddressZipCodeCheck { get; set; }
		[JsonProperty("address_country")]
		public string AddressCountry { get; set; }
		#endregion

		#region BitcoinReceiver Properties
		public bool Active { get; set; }
		[Cents]
		public decimal? Amount { get; set; }
		[Cents]
		[JsonProperty("amount_received")]
		public decimal? AmountReceived { get; set; }
		[Cents]
		[JsonProperty("bitcoin_amount")]
		public decimal? BitcoinAmount { get; set; }
		[JsonProperty("bitcoin_uri")]
		public string BitcoinUri { get; set; }
		public bool Filled { get; set; }
		[JsonProperty("inbound_address")]
		public string InboundAddress { get; set; }

		// Transaction

		[JsonProperty("uncaptured_funds")]
		public bool UncapturedFunds { get; set; }
		public string Description { get; set; }
		public string Email { get; set; }
		[JsonProperty("payment")]
		public string PaymentId { get; set; }
		[JsonProperty("refund_address")]
		public string RefundAddress { get; set; }
		#endregion

		#region BankAccount Properties

		[JsonProperty("bank_name")]
		public string BankName { get; set; }
		
		[JsonProperty("default_for_currency")]
		public bool CurrencyDefault { get; set; }
		
		public string Status { get; set; }
		
		[JsonProperty("routing_number")]
		public string RoutingNumber { get; set; }

		#endregion

		public static implicit operator Card(Source src)
		{
			return src == null || !String.Equals(src.ObjectType, "card", StringComparison.OrdinalIgnoreCase) ? null :
			new Card {
				Id = src.Id,
				LiveMode = src.LiveMode,
				Metadata = src.Metadata,
				Error = src.Error,
				Deleted = src.Deleted,
				DateCreated = src.DateCreated,
				Brand = src.Brand,
				ExpirationMonth = src.ExpirationMonth,
				ExpirationYear = src.ExpirationYear,
				Fingerprint = src.Fingerprint,
				LastFourDigits = src.LastFourDigits,
				AddressLine1 = src.AddressLine1,
				AddressLine1Check = src.AddressLine1Check,
				AddressLine2 = src.AddressLine2,
				City = src.City,
				State = src.State,
				AddressZipCode = src.AddressZipCode,
				AddressZipCodeCheck = src.AddressZipCodeCheck,
				AddressCountry = src.AddressCountry,
				Country = src.Country,
				Customer = src.Customer,
				CVCCheck = src.CVCCheck,
				LastFourDeviceNumber = src.LastFourDeviceNumber,
				Name = src.Name,
				Recipient = src.Recipient
			};
		}

		public static implicit operator BitcoinReceiver(Source src)
		{
			return src == null || !String.Equals(src.ObjectType, "bitcoin_receiver", StringComparison.OrdinalIgnoreCase) ? null :
			new BitcoinReceiver {
				Id = src.Id,
				LiveMode = src.LiveMode,
				Metadata = src.Metadata,
				Error = src.Error,
				Deleted = src.Deleted,
				DateCreated = src.DateCreated,
				Active = src.Active,
				Amount = src.Amount,
				AmountReceived = src.AmountReceived,
				BitcoinAmount = src.BitcoinAmount,
				BitcoinUri = src.BitcoinUri,
				Currency = src.Currency,
				Filled = src.Filled,
				InboundAddress = src.InboundAddress,
				UncapturedFunds = src.UncapturedFunds,
				Description = src.Description,
				Email = src.Email,
				PaymentId = src.PaymentId,
				RefundAddress = src.RefundAddress
			};
		}

		public static implicit operator BankAccount(Source src)
		{
			return src == null || !String.Equals(src.ObjectType, "bank_account", StringComparison.OrdinalIgnoreCase) ? null :
			new BankAccount
			{
				Id = src.Id,
				Country = src.Country,
				Fingerprint = src.Fingerprint,
				LastFourDigits = src.LastFourDigits,
				Name = src.Name,
				LiveMode = src.LiveMode,
				Metadata = src.Metadata,
				Error = src.Error,
				Deleted = src.Deleted,
				DateCreated = src.DateCreated,
				Currency = src.Currency,
				Account = src.Account,
				BankName = src.BankName,
				CurrencyDefault = src.CurrencyDefault,
				RoutingNumber = src.RoutingNumber,
				Status = src.Status
			};
		}
	}

	public enum SourceType
	{ 
		Card,
		Bank_Account,
		Bitcoin_Receiver,
		Alipay_Account
	}
}
