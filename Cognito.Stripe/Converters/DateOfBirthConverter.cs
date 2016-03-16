using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.Stripe.Converters
{
	public class DateOfBirthConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DateTime?);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object value, JsonSerializer serializer)
		{
			// Immediately return null if the object is null or is not the start of an object
			if (reader.TokenType == JsonToken.Null || reader.TokenType != JsonToken.StartObject)
				return null;

			var dobObj = new DateOfBirth();

			serializer.Populate(reader, dobObj);

			return new DateTime(dobObj.year, dobObj.month, dobObj.day);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value != null)
				serializer.Serialize(writer, new DateOfBirth((DateTime?)value));
		}
	}

	class DateOfBirth
	{
		public DateOfBirth() { }

		public DateOfBirth(DateTime? date)
		{ 
			if(!date.HasValue)
				return;

			day = date.Value.Day;
			month = date.Value.Month;
			year = date.Value.Year;
		}

		public int day { get; set; }
		public int month { get; set; }
		public int year { get; set; }
	}
}
