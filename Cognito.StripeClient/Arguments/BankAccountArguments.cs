using Cognito.Stripe;
using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient.Arguments
{
	public class BankAccountGetArguments : GetArguments
	{
		[JsonIgnore]
		public string CustomerId { get; set; }

		public override string GetEndpoint()
		{
			return String.Format("customers/{0}/sources/{1}", CustomerId, Id);
		}
	}

	public class BankAccountVerifyArguments : UpdateArguments
	{
		[JsonIgnore]
		public string CustomerId { get; set; }

		[JsonIgnore]
		public Currency Currency { get; set; }

		[Currency]
		public ICollection<decimal> Amounts { get; set; }

		public override string GetEndpoint()
		{
			return String.Format("customers/{0}/sources/{1}/verify", CustomerId, Id);
		}
	}
}
