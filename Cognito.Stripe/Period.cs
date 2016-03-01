using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe
{
	public class Period
	{
		[JsonProperty("start")]
		public DateTime? StartDate { get; set; }
		[JsonProperty("end")]
		public DateTime? EndDate { get; set; }
	}
}
