using Cognito.Stripe;
using Cognito.Stripe.Classes;
using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient.Converters
{
	public class StripeClassConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType.Namespace.Equals("Cognito.Stripe.Classes", StringComparison.OrdinalIgnoreCase) 
				&& !typeof(BaseObject).IsAssignableFrom(objectType)
				&& !typeof(EventData).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return BaseObjectConverter.ConvertToEntity(reader, objectType, existingValue, serializer);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			BaseObjectConverter.Serialize(writer, value, serializer);
		}
	}
}
