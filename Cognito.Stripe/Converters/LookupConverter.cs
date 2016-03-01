using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe;

namespace Cognito.Stripe.Converters
{
	public class LookupConverter : JsonConverter
	{
		static Dictionary<Type, Dictionary<string, Lookup>> AllLookups = new Dictionary<Type, Dictionary<string, Lookup>>();

		public override bool CanConvert(Type objectType)
		{
			return typeof(Lookup).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var result = existingValue;

			Dictionary<string, Lookup> lookups = null;

			if (!AllLookups.TryGetValue(objectType, out lookups))
			{
				lookups = new Dictionary<string, Lookup>();
				var allProp = (Lookup[])objectType.GetProperty("All", BindingFlags.Static | BindingFlags.Public).GetValue(null);

				foreach (var lookup in allProp)
					lookups[lookup.Code] = lookup;

				AllLookups[objectType] = lookups;
			}

			if(reader.Value != null)
				result = AllLookups[objectType][reader.Value.ToString().ToUpper()];

			return result;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(((Lookup)value).Code);
		}
	}
}
