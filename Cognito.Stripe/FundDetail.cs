using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe
{
	public class FundDetail
	{
		[Cents]
		public decimal? Amount { get; set; }

		public Currency Currency { get; set; }
	}
}
