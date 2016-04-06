using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Helpers
{
	public class CurrencyAttribute : Attribute
	{
		public CurrencyAttribute() { }

		public CurrencyAttribute(string propertyName)
			:base()
		{
			PropertyName = propertyName;
		}

		public string PropertyName { get; set; }
	}
}
