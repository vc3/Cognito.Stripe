using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class EvidenceDetails : BaseObject
	{
		[JsonProperty("submission_count")]
		public int? SubmissionCount { get; set; }

		[JsonProperty("due_by")]
		public DateTime? DueDate { get; set; }
	}
}
