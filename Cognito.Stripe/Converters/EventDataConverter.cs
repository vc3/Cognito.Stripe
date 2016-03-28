using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe.Classes;
using System.Runtime.Serialization;
using System.Reflection;
using Cognito.Stripe.Helpers;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace Cognito.Stripe.Converters
{
	public class EventDataConverter : JsonConverter
	{
		static readonly Dictionary<string, Type> typeMappings = new Dictionary<string, Type> {
			{ "plan", typeof(Plan) },
			{ "customer", typeof(Customer) },
			{ "token", typeof(Token) },
			{ "charge", typeof(Charge) },
			{ "refund", typeof(Refund) },
			{ "card", typeof(Card) },
			{ "subscription", typeof(Subscription) },
			{ "coupon", typeof(Coupon) },
			{ "discount", typeof(Discount) },
			{ "invoice", typeof(Invoice) },
			{ "invoiceitem", typeof(InvoiceItem) },
			{ "dispute", typeof(Dispute) },
			{ "transfer", typeof(Transfer) },
			{ "recipient", typeof(Recipient) },
			{ "application_fee", typeof(ApplicationFee) },
			{ "fee_refund", typeof(ApplicationFeeRefund) },
			{ "account", typeof(Account) },
			{ "balance", typeof(Balance) },
			{ "balance_transaction", typeof(BalanceTransaction) },
			{ "event", typeof(Event) },
			{ "bitcoin_receiver", typeof(BitcoinReceiver) },
			{ "source", typeof(PaymentSource) }
		};

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(EventData);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			BaseObjectConverter.Serialize(writer, value, serializer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var instance = FormatterServices.GetUninitializedObject(objectType) as EventData;

			var eventData = JObject.Load(reader);
			var dataObject = eventData["object"] as JObject;
			var prevAttrObject = eventData["previous_attributes"] as JObject;

			var dataType = typeof(BaseObject);

			if (!typeMappings.TryGetValue(dataObject["object"].ToString(), out dataType))
				dataType = typeof(BaseObject);

			var constructor = dataType.GetConstructor(Type.EmptyTypes);

			var data = constructor.Invoke(null);
			var dataReader = dataObject.CreateReader();
			dataReader.Read();			

			instance.Object = BaseObjectConverter.ConvertToEntity(dataReader, dataType, existingValue, serializer) as BaseObject;

			if (prevAttrObject != null)
			{
				var previousAttr = constructor.Invoke(null);
				var prevAttrReader = dataObject.CreateReader();
				prevAttrReader.Read();

				instance.PreviousAttributes = BaseObjectConverter.ConvertToEntity(prevAttrReader, dataType, existingValue, serializer) as BaseObject;
			}

			return instance;
		}
	}
}
