﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognito.Stripe;
using Cognito.Stripe.Helpers;
using System.Collections.Specialized;

namespace Cognito.StripeClient.Arguments
{
	public class InvoiceCreateArguments : CreateArguments
	{
		[JsonProperty("customer")]
		public string CustomerId { get; set; }

		[JsonIgnore]
		public Currency Currency { get; set; }

		[Currency]
		[JsonProperty("application_fee")]
		public decimal? ApplicationFeeAmount { get; set; }

		public string Description { get; set; }
		
		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }

		[JsonProperty("subscription")]
		public string SubscriptionId { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "invoices"; } }
	}

	public class InvoiceGetArguments : GetArguments
	{
		[JsonIgnore]
		public override string ObjectName { get { return "invoices"; } }

		[JsonIgnore]
		public bool ExpandCharge
		{
			set
			{
				ToggleExpandedProperty(value, "charge");
			}
		}

		[JsonIgnore]
		public bool ExpandCustomer
		{
			set
			{
				ToggleExpandedProperty(value, "customer");
			}
		}
	}

	public class InvoiceUpcomingArguments : GetArguments
	{ 
		[JsonProperty("customer")]
		public string CustomerId { get; set; }
		[JsonProperty("subscription")]
		public string SubscriptionId { get; set; }
		[JsonProperty("subscription_plan")]
		public string PlanId { get; set; }
		[JsonProperty("subscription_quantity")]
		public int SubscriptionQuantity { get; set; }
		[JsonProperty("subscription_prorate")]
		public bool Prorate { get; set; }
		[JsonProperty("subscription_proration_date")]
		public DateTime? ProrationDate { get; set; }
		[JsonProperty("subscription_billing_cycle_anchored_at")]
		public BillingCycleAnchor BillingCycleAnchor { get; set; }

		public override string GetEndpoint()
		{
			return "invoices/upcoming";
		}
	}

	public class InvoiceUpdateArguments : UpdateArguments
	{
		[JsonIgnore]
		public Currency Currency { get; set; }

		[Currency]
		[JsonProperty("application_fee")]
		public decimal? ApplicationFeeAmount { get; set; }

		public string Description { get; set; }

		[JsonProperty("statement_descriptor")]
		public string StatementDescriptor { get; set; }

		public bool Closed { get; set; }
		public bool? Forgiven { get; set; }

		[JsonIgnore]
		public override string ObjectName { get { return "invoices"; } }
	}

	public class InvoicePaymentArguments : UpdateArguments
	{
		public override string GetEndpoint()
		{
			return String.Format("invoices/{0}/pay", Id);
		}
	}

	public class InvoiceSearchArguments : ListArguments
	{
		[JsonProperty("customer")]
		public string CustomerId { get; set; }

		[JsonProperty("date[gt]")]
		public new DateTime? CreatedAfter { get; set; }
		[JsonProperty("date[gte]")]
		public new DateTime? CreatedOnOrAfter { get; set; }
		[JsonProperty("date[lt]")]
		public new DateTime? CreatedBefore { get; set; }
		[JsonProperty("date[lte]")]
		public new DateTime? CreatedOnOrBefore { get; set; }

		[JsonIgnore]
		public bool ExpandCharge
		{
			set 
			{
				ToggleExpandedProperty(value, "data.charge");
			}
		}

		[JsonIgnore]
		public bool ExpandCustomer
		{
			set
			{
				ToggleExpandedProperty(value, "data.customer");
			}
		}

		[JsonIgnore]
		public override string ObjectName { get { return "invoices"; } }
	}
}
