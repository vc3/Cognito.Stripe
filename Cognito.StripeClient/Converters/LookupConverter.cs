using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cognito.StripeClient;
using Cognito.Stripe;

namespace Cognito.StripeClient.Converters
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
				result = GetLookupValue(objectType, reader.Value.ToString());

			return result;
		}

		public static Lookup GetLookupValue(Type objectType, string lookupCode)
		{
			Dictionary<string, Lookup> lookups = null;

			if (!AllLookups.TryGetValue(objectType, out lookups))
			{
				lookups = new Dictionary<string, Lookup>();
				var allProp = (Lookup[])objectType.GetProperty("All", BindingFlags.Static | BindingFlags.Public).GetValue(null);

				foreach (var lookup in allProp)
					lookups[lookup.Code] = lookup;

				AllLookups[objectType] = lookups;
			}

			if(!String.IsNullOrWhiteSpace(lookupCode))
				return AllLookups[objectType][lookupCode.ToUpper()];

			return null;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(((Lookup)value).Code.ToLower());
		}
	}
}
