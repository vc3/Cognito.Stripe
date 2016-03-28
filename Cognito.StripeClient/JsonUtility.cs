using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe.Converters;

namespace Cognito.StripeClient
{
	internal class JsonUtility
	{
		static JsonSerializer serializer;

		static JsonUtility()
		{
			serializer = new JsonSerializer() { ReferenceLoopHandling = ReferenceLoopHandling.Serialize };
			serializer.Converters.Add(new DateTimeConverter());
			serializer.Converters.Add(new LookupConverter());
			serializer.Converters.Add(new BaseObjectConverter());
			serializer.Converters.Add(new EnumConverter());
			serializer.Converters.Add(new EventDataConverter());
			serializer.Converters.Add(new StripeClassConverter());
		}

		public static string Serialize(object value)
		{
			using (var writer = new StringWriter())
			{
				serializer.Serialize(writer, value);
				return writer.ToString();
			}
		}

		public static T Deserialize<T>(string json)
		{
			using (var reader = new JsonTextReader(new StringReader(json)))
			{
				var result = serializer.Deserialize<T>(reader);
				return result;
			}
		}
	}
}
