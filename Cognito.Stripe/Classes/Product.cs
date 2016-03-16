using Cognito.Stripe.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class Product : BaseObject
	{		
		public override string Object { get { return "product"; } }

		public bool Active { get; set; }
		public ICollection<string> Attributes { get; set; }
		public string Caption { get; set; }
		public string Description { get; set; }
		public ICollection<string> Images { get; set; }
		public string Name { get; set; }

		[JsonProperty("package_dimensions")]
		public PackageDimensions Dimensions { get; set; }

		public bool Shippable { get; set; }
		public StripeList<SKU> SKUs { get; set; }

		[JsonProperty("updated")]
		[JsonConverter(typeof(DateTimeConverter))]
		public DateTime? DateUpdated { get; set; }

		public string URL { get; set; }
	}
}
