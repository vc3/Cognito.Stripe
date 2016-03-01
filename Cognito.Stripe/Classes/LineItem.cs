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

		[Cents]
		public decimal? Amount { get; set; }

		public Currency Currency { get; set; }

		public Period Period { get; set; }
		public bool Proration { get; set; }

		public LineItemType Type { get; set; }
		public string Description { get; set; }
		public Plan Plan { get; set; }
		public int? Quantity { get; set; }
		
		[JsonProperty("subscription")]
		public string SubscriptionId { get; set; }
	}

	public enum LineItemType
	{ 
		invoiceitem,
		subscription
	}
}
