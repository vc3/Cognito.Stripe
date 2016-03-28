using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe.Converters;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Collections.Specialized;

namespace Cognito.Stripe.Classes
{
	public class Event : BaseObject
	{
		public override string Object { get { return "event"; } }

		[JsonProperty("api_version")]
		public string APIVersion { get; set; }

		[JsonProperty("pending_webhooks")]
		public int? PendingWebhooks { get; set; }
		
		public string Type { get; set; }
		public string Request { get; set; }
		
		[JsonProperty("user_id")]
		public string UserId { get; set; }

		public EventData Data { get; set; }
	}

	public class EventData
	{
		public BaseObject Object { get; set; }

		[JsonProperty("previous_attributes")]
		public BaseObject PreviousAttributes { get; set; }
	}
}
