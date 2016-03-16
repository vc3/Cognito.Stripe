using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class Verification
	{
		public string Details { get; set; }
		
		[JsonProperty("details_code")]
		public DetailsCode DetailsCode { get; set; }

		public FileUpload Document { get; set; }

		public VerificationStatus Status { get; set; }
	}

	public enum DetailsCode
	{ 
		scan_corrupt,
		scan_not_readable,
		scan_not_uploaded,
		scan_id_type_not_supported,
		scan_id_countery_not_supported,
		scan_name_mismatch,
		scan_failed_other,
		failed_other
	}

	public enum VerificationStatus
	{ 
		Unverified,
		Pending,
		Verified
	}
}
