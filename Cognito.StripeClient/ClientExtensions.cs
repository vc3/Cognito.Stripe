using Cognito.Stripe.Classes;
using Cognito.StripeClient.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient
{
	public static class ClientExtensions
	{
		public static Charge CaptureCharge(this APIClient client, ChargeCaptureArguments args, bool throwException = false)
		{
			return client.Create<Charge>(args, throwExceptions: throwException);
		}

		public static Invoice PayInvoice(this APIClient client, InvoicePaymentArguments args, bool throwException = false)
		{
			return client.Update<Invoice>(args, throwExceptions: throwException);
		}

		public static Transfer CancelTransfer(this APIClient client, TransferCancelArguments args, bool throwException = false)
		{
			return client.Update<Transfer>(args, throwExceptions: throwException);
		}
	}
}
