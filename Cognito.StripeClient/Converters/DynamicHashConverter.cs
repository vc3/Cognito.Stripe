using Cognito.Stripe;
using Cognito.Stripe.Classes;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient.Converters
{
	public class DynamicHashConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(DynamicHash<,>);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
				return null;

			var keyType = objectType.GetGenericArguments()[0];
			var valueType = objectType.GetGenericArguments()[1];
			var baseDictionaryType = typeof(Dictionary<,>).MakeGenericType(typeof(string), valueType);

			var baseDictionary = (IDictionary)Activator.CreateInstance(baseDictionaryType);
			serializer.Populate(reader, baseDictionary);

			var hashObjectType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);
			var hashObject = (IDictionary)Activator.CreateInstance(hashObjectType);

			foreach (DictionaryEntry entry in baseDictionary)
				hashObject.Add(LookupConverter.GetLookupValue(keyType, entry.Key.ToString()), entry.Value);

			var dynamicHash = Activator.CreateInstance(objectType);
			var hashObjProperty = objectType.GetProperty("HashObject");

			hashObjProperty.SetValue(dynamicHash, hashObject);

			return dynamicHash;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value == null)
				return;

			var hashObjProperty = value.GetType().GetProperty("HashObject");

			var valueType = value.GetType().GetGenericArguments()[1];
			var baseDictionaryType = typeof(Dictionary<,>).MakeGenericType(typeof(string), valueType);
			var baseDictionary = (IDictionary)Activator.CreateInstance(baseDictionaryType);

			var hashObject = hashObjProperty.GetValue(value) as IDictionary;

			foreach (DictionaryEntry entry in hashObject)
				baseDictionary.Add(((Lookup)entry.Key).Code.ToLower(), entry.Value);

			serializer.Serialize(writer, baseDictionary);
		}
	}
}
