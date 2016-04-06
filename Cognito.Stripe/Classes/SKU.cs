using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class SKU : BaseObject
	{
		public override string Object { get { return "sku"; } }

		public Currency Currency { get; set; }

		public bool Active { get; set; }
		public Dictionary<string, string> Attributes { get; set; }

		[JsonProperty("image")]
		public string ImageUrl { get; set; }

		public ICollection<Inventory> Inventory { get; set; }

		public PackageDimensions Dimensions { get; set; }
		
		[Currency]
		public decimal? Price { get; set; }

		public Product Product { get; set; }

		[JsonProperty("updated")]
		public DateTime? DateUpdated { get; set; }
	}
}
