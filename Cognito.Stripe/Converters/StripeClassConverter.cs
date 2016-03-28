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

namespace Cognito.Stripe.Converters
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
			// Immediately return null if the object is null
			if (reader.TokenType == JsonToken.Null)
				return null;

			// create an instance of the specified type
			object instance = null;

			instance = FormatterServices.GetUninitializedObject(objectType);
			serializer.Populate(reader, instance);

			if (instance != null)
			{
				var currencyProp = instance.GetType().GetProperty("Currency");
				if (currencyProp != null)
				{
					Currency currency = currencyProp.GetValue(instance) as Currency ?? Currency.USD;

					// loop over all properties on the object decorated with ConvertToCents attribute and convert their values to
					// cents based on the currency property
					var currencyProperties = instance.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
						.Where(p => p.GetCustomAttribute<CentsAttribute>() != null);

					foreach (var prop in currencyProperties)
					{
						var currentValue = prop.GetValue(instance) as decimal?;
						if (currentValue != null)
							prop.SetValue(instance, BaseObject.GetAmount(currentValue, currency));
					}
				}
			}

			return instance;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value != null)
			{
				var currencyProp = value.GetType().GetProperty("Currency");
				if (currencyProp != null)
				{
					Currency currency = currencyProp.GetValue(value) as Currency ?? Currency.USD;

					// loop over all properties on the object decorated with ConvertToCents attribute and convert their values to
					// cents based on the currency property
					var currencyProperties = value.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
						.Where(p => p.GetCustomAttribute<CentsAttribute>() != null);

					foreach (var prop in currencyProperties)
					{
						var currentValue = prop.GetValue(value) as decimal?;
						if (currentValue != null)
							prop.SetValue(value, BaseObject.GetAmountNoDecimal(currentValue, currency));
					}

				}

				serializer.Serialize(writer, value);
			}
		}
	}
}
