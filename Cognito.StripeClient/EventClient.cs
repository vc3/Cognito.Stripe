using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe;
using Cognito.Stripe.Classes;
using Cognito.StripeClient.Arguments;

namespace Cognito.StripeClient
{
	public class EventClient : BaseClient<Event>
	{
		protected static readonly Dictionary<Type, string> typeMappings = new Dictionary<Type, string> {
			{ typeof(Plan), "plan" },
			{ typeof(Customer), "customer"},
			{ typeof(Token), "token"},
			{ typeof(Charge), "charge"},
			{ typeof(Refund), "refund"},
			{ typeof(Card), "card"},
			{ typeof(Subscription), "subscription"},
			{ typeof(Coupon), "coupon"},
			{ typeof(Discount), "discount"},
			{ typeof(Invoice), "invoice"},
			{ typeof(LineItem), "invoice"},
			{ typeof(InvoiceItem), "invoiceitem"},
			{ typeof(Dispute), "dispute"},
			{ typeof(Transfer), "transfer"},
			{ typeof(Recipient), "recipient"},
			{ typeof(ApplicationFee), "application_fees"},
			{ typeof(ApplicationFeeRefund), "fee_refund"},
			{ typeof(Account), "account"},
			{ typeof(Balance), "balance"},
			{ typeof(BalanceTransaction), "balance_transaction"},
			{ typeof(Event), "event"},
			{ typeof(BitcoinReceiver), "bitcoin_receiver"},
			{ typeof(Source), "source"}
		};

		public string DataObjectType { get; set; }

		public EventClient(string apiKey, string dataObjType = null, string baseUrl = "", APIVersion version = APIVersion.v1)
			: base(apiKey, baseUrl, version)
		{
			DataObjectType = dataObjType;
		}

		public override Event Get(GetArguments args, bool throwExceptions = false)
		{
			return String.IsNullOrWhiteSpace(DataObjectType) ? base.Get(args, throwExceptions) : GetEventWithData(args);
		}

		Event GetEventWithData(GetArguments args)
		{
			Type objType = typeMappings.Keys.FirstOrDefault(k => typeMappings[k] == DataObjectType);

			// get generic type for the stripe event client
			var genericType = typeof(EventClient<>).MakeGenericType(objType);

			// construct the appropriate EventClient<T>
			var client = genericType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(string), typeof(APIVersion) }, null)
				.Invoke(new object[] { ApiKey, this.BaseUrl, APIVersion.v1 });

			// invoke the Get method of the EventClient<T>
			return (Event)genericType.GetMethod("Get", BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy)
				.Invoke(client, new object[] { args, false });
		}
	}

	public class EventClient<T> : BaseClient<Event<T>>
		where T : BaseObject, new()
	{
		public EventClient(string apiKey, string baseUrl = "", APIVersion version = APIVersion.v1)
			: base(apiKey, baseUrl, version)
		{ }
	}
}
