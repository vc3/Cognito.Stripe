using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class Balance : BaseObject
	{
		public override string Object { get { return "balance"; } }

		[JsonProperty("available")]
		public ICollection<FundDetail> AvailableFunds { get; set; }
		[JsonProperty("pending")]
		public ICollection<FundDetail> PendingFunds { get; set; }
	}
}
