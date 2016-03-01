using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe
{
	public class Lookup
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public virtual string DisplayName { get { return Name; } }

		public override string ToString()
		{
			return DisplayName;
		}
	}
}
