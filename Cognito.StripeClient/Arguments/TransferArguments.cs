using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe;
using Cognito.Stripe.Classes;
using Cognito.Stripe.Helpers;

namespace Cognito.StripeClient.Arguments
{
	public class TransferCreateArguments : CreateArguments
	{
		[Cents]
		public decimal? Amount { get; set; }

		public Currency Currency { get; set; }

		[JsonProperty("recipient")]
		public string RecipientId { get; set; }

		public string Description { get; set; }

		[JsonProperty("bank_account")]
		public string BankAccountId { get; set; }
		[JsonProperty("card")]
		public string CardId { get; set; }
		
		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "transfers"; } }
	}

	public class TransferGetArguments : GetArguments
	{

		[JsonIgnore]
		public override string ObjectName { get { return "transfers"; } }
	}

	public class TransferUpdateArguments : UpdateArguments
	{
		public string Description { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "transfers"; } }
	}

	public class TransferCancelArguments : UpdateArguments
	{

		[JsonIgnore]
		public override string ObjectName { get { return "transfers"; } } 
	}

	public class TransferSearchArguments : SearchArguments
	{
		[JsonProperty("date[gt]")]
		public DateTime? TransferDateAfter { get; set; }
		[JsonProperty("date[gte]")]
		public DateTime? TransferDateOnOrAfter { get; set; }
		[JsonProperty("date[lt]")]
		public DateTime? TransferDateBefore { get; set; }
		[JsonProperty("date[lte]")]
		public DateTime? TransferDateOnOrBefore { get; set; }

		[JsonProperty("recipient")]
		public string RecipientId { get; set; }
		public TransferStatus Status { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "transfers"; } }
	}
}
