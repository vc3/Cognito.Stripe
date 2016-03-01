using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VC3.Stripe
{
	public class StripeEntityConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			serializer.Serialize(writer, value);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			// Immediately return null if the object is null
			if (reader.TokenType == JsonToken.Null)
				return null;

			// create an instance of the specified type
			var instance = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(objectType);

			serializer.Populate(reader, instance);

			return instance;
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType.BaseType != null && objectType.BaseType.IsGenericType && objectType.BaseType.GetGenericTypeDefinition() == typeof(StripeEventData<>);
		}
	}
}
