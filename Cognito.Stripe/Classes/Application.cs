using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cognito.Stripe.Classes
{
	public class Application : BaseObject
	{
		public override string Object { get { return "application"; } }
		public string Name { get; set; }
	}
}