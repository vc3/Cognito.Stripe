using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Helpers
{
	public class CentsAttribute : Attribute
	{
		public CentsAttribute() { }

		public CentsAttribute(string propertyName)
			:base()
		{
			PropertyName = propertyName;
		}

		public string PropertyName { get; set; }
	}
}
