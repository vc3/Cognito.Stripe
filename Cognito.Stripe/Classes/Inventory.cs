using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognito.Stripe.Classes
{
	public class Inventory
	{
		public int Quantity { get; set; }
		public InventoryType Type { get; set; }
		
		[JsonProperty("value")]
		public InventoryAvailability Availability { get; set; }
	}

	public enum InventoryType
	{
		Finite,
		Bucket,
		Infinite
	}

	public enum InventoryAvailability
	{
		In_Stock,
		Limited,
		Out_Of_Stock
	}
}
