using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	public class LineItem : BaseObject
	{
		public override string Object { get { return "line_item"; } }

		public Currency Currency { get; set; }

		[Currency]
		public decimal? Amount { get; set; }
		public string Description { get; set; }
		public bool Discountable { get; set; }

		public Period Period { get; set; }
		public Plan Plan { get; set; }
		public bool Proration { get; set; }
		public int? Quantity { get; set; }
		public Subscription Subscription { get; set; }
		public LineItemType Type { get; set; }
	}

	public enum LineItemType
	{ 
		InvoiceItem,
		Subscription
	}
}
