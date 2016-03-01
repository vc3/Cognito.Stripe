using Cognito.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VC3.Stripe
{
	/// <summary>
	/// Base class for all stripe even tasks to inherit from
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class StripeEventTask<T> : BackgroundTask<T>
		where T : BaseService
	{
		public StripeEventTask(ExternalAccount externalAccount, T service)
			: base(service)
		{
			ExternalAccount = externalAccount;
		}

		public override void Execute() { }
	}
}