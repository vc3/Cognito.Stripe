using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe.Converters;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Collections.Specialized;

namespace Cognito.Stripe.Classes
{
	public class Event : BaseObject
	{
		public override string Object { get { return "event"; } }

		public string API_Version { get; set; }

		public int? Pending_Webhooks { get; set; }
		
		public string Type { get; set; }
		public string Request { get; set; }
		public string User_Id { get; set; }
	}

	public class Event<T> : Event
		where T : BaseObject, new()
	{
		public EventData<T> Data { get; set; }
	}

	/// <summary>
	/// Represents the specific <see cref="BaseObject"/> in the Stripe Event
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EventData<T>
		where T : BaseObject, new()
	{
		public EventData()
		{
			Object = new T();
		}

		[JsonConverter(typeof(EventDataConverter))]
		public T Object { get; set; }

		[JsonConverter(typeof(EventDataConverter))]
		public T Previous_Attributes { get; set; }
	}
}
