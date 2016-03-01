using Cognito.Stripe.Classes;
using Cognito.StripeClient.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient.Clients
{
	public class InvoiceClient : BaseClient<Invoice>
	{
		public InvoiceClient(string apiKey, string baseUrl = "", APIVersion version = APIVersion.v1)
			: base(apiKey, baseUrl, version)
		{
		}

		public Invoice GetUpcomingInvoice(InvoiceUpcomingArguments args)
		{
			return ProcessRequest<Invoice>(CreateAPIRequest(args.GetEndpoint())
				.WithQueryStringArgs(args.ParseArguments(this)), RequestMethod.Get);
		}
	}
}
