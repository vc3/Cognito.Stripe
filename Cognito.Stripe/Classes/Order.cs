using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class Order : BaseObject
	{
		public override string Object { get { return "order"; } }
		
		public Currency Currency { get; set;}

		[Currency]
		public decimal? Amount { get; set; }

		[JsonProperty("application")]
		public string ApplicationId { get; set; }

		[Currency]
		[JsonProperty("application_fee")]
		public decimal? ApplicationFee { get; set; }

		public Charge Charge { get; set; }
		public string Email { get; set; }

		[JsonProperty("external_coupon_code")]
		public string ExternalCouponCode { get; set; }

		public StripeList<OrderItem> Items { get; set; }

		[JsonProperty("selected_shipping_method")]
		public string SelectedShippingMethod { get; set; }

		public ShippingInfo Shipping { get; set; }

		[JsonProperty("shipping_methods")]
		public ICollection<ShippingMethod> ShippingMethods { get; set; }

		public OrderStatus Status { get; set; }

		[JsonProperty("updated")]
		public DateTime? DateUpdated { get; set; }
	}

	public enum OrderStatus
	{
		Created,
		Paid,
		Canceled,
		Fulfilled,
		Returned
	}
}
