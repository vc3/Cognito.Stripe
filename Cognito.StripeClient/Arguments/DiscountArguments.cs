using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient.Arguments
{
	public class DeleteCustomerDiscountArguments : DeleteArguments
	{
		[JsonIgnore]
		public string CustomerId { get; set; }

		public override string GetEndpoint()
		{
			return String.Format("customers/{0}/discount", CustomerId);
		}
	}

	public class DeleteSubscriptionDiscountArguments : DeleteArguments
	{
		[JsonIgnore]
		public string CustomerId { get; set; }
		[JsonIgnore]
		public string SubscriptionId { get; set; }

		public override string GetEndpoint()
		{
			return String.Format("customers/{0}/subscriptions/{1}/discount", CustomerId, SubscriptionId);
		}
	}
}
