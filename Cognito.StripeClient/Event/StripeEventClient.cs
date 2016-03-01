using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cognito.Payment.DataTransfer.Stripe.Services.Event
{
	public class StripeEventClient<T> : StripeClient
		where T : StripeObject, new()
	{
		public StripeEventClient(string apiKey, string organization)
			: base(Cognito.Configuration.Current.PaymentProviderSettings.StripeSettings.BaseApiUrl, apiKey, organization)
		{
				Endpoints.Add("Get", "{0}/events/{1}");
		}

		public StripeEvent<T> GetEvent(string eventId)
		{
			var result = ProcessRequest<StripeEvent<T>>(CreateStripeRequest("Get").WithParameters(eventId), HttpVerbs.Get);

			if (result.Error != null)
				throw new ApplicationException(result.Error.Message);

			return result;
		}
	}
}