﻿using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe
{
	public class FundDetail
	{
		public Currency Currency { get; set; }

		[Cents]
		public decimal? Amount { get; set; }
	}
}
