using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class FundDetail
	{
		Currency Currency { get; set; }

		[Currency]
		decimal? Amount { get; set; }
	}
}
