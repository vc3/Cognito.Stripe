using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient.Converters
{
	public class EnumConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			var type = objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(objectType) : objectType;
			
			return type.IsEnum;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var result = existingValue;

			if (reader.TokenType == JsonToken.String)
			{
				var value = reader.Value.ToString();
				var type = objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(objectType) : objectType;

				result = !String.IsNullOrWhiteSpace(value) ? Enum.Parse(type, value, true) : 0;
			}

			return result;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(value.ToString().ToLower());
		}
	}
}
