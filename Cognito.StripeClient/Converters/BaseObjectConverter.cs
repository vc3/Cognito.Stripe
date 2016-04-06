using Cognito.Stripe;
using Cognito.Stripe.Classes;
using Cognito.Stripe.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cognito.StripeClient.Converters
{
	public class BaseObjectConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(BaseObject).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return ConvertToEntity(reader, objectType, existingValue, serializer);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			Serialize(writer, value, serializer);
		}

		public static void Serialize(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value != null)
			{
				var currencyProp = value.GetType().GetProperty("Currency");
				if (currencyProp != null)
				{
					Currency currency = currencyProp.GetValue(value) as Currency ?? Currency.USD;

					// loop over all properties on the object decorated with ConvertToCents attribute and convert their values to
					// cents based on the currency property
					var currencyProperties = value.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
						.Where(p => p.GetCustomAttribute<CurrencyAttribute>() != null);

					foreach (var prop in currencyProperties)
					{
						var currentValue = prop.GetValue(value) as decimal?;
						if (currentValue != null)
							prop.SetValue(value, BaseObject.GetAmountNoDecimal(currentValue, currency));
					}

				}

				writer.WriteStartObject();

				foreach (PropertyInfo prop in value.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
						.Where(p => p.GetCustomAttribute<JsonIgnoreAttribute>() == null))
				{
					var jsonPropAttr = prop.GetCustomAttribute(typeof(JsonPropertyAttribute)) as JsonPropertyAttribute;

					var propertyName = jsonPropAttr != null ? jsonPropAttr.PropertyName : prop.Name;

					if (prop.CanRead)
					{
						writer.WritePropertyName(propertyName.ToLower());

						object propVal = prop.GetValue(value, null);
						if (propVal != null)
							serializer.Serialize(writer, propVal);
						else
							writer.WriteNull();
					}
				}

				writer.WriteEndObject();
			}
		}

		public static object ConvertToEntity(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			// Immediately return null if the object is null
			if (reader.TokenType == JsonToken.Null)
				return null;

			// create an instance of the specified type
			object instance = null;

			// if the token is the start of an object, fully populate the properties on the instance
			// else the object is not fully expanded and only the id of the object is returned.
			if (reader.TokenType == JsonToken.StartObject)
			{
				if (objectType == typeof(Transaction))
					instance = ConvertTransaction(reader, objectType, serializer);
				else if (objectType == typeof(PaymentSource))
					instance = ConvertPaymentSource(reader, objectType, serializer);
				else
				{
					instance = objectType.GetConstructor(Type.EmptyTypes).Invoke(null);
					serializer.Populate(reader, instance);
				}

				if(typeof(BaseObject).IsAssignableFrom(objectType))
					((BaseObject)instance).Loaded = true;
			}
			else if (reader.TokenType == JsonToken.String)
			{
				instance = FormatterServices.GetUninitializedObject(objectType);
				((BaseObject)instance).Id = reader.Value.ToString();
			}

			if (instance != null)
			{
				var currencyProp = instance.GetType().GetProperty("Currency");
				if (currencyProp != null)
				{
					Currency currency = currencyProp.GetValue(instance) as Currency ?? Currency.USD;

					// loop over all properties on the object decorated with ConvertToCents attribute and convert their values to
					// cents based on the currency property
					var currencyProperties = instance.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
						.Where(p => p.GetCustomAttribute<CurrencyAttribute>() != null);

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

		static object ConvertTransaction(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			Transaction instance = new Transaction();
			JObject transactionObj = JObject.Load(reader);
			reader = transactionObj.CreateReader();
			reader.Read();

			if (transactionObj != null)
			{
				var trxType = transactionObj["object"].ToString();

				switch (trxType)
				{
					case "charge":
						instance = new Charge();
						break;
					case "application_fee":
						instance = new ApplicationFee();
						break;
					case "transfer":
						instance = new Transfer();
						break;
					case "refund":
						instance = new Refund();
						break;
					default:
						instance = new Transaction();
						break;
				}
			}

			serializer.Populate(reader, instance);

			return instance;
		}

		static object ConvertPaymentSource(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			PaymentSource instance = new PaymentSource();
			JObject paySourceObj = JObject.Load(reader);
			reader = paySourceObj.CreateReader();
			reader.Read();

			if (paySourceObj != null)
			{
				var trxType = paySourceObj["object"].ToString();

				switch (trxType)
				{
					case "card":
						instance = new Card();
						break;
					case "bank_account":
						instance = new BankAccount();
						break;
					case "bitcoin_receiver":
						instance = new BitcoinReceiver();
						break;
					case "alipay_account":
						instance = new AliPayAccount();
						break;
					default:
						instance = new PaymentSource();
						break;
				}
			}

			serializer.Populate(reader, instance);

			return instance;
		}
	}
}
