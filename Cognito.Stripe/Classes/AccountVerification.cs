using Cognito.Stripe.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class AccountVerification
	{
		[JsonProperty("disabled_reason")]
		public string DisabledReason{ get; set; }

		[JsonProperty("due_by")]
		[JsonConverter(typeof(DateTimeConverter))]
		public DateTime? DueDate { get; set; }

		[JsonProperty("fields_needed")]
		public ICollection<string> FieldsNeeded { get; set; }
	}
}
