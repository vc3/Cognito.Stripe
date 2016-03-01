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
		public static Charge CaptureCharge(this BaseClient client, ChargeCaptureArguments args)
		{
			return client.Create<Charge>(args);
		}

		public static Invoice PayInvoice(this BaseClient client, InvoicePaymentArguments args, bool throwException = false)
		{
			return client.Update<Invoice>(args, throwException);
		}

		public static Transfer CancelTransfer(this BaseClient client, TransferCancelArguments args)
		{
			return client.Update<Transfer>(args);
		}
	}
}
