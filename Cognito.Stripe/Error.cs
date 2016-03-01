using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe
{
	public class Error
	{
		public int? ResponseCode { get; set; }
		public string Message { get; set; }
		public string Code { get; set; }
		public StripeErrorType Type { get; set; }
	}

	public enum StripeErrorType
	{ 
		invalid_request_error,
		api_error,
		card_error,
		invalid_request,
		invalid_client,
		invalid_grant,
		invalid_scope,
		unsupported_grant_type,
		unsupported_response_type
	}
}
