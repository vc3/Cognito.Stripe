using Cognito.Model;
using VC3.Stripe.Services.Account;
using VC3.Stripe.Services.ApplicationFee;
using VC3.Stripe.Services.Charge;
using Cognito.Payment.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VC3.Stripe
{
	#region StripeEvent
	/// <summary>
	/// Represents data passed from Stripe in a webhook request
	/// </summary>
	public class StripeEvent : StripeObject
	{
		public override string Object { get { return "event"; } }
		[JsonProperty("pending_webhooks")]
		public int NumberOfPendingWebHooks { get; set; }
		public string Type { get; set; }
		[JsonProperty("request")]
		public string RequestId { get; set; }
		[JsonProperty("user_id")]
		public string AccountId { get; set; }
	}

	/// <summary>
	/// Represents a <see cref="StripeEvent"/> for a specific <see cref="StripeObject"/>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class StripeEvent<T> : StripeEvent
		where T : StripeObject, new()
	{
		public StripeEventData<T> Data { get; set; }
	}
	#endregion

	#region StripeEventData
	/// <summary>
	/// Represents the specific <see cref="StripeObject"/> in the Stripe Event
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class StripeEventData<T>
		where T : StripeObject, new()
	{
		public StripeEventData()
		{
			Object = new T();
		}

		[JsonConverter(typeof(StripeEntityConverter))]
		public T Object { get; set; }
		public object previous_attributes { get; set; }
	}
	#endregion

	#region StripeEventRequest
	/// <summary>
	/// Base class that represents the Stripe event request.  Contains the 
	/// </summary>
	public class StripeEventRequest
	{
		#region Mappings
		public static Dictionary<StripeEventType, Tuple<Type, Type, Type>> Mappings = new Dictionary<StripeEventType, Tuple<Type, Type, Type>>() { 
			{StripeEventType.accountapplicationdeauthorized, new Tuple<Type, Type, Type>(typeof(StripeApplication), typeof(StripeAccountDeauthorizedEventTask), typeof(CoreService))},
			{ StripeEventType.accountupdated, new Tuple<Type, Type, Type>(typeof(StripeAccount), typeof(StripeAccountUpdatedEventTask), typeof(CoreService))},
			//{ StripeEventType.application_feecreated, typeof(StripeApplicationFee) },
			//{ StripeEventType.application_feerefunded, new Tuple<Type, Type>(typeof(StripeApplicationFee), typeof(StripeApplicationFeeEventTask)) },
			//{ StripeEventType.balanceavailable, typeof(StripeBalance) },
			//{ StripeEventType.chargesucceeded, typeof(StripeCharge) },
			//{ StripeEventType.chargefailed, typeof(StripeCharge) },
			{ StripeEventType.chargerefunded, new Tuple<Type, Type, Type>(typeof(StripeCharge), typeof(StripeChargeRefundedTask), typeof(PaymentService)) },
			//{ StripeEventType.chargecaptured, typeof(StripeCharge) },
			//{ StripeEventType.chargeupdated, typeof(StripeCharge) },
			//{ StripeEventType.chargedisputecreated, typeof(StripeDispute) },
			//{ StripeEventType.chargedisputeupdated, typeof(StripeDispute) },
			//{ StripeEventType.chargedisputeclosed, typeof(StripeDispute) },
			//{ StripeEventType.customercreated, typeof(StripeCustomer) },
			//{ StripeEventType.customerupdated, typeof(StripeCustomer) },
			//{ StripeEventType.customerdeleted, typeof(StripeCustomer) },
			//{ StripeEventType.customercardcreated, typeof(StripeCard) },
			//{ StripeEventType.customercardupdated, typeof(StripeCard) },
			//{ StripeEventType.customercarddeleted, typeof(StripeCard) }
			//{ StripeEventType.customersubscriptioncreated, typeof(StripeSubscription) },
			//{ StripeEventType.customersubscriptionupdated, typeof(StripeSubscription) },
			//{ StripeEventType.customersubscriptiondeleted, typeof(StripeSubscription) },
			//{ StripeEventType.customersubscriptiontrial_will_end, typeof(StripeSubscription) },
			//{ StripeEventType.customerdiscountcreated, typeof(StripeDiscount) },
			//{ StripeEventType.customerdiscountupdated, typeof(StripeDiscount) },
			//{ StripeEventType.customerdiscountdeleted, typeof(StripeDiscount) },
			//{ StripeEventType.invoicecreated, typeof(StripeInvoice) },
			//{ StripeEventType.invoiceupdated, typeof(StripeInvoice) },
			//{ StripeEventType.invoicepayment_succeeded, typeof(StripeInvoice) },
			//{ StripeEventType.invoicepayment_failed, typeof(StripeInvoice) },
			//{ StripeEventType.invoiceitemcreated, typeof(StripeInvoiceItem) },
			//{ StripeEventType.invoiceitemupdated, typeof(StripeInvoiceItem) },
			//{ StripeEventType.invoiceitemdeleted, typeof(StripeInvoiceItem) },
			//{ StripeEventType.plancreated, typeof(StripePlan) },
			//{ StripeEventType.planupdated, typeof(StripePlan) },
			//{ StripeEventType.plandeleted, typeof(StripePlan) },
			//{ StripeEventType.couponcreated, typeof(StripeCoupon) },
			//{ StripeEventType.coupondeleted, typeof(StripeCoupon) },
			//{ StripeEventType.transfercreated, typeof(StripeTransfer) },
			//{ StripeEventType.transferupdated, typeof(StripeTransfer) },
			//{ StripeEventType.transferpaid, typeof(StripeTransfer) },
			//{ StripeEventType.transferfailed, typeof(StripeTransfer) }
		};
		#endregion

		public string Id { get; set; }
		public string Type { get; set; }
		public bool LiveMode { get; set; }
		public string Request { get; set; }
		public string User_Id { get; set; }
	}

	/// <summary>
	/// Represents a Stripe event request.  Pulls only the minimum data from the request
	/// then submits a request back to Stripe to pull the remaining detials
	/// </summary>
	public class StripeEventRequest<T> : StripeEventRequest
		where T : StripeObject, new()
	{
		public StripeEventRequest()
		{
			Data = new StripeEventData<T>();
		}

		public StripeEventData<T> Data { get; set; }
	}
	#endregion

	/// <summary>
	/// Represents the list of events that Stripe could notify Cognito about.
	/// Actual stripe event type names contain "." (ie customer.updated), enums
	/// identified as the name without the "."
	/// </summary>
	public enum StripeEventType
	{
		accountupdated,
		accountapplicationdeauthorized,
		application_feecreated,
		application_feerefunded,
		balanceavailable,
		chargesucceeded,
		chargefailed,
		chargerefunded,
		chargecaptured,
		chargeupdated,
		chargedisputecreated,
		chargedisputeupdated,
		chargedisputeclosed,
		customercreated,
		customerupdated,
		customerdeleted,
		customercardcreated,
		customercardupdated,
		customercarddeleted,
		customersubscriptioncreated,
		customersubscriptionupdated,
		customersubscriptiondeleted,
		customersubscriptiontrial_will_end,
		customerdiscountcreated,
		customerdiscountupdated,
		customerdiscountdeleted,
		invoicecreated,
		invoiceupdated,
		invoicepayment_succeeded,
		invoicepayment_failed,
		invoiceitemcreated,
		invoiceitemupdated,
		invoiceitemdeleted,
		plancreated,
		planupdated,
		plandeleted,
		couponcreated,
		coupondeleted,
		transfercreated,
		transferupdated,
		transferpaid,
		transferfailed,
		ping,
		unknown
	}
}