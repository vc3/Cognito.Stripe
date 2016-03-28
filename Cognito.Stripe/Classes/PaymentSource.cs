using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Classes
{
	/// <summary>
	/// Represents all properties that could be provided by Stripe in the Source property of a customer or charge
	/// Combines properties for <see cref="Card"/> and <see cref="BitcoinReceiver"/>
	/// </summary>
	public class PaymentSource : BaseObject
	{
		public string Fingerprint { get; set; }
	
		public Currency Currency { get; set; }
	}

	public enum SourceType
	{ 
		Card,
		Bank_Account,
		Bitcoin_Receiver,
		Alipay_Account
	}
}
