using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe;
using Cognito.Stripe.Helpers;

namespace Cognito.StripeClient.Arguments
{
	public class ApplicationFeeRefundCreateArguments : CreateArguments
	{
		[JsonIgnore]
		public string FeeId { get; set; }

		[JsonIgnore]
		public Currency Currency { get; set; }

		[Currency]
		public decimal? Amount { get; set; }

		public override string GetEndpoint()
		{
			return String.Format("application_fees/{0}/refunds", FeeId);
		}
	}

	public class ApplicationFeeRefundGetArguments : GetArguments
	{
		[JsonIgnore]
		public string FeeId { get; set; }

		[JsonIgnore]
		public bool ExpandBalanceTransaction
		{
			set
			{
				ToggleExpandedProperty(value, "balance_transaction");
			}
		}

		public override string GetEndpoint()
		{
			return String.Format("application_fees/{0}/refunds/{1}", FeeId, Id);
		}
	}
	
	public class ApplicationFeeRefundUpdateArguments : UpdateArguments
	{
		[JsonIgnore]
		public string FeeId { get; set; }

		public override string GetEndpoint()
		{
			return String.Format("application_fees/{0}/refunds/{1}", FeeId, Id);
		}
	}

	public class ApplicationFeeRefundSearchArguments : SearchArguments
	{ 
		[JsonIgnore]
		public string FeeId { get; set; }

		[JsonIgnore]
		public bool ExpandBalanceTransaction
		{
			set
			{
				ToggleExpandedProperty(value, "data.balance_transaction");
			}
		}

		public override string GetEndpoint()
		{
			return String.Format("application_fees/{0}/refunds", FeeId);
		}
	}
}
