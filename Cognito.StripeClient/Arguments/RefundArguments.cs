﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe;
using Cognito.Stripe.Helpers;
using Cognito.Stripe.Classes;

namespace Cognito.StripeClient.Arguments
{
	public class RefundCreateArguments : CreateArguments
	{
		[JsonIgnore]
		public string ChargeId { get; set; }

		[Cents]
		public decimal? Amount { get; set; }

		[JsonIgnore]
		public Currency Currency { get; set; }

		[JsonProperty("refund_application_fee")]
		public bool RefundApplicationFee { get; set; }
		public RefundReason Reason { get; set; }

		public override string GetEndpoint() { return String.Format("charges/{0}/refunds", ChargeId); }
	}

	public class RefundGetArguments : GetArguments
	{
		[JsonIgnore]
		public string ChargeId { get; set; }

		public override string GetEndpoint() { return String.Format("charges/{0}/refunds/{1}", ChargeId, Id); }
	}

	public class RefundUpdateArguments : UpdateArguments
	{
		[JsonIgnore]
		public string ChargeId { get; set; }
		public override string GetEndpoint() { return String.Format("charges/{0}/refunds/{1}", ChargeId, Id); }
	}

	public class RefundSearchArguments : SearchArguments
	{
		[JsonIgnore]
		public string ChargeId { get; set; }

		public override string GetEndpoint() { return String.Format("charges/{0}/refunds", ChargeId); }
	}
}
