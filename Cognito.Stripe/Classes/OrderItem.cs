using Cognito.Stripe.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class OrderItem : BaseObject
	{
		public override string Object { get { return "order_item"; } }

		public Currency Currency { get; set; }

		[Currency]
		public decimal? Amount { get; set; }
		public string Description { get; set; }
		public SKU Parent { get; set; }
		public int Quantity { get; set; }
		public OrderItemType Type { get; set; }
	}

	public enum OrderItemType
	{
		SKU,
		Tax,
		Shipping,
		Discount
	}
}
