using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class EvidenceDetails : BaseObject
	{
		[JsonProperty("due_by")]
		public DateTime? DueDate { get; set; }

		[JsonProperty("has_evidence")]
		public bool HasEvidence { get; set; }

		[JsonProperty("past_due")]
		public bool PastDue { get; set; }

		[JsonProperty("submission_count")]
		public int? SubmissionCount { get; set; }
	}
}
