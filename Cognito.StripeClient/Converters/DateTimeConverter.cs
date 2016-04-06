using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cognito.StripeClient.Converters
{
	public class DateTimeConverter : DateTimeConverterBase
	{
		static DateTime StartDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public static DateTime ConvertToDate(double? seconds)
		{
			return StartDate.AddSeconds(seconds.GetValueOrDefault(0));
		}

		public static int? ConvertToSeconds(DateTime? date)
		{
			if (date.HasValue)
				return Convert.ToInt32(date.Value.Subtract(StartDate).TotalSeconds);

			return null;
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DateTime?);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object value, JsonSerializer serializer)
		{
			double seconds = 0;

			if (reader.Value != null && Double.TryParse(reader.Value.ToString(), out seconds))
				return ConvertToDate(seconds);

			return null;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			int? seconds = null;
			if (value != null)
				seconds = ConvertToSeconds((DateTime?)value);

			if(seconds != null && seconds.HasValue)	
				writer.WriteValue(seconds.Value.ToString());
		}
	}
}
