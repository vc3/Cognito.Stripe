using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class VerificationFields
	{
		public ICollection<string> Minimum { get; set; }
		public ICollection<string> Additional { get; set; }
	}
}
